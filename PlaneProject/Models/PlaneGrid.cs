namespace PlaneProject.Models
{
    public class PlaneGrid
    {
        private List<PlanePart> _placedPlanes = new List<PlanePart>();
        public bool AreAllPlanePlaced => _placedPlanes.Count == 6;//one plane atm 
        public bool AreAllPlaneAreDead => _placedPlanes.All(p => p.Status == PlanePartType.Dead);

        public PlaneGrid()
        {
        }

        public bool PlacePlanes(List<PlanePart> planes)
        {
            if (planes.Count != 6)
                return false;

            /*
            if (areLettersConsecutive(planes.OrderBy(p => p.Y).Skip(6).Take(3).Select(p => p.Y).ToArray()))
            {
                onePlane = planes.OrderBy(p => p.Y).Skip(6).Take(3).ToList();
                int i = 0;
                onePlane.ForEach(p =>
                {
                    if (i == 1) p.IsCabin = true;
                    p.Status = PlanePartType.Placed;
                    i++;
                }
                );
                _placedPlanes.Add(new Guid(), onePlane);
            }
            */
            //List<PlanePart> wings = new List<PlanePart>();
            //List<PlanePart> bodies = new List<PlanePart>();

            //wings = planes;
            //planes.GroupBy(p => p.X).Where(p => p.Count() >= 3)

            //TO DO: validate placed planes
            //TO DO: set the cabin

            for (int j = 0; j < planes.Count; j++)
            {
                PlanePart part = planes[j];
                if (j == 2) part.IsCabin = true;
                part.Status = PlanePartType.Placed;
                if (!_placedPlanes.Contains(part))
                    _placedPlanes.Add(part);
            }
            return true;
        }

        public List<PlanePart> CheckIfHit(PlanePart planePart)
        {
            PlanePart planePartFromPlaced = _placedPlanes.Where(p => p.X == planePart.X && p.Y == planePart.Y).FirstOrDefault();

            if (planePartFromPlaced.X == 0)
            {
                planePart.Status = PlanePartType.Air;
                return new List<PlanePart>() { planePart };
            }
            else
            {
                if (planePartFromPlaced.IsCabin)
                {
                    //TO DO: if there are more planes, do the logic for all of them correctly
                    _placedPlanes.ForEach(p => p.Status = PlanePartType.Dead);
                    return _placedPlanes;
                }
                else
                {
                    _placedPlanes.Where(p => p.X == planePart.X && p.Y == planePart.Y).ToList().ForEach(p => p.Status = PlanePartType.Hit);
                    planePart.Status = PlanePartType.Hit;
                    return new List<PlanePart>() { planePart };
                }
            }
        }

        /*
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
        */
    }
}
