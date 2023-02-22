namespace PlaneProject.Models
{
    public class Player
    {
        //private static byte _gridSize;
        public Player(bool isStarted)
        { 
            this.Id = Guid.NewGuid();
            //_gridSize = gridSize;
            this.IsStarted = isStarted;
            this.Planes = new List<PlanePart>(); //gridGenerator();
            //this.OpponentPlanes = new List<PlanePart>(); //new List<PlanePart>(this.OwnPlanes);
        }

        public Guid Id { get; set; }
        public string? OpponentId { get; set; }
        public bool IsStarted   { get; set; }

        public List<PlanePart> Planes { get; set; }

        //public List<PlanePart> OpponentPlanes { get; set; }
        /*
        private static List<PlanePart> gridGenerator()
        {
            List<PlanePart> newGrid = new List<PlanePart>();
            byte i = 1;

            for (byte x = 1; x <= _gridSize; x++)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (i <= _gridSize)
                    {
                        newGrid.Add(new PlanePart(x, c));
                        i++;
                    }
                    else
                    {
                        i = 1;
                        break;
                    }
                }
            } 
            return newGrid;
        }*/
    }
}