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

        private int _occupancy;
        public int Occupancy
        {
            get => _occupancy;
            set
            {
                _occupancy = value;
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

        private List<CrewMember> _crewMembers = new();
        public List<CrewMember> CrewMembers
        {
            get => _crewMembers;
            set
            {
                _crewMembers = value;
                Touch();
            }
        }

        public Flight(string name, DateTime departureTime, DateTime arrivalTime, string from, string to,
                      double distance, int occupancy, Plane plane, List<CrewMember> crewMembers) : base()
        {
            Name = name;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            From = from;
            To = to;
            DistanceKm = distance;
            Occupancy = occupancy;
            Plane = plane;
            Plane.AddFlight();
            CrewMembers = crewMembers;
        }
    }
}
