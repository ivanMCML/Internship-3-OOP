using Aerodrom.enums;

namespace Aerodrom.classes
{
    public static class PlaneHelper
    {
        public static Plane ChoosePlane(List<Plane> planes)
        {
            for (int i = 0; i < planes.Count(); i++)
            {
                Console.Write($"#{i + 1} ");
                planes[i].printPlane();
            }

            while (true)
            {
                Console.Write($"Odaberite avion (1 - {planes.Count()}): ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > planes.Count())
                    Console.WriteLine("\nNeispravan odabir aviona.");
                else return planes[choice - 1];
            }    
        }

        public static void DisplayPlanes(List<Plane> planes)
        {
            if (!planes.Any())
            {
                Console.WriteLine("\nAvion nije pronadjen.");
                return;
            }

            foreach (var plane in planes)
                plane.printPlane();
        }

        public static void AddPlane(List<Plane> planes)
        {
            string? name;

            do
            {
                Console.Write("Ime: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            int year;
            while (true)
            {
                Console.Write("Godina proizvodnje: ");
                if (int.TryParse(Console.ReadLine(), out year))
                    break;
            }

            var seatsPerCategory = new Dictionary<Category, int>();

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                string answer;
                do
                {
                    Console.Write($"Je li kategorija {category} dostupna? (da/ne): ");
                    answer = Console.ReadLine().ToLower().Trim();
                } while (answer != "da" && answer != "ne");

                if (answer == "da")
                {
                    int seats;
                    while (true)
                    {
                        Console.Write($"Broj mjesta za {category}: ");
                        if (int.TryParse(Console.ReadLine(), out seats) && seats > 0)
                            break;

                        Console.WriteLine("Neispravan unos, pokusaj ponovno.");
                    }

                    seatsPerCategory.Add(category, seats);
                }
            }

            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da zelis dodati avion?(da/ne)");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");
            if (check == "da")
                planes.Add(new Plane(name, year, 0, seatsPerCategory));
            else Console.WriteLine("\nAvion odbacen");
        }


        public static void SearchPlanes(List<Plane> planes)
        {
            while (true)
            {
                Console.WriteLine("1 - Po ID-u");
                Console.WriteLine("2 - Po nazivu");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int answer) && answer > 0 && answer < 3)
                {
                    if (answer == 1)
                        SearchPlaneById(planes);
                    else if (answer == 2)
                        SearchPlaneByName(planes);
                    return;
                }
            }
        }

        public static void SearchPlaneById(List<Plane> planes)
        {
            Console.Write("Unesi ID aviona: ");
            string id = Console.ReadLine();

            if (!Guid.TryParse(id, out Guid searchId))
            {
                Console.WriteLine("\nNeispravan format ID-a.");
                return;
            }

            Plane? plane = planes.FirstOrDefault(p => p.Id == searchId);

            if (plane != null)
                plane.printPlane();
            else
                Console.WriteLine("\nAvion nije pronadjen.");
        }

        public static void SearchPlaneByName(List<Plane> planes)
        {
            Console.Write("Unesi naziv aviona: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\nNeispravan unos.");
                return;
            }

            var plane = planes.Where(p => p.Name == name).ToList();

            DisplayPlanes(plane);
        }


        public static void DeletePlane(List<Plane> planes, List<Flight> flights)
        {
            Console.WriteLine("1 - Po ID-u");
            Console.WriteLine("2 - Po nazivu");
            Console.Write("\nOdabir: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("\nNeispravan odabir.");
                return;
            }

            if(choice == 1)
                DeletePlaneById(planes, flights);
            else DeletePlaneByName(planes, flights);
        }

        public static void DeletePlaneById(List<Plane> planes, List<Flight> flights)
        {
            Console.Write("Unesi ID aviona: ");
            string id = Console.ReadLine().Trim();

            if (!Guid.TryParse(id, out Guid planeId))
            {
                Console.WriteLine("\nNeispravan format ID-a.");
                return;
            }

            var plane = planes.FirstOrDefault(p => p.Id == planeId);

            if (plane == null)
            {
                Console.WriteLine("\nAvion nije pronadjen.");
                return;
            }

            if (flights.Any(f => f.Plane == plane))
            {
                Console.WriteLine("\nAvion se ne moze obrisat jer je dodijeljen letu.");
                return;
            }

            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da zelis obrisat avion?(da/ne)");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");
            if (check == "ne")
            {
                Console.WriteLine("\nBrisanje ponisteno.");
                return;
            }

            planes.Remove(plane);
            Console.WriteLine("\nAvion uspjesno obrisan.");
        }

        public static void DeletePlaneByName(List<Plane> planes, List<Flight> flights)
        {
            Console.Write("Unesi naziv aviona: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("\nNeispravan unos.");
                return;
            }

            var plane = planes.Where(p => p.Name == name).ToList();

            if (!plane.Any())
            {
                Console.WriteLine("\nAvion nije pronadjen.");
                return;
            }

            Plane chosen;
            if (plane.Count > 1)
            {
                Console.WriteLine("\nPronadjeno vise aviona s tim imenom:");
                for (int i = 0; i < plane.Count; i++)
                {
                    Console.Write($"#{i + 1} ");
                    plane[i].printPlane();
                }
                chosen = plane[Helpers.ChooseIndex(plane.Count(), "avion")];
            }
            else chosen = plane[0];


            if (flights.Any(f => f.Plane == chosen))
            {
                Console.WriteLine("\nAvion se ne moze obrisat jer je dodijeljen letu.");
                return;
            }

            string? check;
            do
            {
                Console.WriteLine("\nJesi li siguran da zelis obrisat avion?(da/ne)");
                check = Console.ReadLine().ToLower();
            } while (check != "da" && check != "ne");
            if (check == "ne")
            {
                Console.WriteLine("\nBrisanje ponisteno.");
                return;
            }

            planes.Remove(chosen);
            Console.WriteLine("\nAvion uspjesno obrisan.");
        }

    }
}
