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
                new Plane("ciro", 1980, 0, 80, new List<enums.Category>{enums.Category.standard, enums.Category.business })
            };

            var flights = new List<Flight>
            {
                new Flight("Prvi Let", new DateTime(2025, 12, 12, 9, 10, 0),
                new DateTime(2025, 12, 12, 11, 54, 00), "Split", "Zagreb", 500, 20,
                planes[1], new List<CrewMember>{crew[0], crew[1]})
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
                        flightMenu();
                        break;
                    case 3:
                        planeMenu();
                        break;
                    case 4:
                        crewMenu();
                        break;
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
                        register(flights, passengers);
                    else if (answer == 2) 
                        login(flights, passengers);
                    else return;
                }
            }
        }

        public static void register(List<Flight> flights, List<Passenger> passengers)
        {
            Console.WriteLine("\nREGISTRACIJA");
            string? name;
            do
            {
                Console.Write("Ime: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            string? surname;

            do
            {
                Console.Write("Prezime: ");
                surname = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(surname));

            char genderC = ' ';
            do
            {
                Console.Write("Spol: ");
                name = Console.ReadLine();
            } while (genderC != 'M' && genderC != 'F');

            Gender gender;
            if (genderC == 'M')
                gender = Gender.M;
            else gender = Gender.F;

                int year;
            while (true) {
                Console.Write("Godina rođenja: ");
                if (int.TryParse(Console.ReadLine(), out year) && year <= DateTime.Now.Year)
                    break;
            }
            
            string? email;
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (passengers.Any(p => p.UserName == email))
                {
                    Console.WriteLine("\nEmail već postoji");
                    return;
                }
            } while (string.IsNullOrWhiteSpace(email));

            string? password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(password));

            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da se zelis registrirati?(da/ne)");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");
            if (check == "da")
            {
                var p = new Passenger(email, password, new List<Flight> { }, name, surname, year, gender);
                passengers.Add(p);
                Console.WriteLine("\nRegistracija uspjesna");
                loggedMenu(flights, passengers, p);
                return;
            }
            else
            {
                Console.WriteLine("\nRegistracija odbacena");
                return;
            }
        }

        public static void login(List<Flight> flights, List<Passenger> passengers)
        {
            Console.WriteLine("\nPrijava");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Email: "); 
                var email = Console.ReadLine();
                Console.Write("Lozinka: "); 
                var pw = Console.ReadLine();
                var p = passengers.FirstOrDefault(x => x.UserName == email && x.Password == pw);
                if (p != null) 
                { 
                    Passenger logged = p;
                    Console.WriteLine("\nPrijavljen si");
                    loggedMenu(flights, passengers, logged);
                    return; 
                }
                Console.WriteLine("\nNeispravan unos, pokusaj ponovno.");
            }
            Console.WriteLine("\nPrevise neispravnih pokusaja");
        }

        public static void loggedMenu(List<Flight> flights, List<Passenger> passengers, Passenger logged)
        {
            while (true)
            {
                Console.WriteLine("\n1 - Prikaz svih letova");
                Console.WriteLine("2 - Odabir leta");
                Console.WriteLine("3 - Pretrazivanje letova");
                Console.WriteLine("4 - Otkazivanje leta");
                Console.WriteLine("5 - Povratak");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 6)
                {
                    switch (answer)
                    {
                        case 1:
                            var userFlights = logged.Flights;

                            if (!userFlights.Any())
                            {
                                Console.WriteLine("\nNemas ni jedan rezervirani let.");
                                break;
                            }
                            foreach (Flight f in logged.Flights)
                                f.PrintFlightForPassenger();
                            break;
                        case 2:
                            chooseFlight(flights, logged);
                            break;
                        case 3:
                            searchFlights(flights);
                            break;
                        case 4:
                            cancelFlight(flights, logged);
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }

        public static void chooseFlight(List<Flight> flights, Passenger logged)
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

        public static void searchFlights(List<Flight> flights)
        {
            while (true)
            {
                Console.WriteLine("1 - Po ID-u");
                Console.WriteLine("2 - Po nazivu");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 3)
                {
                    if (answer == 1)
                        searchFlightById(flights);
                    else if (answer == 2)
                        searchFlightByName(flights);
                    return;
                }
            }
        }

        public static void searchFlightById(List<Flight> flights)
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

        public static void searchFlightByName(List<Flight> flights)
        {
            Console.Write("Unesi naziv leta: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\nNeispravan unos.");
                return;
            }

            var flight = flights.Where(f => f.Name == name).ToList();

            if (!flight.Any())
            {
                Console.WriteLine("\nLet nije pronadjen.");
                return;
            }

            foreach (var f in flight)
            {
                f.PrintFlightForPassenger();
            }
        }

        public static void cancelFlight(List<Flight> flights, Passenger logged)
        {
            var userFlights = logged.Flights;

            if (!userFlights.Any())
            {
                Console.WriteLine("\nNemas ni jedan rezervirani let.");
                return;
            }

            for (int i = 0; i < userFlights.Count; i++)
            {
                Console.Write($"#{i + 1} ");
                userFlights[i].PrintFlightForPassenger();
            }

            Console.Write($"\nOtkazi let (1-{userFlights.Count}): ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > userFlights.Count)
            {
                Console.WriteLine("\nNeispravan odabir.");
                return;
            }
            Flight selectedFlight = userFlights[choice - 1];

            if ((selectedFlight.DepartureTime - DateTime.Now).TotalHours < 24)
            {
                Console.WriteLine("\nNije moguće otkazati let jer kreće za 24h ili manje.");
                return;
            }

            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da zelis otkazati let? (da/ne) ");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");

            if (check == "da")
            {
                logged.Flights.Remove(selectedFlight);
                Console.WriteLine("\nLet uspjesno otkazan.");
            }
            else Console.WriteLine("\nOtkazivanje prekinuto.");

        }

    }
}
