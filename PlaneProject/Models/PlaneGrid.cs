namespace PlaneProject.Models
{
    public class PlaneGrid
    {
        private readonly List<PlanePart> _planeGrid = new List<PlanePart>();

        public PlaneGrid()
        {
            _planeGrid = gridGenerator();
        }

        public bool PlacePlanes(List<PlanePart> planes)
        {
            if (planes.Count != 18)
                return false;

            List<PlanePart> wings = new List<PlanePart>();
            List<PlanePart> bodies = new List<PlanePart>();

            wings = planes;   
                


            return true;
        }

        private static List<PlanePart> gridGenerator()
        {
            List<PlanePart> newGrid = new List<PlanePart>();
            for (byte x = 10; x >= 1; x--)
            {
                for (char l = 'A'; l <= 'J'; l++)
                {
                    //newGrid.Add(new PlanePart(x, l));
                }
            }

            /*
            for (byte x = 1; x <= 10; x++)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (i <= 10)
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
            }*/
            return newGrid;
        }
    }
}
