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

    }
}
