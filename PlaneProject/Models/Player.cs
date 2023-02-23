namespace PlaneProject.Models
{
    public class Player
    {        
        public Player(string connectionId, Guid id)
        { 
            this.Id = id;
            this.ConnectionId = connectionId;
        }

        public Player(string connectionId)
        {
            this.ConnectionId = connectionId;
        }

        public Guid Id { get; set; }

        public string ConnectionId { get; set; }
        //public string GameId { get; set; }
    }
}