using Aerodrom.enums;

namespace Aerodrom.classes
{
    public class Plane : BaseEntity
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

        private int _productionYear;
        public int ProductionYear
        {
            get => _productionYear;
            set
            {
                _productionYear = value;
                Touch();
            }
        }

        private int _numberOfFlights;
        public int NumberOfFlights
        {
            get => _numberOfFlights;
            set
            {
                _numberOfFlights = value;
                Touch();
            }
        }

        private int _capacity;
        public int Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                Touch();
            }
        }

        private List<Category> _categories = new();
        public List<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                Touch();
            }
        }

        public Plane(string name, int productionYear, int numberOfFlights, int capacity, List<Category> categories)
            : base()
        {
            Name = name;
            ProductionYear = productionYear;
            NumberOfFlights = 0;
            Capacity = capacity;
            Categories = categories;
        }

        public void AddFlight()
        {
            NumberOfFlights++;
            Touch()
        }
    }
}
