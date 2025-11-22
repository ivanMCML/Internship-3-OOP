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

        private Dictionary<Category, int> _categoryCapacities = new();
        public Dictionary<Category, int> CategoryCapacities
        {
            get => _categoryCapacities;
            set 
            { 
                _categoryCapacities = value; 
                Touch(); 
            }
        }

        public Plane(string name, int productionYear, int numberOfFlights, Dictionary<Category, int> categoryCapaccities)
            : base()
        {
            Name = name;
            ProductionYear = productionYear;
            NumberOfFlights = 0;
            CategoryCapacities = categoryCapaccities;
        }

        public void AddFlight()
        {
            NumberOfFlights++;
            Touch();
        }

        public void printPlane()
        {
            Console.WriteLine($"{Id} - {Name} - {ProductionYear} - {NumberOfFlights}");
        }
    }
}
