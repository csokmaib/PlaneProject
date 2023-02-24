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
            //string message = "";

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

            //await Clients.All.SendAsync("ValidatePlanes", message, success);
            //await Clients.All.SendAsync("ReceiveFiringResult", , x, y);
            //await Clients.Group(myId).SendAsync("ReceiveFiringResult", myId, x, y);
            //await Clients.User(opponentId).SendAsync("ReceiveFiringResult", opponentId, x, y);
        }

        public async Task SendFiring(string opponentId, byte x, char y)
        {


            //await Clients.All.SendAsync("ReceiveFiringResult", opponentId, x, y);
            //await Clients.Group(myId).SendAsync("ReceiveFiringResult", myId, x, y);
            //await Clients.User(opponentId).SendAsync("ReceiveFiringResult", opponentId, x, y);
        }

    }
}
