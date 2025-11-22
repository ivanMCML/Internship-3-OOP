using Aerodrom.classes;
using Aerodrom.enums;
using System.ComponentModel;

namespace Aerodrom
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var crew = new List<CrewMember>
            {
                new CrewMember(enums.CrewMemberType.Pilot, "Josip", "Pavic", 1990, Gender.M),
                new CrewMember(enums.CrewMemberType.Copilot, "Ana", "Letica", 1994, Gender.F),
        
            };

            var planes = new List<Plane>
            {
                new Plane("ciro", 1980, 0, new Dictionary<Category, int>{ { enums.Category.standard, 80}, { enums.Category.business, 20 } })
            };

            var flights = new List<Flight>
            {
                new Flight("Prvi Let", new DateTime(2025, 12, 12, 9, 10, 0),
                new DateTime(2025, 12, 12, 11, 54, 00), "Split", "Zagreb", 500, new Dictionary<Category, int>{{ enums.Category.standard, 0}, { enums.Category.business, 0 } },
                planes[0], new List<CrewMember>{crew[0], crew[1]})
            };

            var passengers = new List<Passenger>
            {
                new Passenger("ante04@gmail.com", "to1999", new List<Flight>{flights[0]},
                "Ante", "Delic", 1999, Gender.M)
            };

            while (true)
            {
                int choice = mainMenu();

                switch(choice)
                {
                    case 1:
                        passengerMenu(flights, passengers);
                        break;
                    case 2:
                        flightMenu(flights, planes, crew);
                        break;
                    //case 3:
                    //    planeMenu();
                    //    break;
                    //case 4:
                    //    crewMenu();
                    //    break;
                    case 5:
                        return;
                }
            }
        }

        public static int mainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAPLIKACIJA ZA UPRAVLJANJE AERODROMOM");
                Console.WriteLine("1 - Putnici");
                Console.WriteLine("2 - Letovi");
                Console.WriteLine("3 - Avioni");
                Console.WriteLine("4 - Posada");
                Console.WriteLine("5 - Izlaz");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 6)
                    return answer;
                else return 0;
            }
        }

        public static void passengerMenu(List<Flight> flights, List<Passenger> passengers)
        {
            while (true)
            {
                Console.WriteLine("\nPUTNICI");
                Console.WriteLine("1 - Registracija");
                Console.WriteLine("2 - Prijava");
                Console.WriteLine("3 - Povratak");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 4)
                {
                    if (answer == 1) 
                        PassengerHelper.Register(flights, passengers);
                    else if (answer == 2) 
                        PassengerHelper.Login(flights, passengers);
                    else return;
                }
            }
        }



        public static void flightMenu(List<Flight> flights, List<Plane> planes, List<CrewMember> crew)
        {

            while (true)
            {
                Console.WriteLine("\nLETOVI");
                Console.WriteLine("1 - Prikazi letove");
                Console.WriteLine("2 - Dodaj let");
                Console.WriteLine("3 - Pretrazi letove");
                Console.WriteLine("4 - Uredi let");
                Console.WriteLine("5 - Izbrisi let");
                Console.WriteLine("6 - Povratak");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 7)
                {
                    switch (answer)
                    {
                        case 1:
                            FlightHelper.DisplayFlights(flights);
                            break;
                        case 2:
                            FlightHelper.AddFlight(flights, planes, crew);
                            break;
                        case 3:
                            FlightHelper.SearchFlights(flights);
                            break;
                        case 4:
                            //crewMenu();
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }

    }
}
