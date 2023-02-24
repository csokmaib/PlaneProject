namespace PlaneProject.Models
{
    public class PlaneGrid
    {
        //private readonly List<PlanePart> _planeGrid = new List<PlanePart>();
        private readonly List<PlanePart> _placedPlanes = new List<PlanePart>();
        public bool AreAllPlanePlaced => _placedPlanes.Count == 6;//one place atm 
        public bool AreAllPlaneAreDead => _placedPlanes.All(p => p.Status == PlanePartType.Dead);

        public PlaneGrid()
        {
            //_planeGrid = gridGenerator();
        }

        public bool PlacePlanes(List<PlanePart> planes)
        {
            if (planes.Count != 6)
                return false;

            //List<PlanePart> wings = new List<PlanePart>();
            //List<PlanePart> bodies = new List<PlanePart>();

            //wings = planes;
            //planes.GroupBy(p => p.X).Where(p => p.Count() >= 3)

            //TO DO: validate placed planes
            //TO DO: set the cabin
            planes.ForEach(p => p.Status = PlanePartType.Placed);
            foreach (PlanePart plane in planes)
            {
                if (!_placedPlanes.Contains(plane))
                    _placedPlanes.Add(plane);
            }
            return true;
        }

        private static bool areLettersConsecutive(char[] letters)
        {
            Array.Sort(letters);
            for (int i = 1; i < letters.Length; i++)
            {
                if (letters[i] - letters[i - 1] != 1)
                    return false;
            }
            return true;
        }

        private static bool areNumbersConsecutive(int[] numbers)
        {
            Array.Sort(numbers);
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] - numbers[i - 1] != 1)
                    return false;
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
