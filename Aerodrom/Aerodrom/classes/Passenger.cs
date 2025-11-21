namespace Aerodrom.classes
{
    public class Passenger : People
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                Touch();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                Touch();
            }
        }

        private List<Flight> _flights = new();
        public List<Flight> Flights
        {
            get => _flights;
            set
            {
                _flights = value;
                Touch();
            }
        }

        public Passenger(string userName, string password, List<Flight> flights, string firstName, string lastName, int yearOfBirth, Gender gender)
            : base(firstName, lastName, yearOfBirth, gender)
        {
            UserName = userName;
            Password = password;
            Flights = flights;
        }
    }
}
