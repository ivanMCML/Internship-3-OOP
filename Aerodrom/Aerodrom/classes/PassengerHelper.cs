namespace Aerodrom.classes
{
    public static class PassengerHelper
    {
        public static void Register(List<Flight> flights, List<Passenger> passengers)
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
                genderC = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            } while (genderC != 'M' && genderC != 'F');

            Gender gender;
            if (genderC == 'M')
                gender = Gender.M;
            else gender = Gender.F;

            Console.WriteLine("Datum rodjenja");
            DateOnly dateOfBirth = Helpers.GetDateOnly();
            
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
                var p = new Passenger(email, password, new List<Flight> { }, name, surname, dateOfBirth, gender);
                passengers.Add(p);
                Console.WriteLine("\nRegistracija uspjesna");
                LoggedMenu(flights, passengers, p);
                return;
            }
            else
            {
                Console.WriteLine("\nRegistracija odbacena");
                return;
            }
        }

        public static void Login(List<Flight> flights, List<Passenger> passengers)
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
                    LoggedMenu(flights, passengers, logged);
                    return;
                }
                Console.WriteLine("\nNeispravan unos, pokusaj ponovno.");
            }
            Console.WriteLine("\nPrevise neispravnih pokusaja");
        }

        public static void LoggedMenu(List<Flight> flights, List<Passenger> passengers, Passenger logged)
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
                            FlightHelper.DisplayFlights(logged.Flights);
                            break;
                        case 2:
                            FlightHelper.BookFlight(flights, logged);
                            break;
                        case 3:
                            FlightHelper.SearchFlights(flights);
                            break;
                        case 4:
                            CancelFlight(flights, logged);
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }

        public static void CancelFlight(List<Flight> flights, Passenger logged)
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
