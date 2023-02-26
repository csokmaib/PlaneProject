namespace PlaneProject.Models
{
    public class  PlanePart : IEquatable<PlanePart>
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

        public bool Equals(PlanePart other)
        {
            return X == other.X && Y == other.Y && IsCabin == other.IsCabin && Status == other.Status;
        }
    }

    public enum PlanePartType
    { 
        Placed,
        Air,
        Hit,
        Dead
    }
}
