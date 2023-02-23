namespace PlaneProject.Models
{

    public struct PlanePart
    {
        public PlanePart(int x, char y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public char Y { get; set; }
        public bool IsCabin { get; set; } = false;
        public PlanePartType Status { get; set; } = PlanePartType.Air;
    }

    public enum PlanePartType
    { 
        Placed,
        Air,
        Hit,
        Dead
    }
}
