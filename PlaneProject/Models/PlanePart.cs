namespace PlaneProject.Models
{
    public class PlanePart
    {
        public PlanePart(byte x, char y)
        { 
            this.X = x;
            this.Y = y;
        }

        public byte X { get; set; }
        public char Y { get; set; }
        public bool IsCabin { get; set; }
        public PlanePartType Status { get; set; } = PlanePartType.Air;

        public override string ToString()
        {
            return this.X + this.Y.ToString().ToUpper();
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
