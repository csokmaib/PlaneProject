using PlaneProject.Models;

namespace PlaneProject.Services
{
    public class GameService : IGameService
    {
        private readonly Queue<Player> _waitingPlayers;
        private readonly List<Player> _playersInGame;
        private readonly List<Game> _gameList;

        public GameService()
        {
            _gameList = new List<Game>();
            _waitingPlayers = new Queue<Player>();
            _playersInGame = new List<Player>();
        }

        public void RegisterPlayer(string connectionId, Guid playerId)
        {
            Player player = new Player(connectionId, playerId);
            _playersInGame.Add(player);                
        }

        public (string ConnectionId1, string ConnectionId2, Guid GameId) AddWaitingPlayerIntoQueue(string connectionId)
        {
            Player player2 = _playersInGame.FirstOrDefault(p => p.ConnectionId.Equals(connectionId));
            if (player2 == null) return (null, null, Guid.Empty);

            if (_waitingPlayers.Count > 0)
            {
                var player1 = _waitingPlayers.Dequeue();
                var newGame = new Game(player1, player2);
                _gameList.Add(newGame);
                return (player1.ConnectionId, player2.ConnectionId, newGame.Id);
            }
            else
            {
                if (_waitingPlayers.Any(p => p == player2))
                    return (null, null, Guid.Empty);
                _waitingPlayers.Enqueue(player2);
            }
            return (null, null, Guid.Empty);
        }

        public bool SetPlanes(List<PlanePart> planes, string gameId, string connectionId)
        {
            if (Guid.TryParse(gameId, out var gameGuid))
            {
                if (!_gameList.Any(g => g.Id.Equals(gameGuid)))  return false;

                var game = _gameList.Single(g => g.Id.Equals(gameGuid));

                if (game.PlaceThePlanes(planes, connectionId))
                {
                    //TO DO: if the all planes are placed, get to the next turn

                    return true;
                }
            }
            return false;
        }





    }
}
