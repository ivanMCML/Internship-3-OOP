using Aerodrom.classes;
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

        }

    }
}
