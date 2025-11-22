using Aerodrom.enums;

namespace Aerodrom.classes
{
    public static class FlightHelper
    {
        public static void BookFlight(List<Flight> flights, Passenger logged)
        {
            var availableFlights = flights.Where(f => f.GetTotalFreeSeats() > 0).ToList();

            if (!availableFlights.Any())
            {
                Console.WriteLine("\nNema dostupnih letova.");
                return;
            }

            Console.WriteLine("\nDostupni letovi:");
            for (int i = 0; i < availableFlights.Count; i++)
            {
                Console.Write($"#{i + 1} ");
                availableFlights[i].PrintFlightForPassenger();
            }

            Console.Write($"Odaberite let (1 - {availableFlights.Count}): ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > availableFlights.Count)
            {
                Console.WriteLine("\nNeispravan odabir leta.");
                return;
            }

            Flight selectedFlight = availableFlights[choice - 1];


            var freeSeats = selectedFlight.GetFreeSeatsPerCategory();
            var categories = freeSeats.Where(c => c.Value > 0).ToList();

            if (!categories.Any())
            {
                Console.WriteLine("\nNema slobodnih mjesta ni u jednoj kategoriji.");
                return;
            }

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"#{i + 1} {categories[i].Key} slobodnih mijesta: {categories[i].Value}");
            }

            Console.Write("Odaberite kategoriju: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryChoice) || categoryChoice < 1 || categoryChoice > categories.Count)
            {
                Console.WriteLine("\nNeispravan odabir kategorije.");
                return;
            }

            Category chosenCategory = categories[categoryChoice - 1].Key;

            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da se zelis registrirati?(da/ne)");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");
            if (check == "da")
            {
                selectedFlight.CategoryOccupancy[chosenCategory]++;
                logged.Flights.Add(selectedFlight);
                Console.WriteLine("\nLet uspjesno rezerviran.");
            }
            else Console.WriteLine("\nRezervacija odbacena.");
        }

        public static void SearchFlights(List<Flight> flights)
        {
            while (true)
            {
                Console.WriteLine("1 - Po ID-u");
                Console.WriteLine("2 - Po nazivu");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 3)
                {
                    if (answer == 1)
                        SearchFlightById(flights);
                    else if (answer == 2)
                        SearchFlightByName(flights);
                    return;
                }
            }
        }

        public static void SearchFlightById(List<Flight> flights)
        {
            Console.Write("Unesi ID leta: ");
            string id = Console.ReadLine();

            if (!Guid.TryParse(id, out Guid searchId))
            {
                Console.WriteLine("\nNeispravan format ID-a.");
                return;
            }

            Flight? flight = flights.FirstOrDefault(f => f.Id == searchId);

            if (flight != null)
                flight.PrintFlightForPassenger();
            else
                Console.WriteLine("\nLet nije pronadjen.");
        }

        public static void SearchFlightByName(List<Flight> flights)
        {
            Console.Write("Unesi naziv leta: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\nNeispravan unos.");
                return;
            }

            var flight = flights.Where(f => f.Name == name).ToList();

            DisplayFlights(flight);
        }

        public static void DisplayFlights(List<Flight> flights)
        {
            if (!flights.Any())
            {
                Console.WriteLine("\nLet nije pronadjen.");
                return;
            }

            foreach (var flight in flights)
                flight.PrintFlightForPassenger();
        }

        public static void AddFlight(List<Flight> flights, List<Plane> planes, List<CrewMember> crew)
        {
            string? name;

            do
            {
                Console.Write("Naziv: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            string? from;
            do
            {
                Console.Write("Mjesto polaska: ");
                from = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(from));

            string? to;
            do
            {
                Console.Write("Mjesto polaska: ");
                to = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(to));

            double distance;
            while (true)
            {
                Console.Write("Udaljenost putovanja(km): ");
                if (double.TryParse(Console.ReadLine(), out distance) && distance > 0)
                    break;
            }

            Console.WriteLine("Vrijeme polaska:");
            var depatureTime = Helpers.GetDateTime();
            
            Console.WriteLine("Vrijeme dolaska:");
            var arrivalTime = Helpers.GetDateTime();

            Plane airplane = PlaneHelper.ChoosePlane(planes);

            var newCrew = CrewHelper.ChooseCrewMembers(crew);
            if(newCrew.Count() < 4)
            {
                Console.WriteLine("Nema dovoljno članova posade");
                return;
            }

            var occupacy = new Dictionary<Category, int>();
            foreach (var c in airplane.CategoryCapacities)
                occupacy.Add(c.Key, 0);


            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da kreirati let?(da/ne)");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");
            if (check == "da")
            {
                flights.Add(new Flight(name, depatureTime, arrivalTime, from, to, distance, occupacy, airplane, newCrew));
            }
            else
            {
                Console.WriteLine("\nLet odbacen");
                return;
            }
        }


    }
}
