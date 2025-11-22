using Aerodrom.enums;

namespace Aerodrom.classes
{
    public static class CrewHelper
    {
        public static void CreateCrew(List<CrewMember> crewMembers, List<Crew> crews)
        {

            string? name;
            do
            {
                Console.Write("Ime posade: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            var pilots = crewMembers.Where(c => (c.Position == CrewMemberType.Pilot && c.IsAssigned == false)).ToList();
            if (!pilots.Any())
            {
                Console.WriteLine("Nema dostupnih pilota!");
                return;
            }

            Console.WriteLine("\nDostupni piloti:");
            for (int i = 0; i < pilots.Count; i++)
                Console.WriteLine($"#{i + 1} {pilots[i].FirstName} {pilots[i].LastName}");

            var pilot = pilots[Helpers.ChooseIndex(pilots.Count, "pilota")];

            var copilots = crewMembers.Where((c => c.Position == CrewMemberType.Copilot && c.IsAssigned == false)).ToList();
            if (!copilots.Any())
            {
                Console.WriteLine("Nema dostupnih kopilota!");
                return;
            }

            Console.WriteLine("\nDostupni kopiloti:");
            for (int i = 0; i < copilots.Count; i++)
                Console.WriteLine($"#{i + 1} {copilots[i].FirstName} {copilots[i].LastName}");

            var copilot = copilots[Helpers.ChooseIndex(copilots.Count, "kopilota")];

            var stewardesses = crewMembers.Where((c => c.Position == CrewMemberType.Stewardess && c.IsAssigned == false)).ToList();
            if (!stewardesses.Any())
            {
                Console.WriteLine("\nNema dostupnih stjuardesa.");
                return;
            }

            Console.WriteLine("\nDostupne stjuardese:");
            for (int i = 0; i < stewardesses.Count; i++)
                Console.WriteLine($"#{i + 1} {stewardesses[i].FirstName} {stewardesses[i].LastName}");

            Console.Write("Koliko stjuardesa želiš (1 ili 2)? ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                Console.Write("Unesi 1 ili 2: ");

            
            Console.WriteLine($"\nOdaberi prvu stjuardesu:");
            var stewardess1 = stewardesses[Helpers.ChooseIndex(stewardesses.Count, "stjuardesu")];

            CrewMember? stewardess2 = null;
            if (choice == 2)
            {
                Console.WriteLine($"\nOdaberi drugu stjuardesu:");
                stewardess2 = stewardesses[Helpers.ChooseIndex(stewardesses.Count, "stjuardesu")];

            }

            var newCrew = new Crew(name, pilot, copilot, stewardess1, stewardess2);
            crews.Add(newCrew);
        }

        public static Crew ChooseCrew(List<Crew>crews)
        {
            DisplayCrews(crews);
            return crews[Helpers.ChooseIndex(crews.Count(), "posadu")];
        }

        public static void DisplayCrews(List<Crew> crews)
        {
            for(int i = 0; i < crews.Count(); i++)
            {
                Console.WriteLine();
                Console.Write($"#{i + 1} ");
                crews[i].PrintCrew();
            }
        }
    }
}
