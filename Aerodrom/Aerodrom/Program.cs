using Aerodrom.classes;
using Aerodrom.enums;
using System.ComponentModel;

namespace Aerodrom
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var crewMembers = new List<CrewMember>
            {
                new CrewMember(CrewMemberType.Pilot, "Josip", "Pavic", new DateOnly(1990, 5, 12), Gender.M),
                new CrewMember(CrewMemberType.Copilot, "Ana", "Letica", new DateOnly(1994, 8, 23), Gender.F),
                new CrewMember(CrewMemberType.Stewardess, "Ivana", "Horvat", new DateOnly(1995, 3, 10), Gender.F),
                new CrewMember(CrewMemberType.Stewardess, "Martina", "Kovac", new DateOnly(1992, 7, 5), Gender.F),
                new CrewMember(CrewMemberType.Pilot, "Marko", "Radic", new DateOnly(1988, 11, 30), Gender.M),
                new CrewMember(CrewMemberType.Copilot, "Luka", "Babic", new DateOnly(1991, 4, 18), Gender.M),
                new CrewMember(CrewMemberType.Stewardess, "Petra", "Matic", new DateOnly(1993, 12, 2), Gender.F),
                new CrewMember(CrewMemberType.Stewardess, "Katarina", "Novak", new DateOnly(1996, 1, 20), Gender.F),
                new CrewMember(CrewMemberType.Pilot, "Tomislav", "Saric", new DateOnly(1987, 9, 15), Gender.M),
                new CrewMember(CrewMemberType.Copilot, "Ivica", "Peric", new DateOnly(1990, 6, 8), Gender.M)
            };

            var crews = new List<Crew>
            {
                new Crew("Posada 1", crewMembers[0], crewMembers[1], crewMembers[2], crewMembers[3]),
                new Crew("Posada 2", crewMembers[4], crewMembers[5], crewMembers[6], crewMembers[7])
            };
            var planes = new List<Plane>
            {
                new Plane("Avion 1", 2010, 0, new Dictionary<Category, int> { { Category.standard, 120 }, { Category.business, 20 }, { Category.VIP, 5 } }),
                new Plane("Avion 2", 2012, 0, new Dictionary<Category, int> { { Category.standard, 150 }, { Category.business, 25 }, { Category.VIP, 10 } }),
                new Plane("Avion 3", 2015, 0, new Dictionary<Category, int> { { Category.standard, 90 }, { Category.business, 15 }, { Category.VIP, 5 } }),
                new Plane("Avion 4", 2018, 0, new Dictionary<Category, int> { { Category.standard, 200 }, { Category.business, 40 }, { Category.VIP, 15 } }),
                new Plane("Avion 5", 2020, 0, new Dictionary<Category, int> { { Category.standard, 220 }, { Category.business, 50 }, { Category.VIP, 20 } })
            };

            var flights = new List<Flight>
            {
                new Flight("Split-Zagreb", new DateTime(2025, 12, 12, 9, 0, 0), new DateTime(2025, 12, 12, 10, 15, 0),
                    "Split", "Zagreb", 500, new Dictionary<Category, int> { { Category.standard, 0 }, { Category.business, 0 }, { Category.VIP, 0 } },
                    planes[0], crews[0]),
                new Flight("Zagreb-Dubrovnik", new DateTime(2025, 12, 13, 14, 0, 0), new DateTime(2025, 12, 13, 15, 45, 0),
                    "Zagreb", "Dubrovnik", 600, new Dictionary<Category, int> { { Category.standard, 0 }, { Category.business, 0 }, { Category.VIP, 0 } },
                    planes[1], crews[1]),
                new Flight("Dubrovnik-Split", new DateTime(2025, 12, 14, 8, 30, 0), new DateTime(2025, 12, 14, 9, 45, 0),
                    "Dubrovnik", "Split", 250, new Dictionary<Category, int> { { Category.standard, 0 }, { Category.business, 0 }, { Category.VIP, 0 } },
                    planes[0], crews[0]),
                new Flight("Zagreb-Rijeka", new DateTime(2025, 12, 15, 12, 0, 0), new DateTime(2025, 12, 15, 13, 30, 0),
                    "Zagreb", "Rijeka", 300, new Dictionary<Category, int> { { Category.standard, 0 }, { Category.business, 0 }, { Category.VIP, 0 } },
                    planes[2], crews[1]),
                new Flight("Split-Dubrovnik", new DateTime(2025, 12, 16, 16, 0, 0), new DateTime(2025, 12, 16, 17, 15, 0),
                    "Split", "Dubrovnik", 250, new Dictionary<Category, int> { { Category.standard, 0 }, { Category.business, 0 }, { Category.VIP, 0 } },
                    planes[3], crews[0])
            };

            var passengers = new List<Passenger>
            {
                new Passenger("marko@gmail.com", "loz", new List<Flight>{ flights[0], flights[1] },
                    "Marko", "Livaja", new DateOnly(1995, 4, 12), Gender.M),
                new Passenger("iva@gmail.com", "loz", new List<Flight>{ flights[2] }, "Iva",
                    "Knezevic", new DateOnly(1998, 9, 23), Gender.F),
                new Passenger( "petar@gmail.com", "loz", new List<Flight>(), "Petar", "Juric",
                    new DateOnly(2000, 1, 5), Gender.M)
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
                        flightMenu(flights, planes, crewMembers, crews, passengers);
                        break;
                    case 3:
                        planeMenu(planes, flights);
                        break;
                    case 4:
                        crewMenu(crewMembers, crews);
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
                        PassengerHelper.Register(flights, passengers);
                    else if (answer == 2) 
                        PassengerHelper.Login(flights, passengers);
                    else return;
                }
            }
        }



        public static void flightMenu(List<Flight> flights, List<Plane> planes, List<CrewMember> crewMembers, List<Crew> crews, List<Passenger> passengers)
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
                            FlightHelper.AddFlight(flights, planes, crewMembers, crews);
                            break;
                        case 3:
                            FlightHelper.SearchFlights(flights);
                            break;
                        case 4:
                            FlightHelper.EditFlight(flights, crews);
                            break;
                        case 5:
                            FlightHelper.DeleteFlight(flights, passengers);
                            break;
                        case 6:
                            return;
                    }
                }
            }
        }


        public static void planeMenu(List<Plane> planes, List<Flight> flights)
        {

            while (true)
            {
                Console.WriteLine("\nLETOVI");
                Console.WriteLine("1 - Prikazi avione");
                Console.WriteLine("2 - Dodaj avion");
                Console.WriteLine("3 - Pretrazi avione");
                Console.WriteLine("4 - Izbrisi avion");
                Console.WriteLine("5 - Povratak");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 6)
                {
                    switch (answer)
                    {
                        case 1:
                            PlaneHelper.DisplayPlanes(planes);
                            break;
                        case 2:
                            PlaneHelper.AddPlane(planes);
                            break;
                        case 3:
                            PlaneHelper.SearchPlanes(planes);
                            break;
                        case 4:
                            PlaneHelper.DeletePlane(planes, flights);
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }

        public static void crewMenu(List<CrewMember> crewMembers, List<Crew> crews)
        {

            while (true)
            {
                Console.WriteLine("\nLETOVI");
                Console.WriteLine("1 - Prikazi posade");
                Console.WriteLine("2 - Kreiraj posadu");
                Console.WriteLine("3 - Dodaj osobu");
                Console.WriteLine("4 - Povratak");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 5)
                {
                    switch (answer)
                    {
                        case 1:
                            CrewHelper.DisplayCrews(crews);
                            break;
                        case 2:
                            CrewHelper.CreateCrew(crewMembers, crews);
                            break;
                        case 3:
                            CrewHelper.AddCrewMember(crewMembers);
                            break;
                        case 4:
                            return;
                    }
                }
            }
        }

    }
}
