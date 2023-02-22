using Microsoft.AspNetCore.SignalR;

namespace PlaneProject.Services
{
    public class CommunicationHub: Hub
    {
        private IGameService _gameService;
        public CommunicationHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task SendFiring(string opponentId, byte x, char y)
        {
            await Clients.All.SendAsync("ReceiveFiringResult", opponentId, x, y);
            //await Clients.Group(myId).SendAsync("ReceiveFiringResult", myId, x, y);
            //await Clients.User(opponentId).SendAsync("ReceiveFiringResult", opponentId, x, y);
        }

        public async Task setOnePlane(byte x, char y)
        {
            //await Clients.All.SendAsync("ReceiveFiringResult", , x, y);
            //await Clients.Group(myId).SendAsync("ReceiveFiringResult", myId, x, y);
            //await Clients.User(opponentId).SendAsync("ReceiveFiringResult", opponentId, x, y);
        }
    }
}
