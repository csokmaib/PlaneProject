using Microsoft.AspNetCore.SignalR;
using PlaneProject.Models;

namespace PlaneProject.Services
{
    public class CommunicationHub: Hub
    {
        private IGameService _gameService;
        public CommunicationHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task AddWaitingPlayerIntoQueue()
        {
            Guid playerId = Guid.NewGuid();
            _gameService.RegisterPlayer(Context.ConnectionId, playerId);
            var result = _gameService.AddWaitingPlayerIntoQueue(Context.ConnectionId);

            if (result.ConnectionId1 != null && result.ConnectionId2 != null && result.GameId != Guid.Empty)
            {
                await Clients.Client(result.ConnectionId2).SendAsync("GameStarted", result.GameId);
                await Clients.Client(result.ConnectionId1).SendAsync("GameStarted", result.GameId);
            }
        }

        public async Task SetPlanes(List<PlanePart> planes, string gameId)
        {
            //TO DO: send message if the planes are not placed correctly
            var result = _gameService.SetPlanes(planes, gameId, Context.ConnectionId);

            if (result.ConnectionId1 != null && result.ConnectionId2 != null)
            {
                await Clients.Client(result.ConnectionId1).SendAsync("NextTurn", result.IsPlayer1Turn);
                await Clients.Client(result.ConnectionId2).SendAsync("NextTurn", !result.IsPlayer1Turn);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("WaitForOpponentToSetPlanes");
            }  
        }

        public async Task SendFiring(PlanePart planePart, string gameId)
        {
            var result = _gameService.CheckIfHit(planePart, gameId, Context.ConnectionId);

            if (result.ConnectionId1 != null && result.ConnectionId2 != null)
            {
                await Clients.Client(result.ConnectionId1).SendAsync("NextFire", result.HitResult, result.IsPlayer1Turn);
                await Clients.Client(result.ConnectionId2).SendAsync("NextFire", result.HitResult, !result.IsPlayer1Turn);
            }
        }

        //TO DO: combine NextTurn with NextFire
    }
}
