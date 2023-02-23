namespace PlaneProject.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        private readonly Player _player1;
        private readonly Player _player2;

        private readonly PlaneGrid _player1Grid;
        private readonly PlaneGrid _player2Grid;


        public Game(Player player1, Player player2)
        {
            Id = Guid.NewGuid();
            _player1 = player1;
            _player2 = player2;
            IsPlayer1Started = (new Random()).Next(100) < 50;
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public bool IsPlayer1Started { get; set; }

        public bool PlaceThePlanes(List<PlanePart> planeParts, string connectionId)
        {

            if (_player1.ConnectionId.Equals(connectionId))
                return _player1Grid.PlacePlanes(planeParts);

            if (_player2.ConnectionId.Equals(connectionId))
                return _player2Grid.PlacePlanes(planeParts);

            return false;
        }
    }
}
