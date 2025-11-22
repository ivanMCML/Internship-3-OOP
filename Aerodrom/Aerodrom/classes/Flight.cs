using Aerodrom.enums;

namespace Aerodrom.classes
{
    public class Flight : BaseEntity
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Touch();
            }
        }

        private DateTime _departureTime;
        public DateTime DepartureTime
        {
            get => _departureTime;
            set
            {
                _departureTime = value;
                Touch();
            }
        }

        private DateTime _arrivalTime;
        public DateTime ArrivalTime
        {
            get => _arrivalTime;
            set
            {
                _arrivalTime = value;
                Touch();
            }
        }

        private string _from;
        public string From
        {
            get => _from;
            set
            {
                _from = value;
                Touch();
            }
        }

        private string _to;
        public string To
        {
            get => _to;
            set
            {
                _to = value;
                Touch();
            }
        }

        private double _distanceKm;
        public double DistanceKm
        {
            get => _distanceKm;
            set
            {
                _distanceKm = value;
                Touch();
            }
        }

        private Dictionary<Category, int> _categoryOccupancy = new();
        public Dictionary<Category, int> CategoryOccupancy
        {
            get => _categoryOccupancy;
            set
            {
                _categoryOccupancy = value;
                Touch();
            }
        }

        private Plane _plane;
        public Plane Plane
        {
            get => _plane;
            set
            {
                _plane = value;
                Touch();
            }
        }

        private Crew _crew;
        public Crew Crew
        {
            get => _crew;
            set
            {
                _crew = value;
                Touch();
            }
        }

        public Flight(string name, DateTime departureTime, DateTime arrivalTime, string from, string to,
                      double distance, Dictionary<Category, int> categoryOccupancy, Plane plane, Crew crew) : base()
        {
            Name = name;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            From = from;
            To = to;
            DistanceKm = distance;
            CategoryOccupancy = categoryOccupancy;
            Plane = plane;
            Plane.AddFlight();
            Crew = crew;
        }

        public void PrintFlightForPassenger()
        {
            Console.WriteLine($"{Id} - {Name} - {DepartureTime.Date} - {ArrivalTime.Date} - {DistanceKm} - {GetTravelTime()}");
        }

        public Dictionary<Category, int> GetFreeSeatsPerCategory()
        {
            var result = new Dictionary<Category, int>();

            foreach (var category in Plane.CategoryCapacities)
            {
                int max = category.Value;
                int occupied = CategoryOccupancy.ContainsKey(category.Key) ? CategoryOccupancy[category.Key] : 0;

                int free = max - occupied;
                result[category.Key] = free;
            }

            return result;
        }

        public int GetTotalFreeSeats()
        {
            return GetFreeSeatsPerCategory().Values.Sum();
        }

        public TimeSpan GetTravelTime()
        {
            return ArrivalTime - DepartureTime;
        }
    }
}
