namespace PlaneProject.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        private readonly Player _player1;
        private readonly Player _player2;

        private readonly PlaneGrid _player1Grid;
        private readonly PlaneGrid _player2Grid;
        public bool IsPlayer1Turn { get; set; }
        public bool AllPlaneArePlaced => _player1Grid.AreAllPlanePlaced && _player2Grid.AreAllPlanePlaced;

        public Game(Player player1, Player player2)
        {
            Id = Guid.NewGuid();
            _player1 = player1;
            _player2 = player2;
            _player1Grid = new PlaneGrid();
            _player2Grid = new PlaneGrid();
            IsPlayer1Turn = (new Random()).Next(100) < 50;
        }

        public bool PlaceThePlanes(List<PlanePart> planeParts, string connectionId)
        {
            if (_player1.ConnectionId.Equals(connectionId))
                return _player1Grid.PlacePlanes(planeParts);
            if (_player2.ConnectionId.Equals(connectionId))
                return _player2Grid.PlacePlanes(planeParts);
            return false;
        }

        public (Player Player1, Player Player2) GetGamePlayers()
        {
            return (_player1, _player2);
        }
    }
}
