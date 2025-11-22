using Aerodrom.enums;

namespace Aerodrom.classes
{
    public static class CrewHelper
    {
        public static List<CrewMember> ChooseCrewMembers(List<CrewMember> crew)
        {
            var selectedCrew = new List<CrewMember>();

            var pilots = crew.Where(c => c.Position == CrewMemberType.Pilot).ToList();
            if (!pilots.Any())
            {
                Console.WriteLine("Nema dostupnih pilota!");
                return selectedCrew;
            }

            Console.WriteLine("\nDostupni piloti:");
            for (int i = 0; i < pilots.Count; i++)
                Console.WriteLine($"#{i + 1} {pilots[i].FirstName} {pilots[i].LastName}");

            selectedCrew.Add(pilots[Helpers.ChooseIndex(pilots.Count, "pilota")]);

            var copilots = crew.Where(c => c.Position == CrewMemberType.Copilot).ToList();
            if (!copilots.Any())
            {
                Console.WriteLine("Nema dostupnih kopilota!");
                return selectedCrew;
            }

            Console.WriteLine("\nDostupni kopiloti:");
            for (int i = 0; i < copilots.Count; i++)
                Console.WriteLine($"#{i + 1} {copilots[i].FirstName} {copilots[i].LastName}");

            selectedCrew.Add(copilots[Helpers.ChooseIndex(copilots.Count, "kopilota")]);

            var stewardesses = crew.Where(c => c.Position == CrewMemberType.Stewardess).ToList();
            if (!stewardesses.Any())
            {
                Console.WriteLine("\nNema dostupnih stjuardesa.");
                return selectedCrew;
            }

            Console.WriteLine("\nDostupne stjuardese:");
            for (int i = 0; i < stewardesses.Count; i++)
                Console.WriteLine($"#{i + 1} {stewardesses[i].FirstName} {stewardesses[i].LastName}");

            Console.Write("Koliko stjuardesa želiš (1 ili 2)? ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                Console.Write("Unesi 1 ili 2: ");

            for (int i = 0; i < choice; i++)
            {
                Console.WriteLine($"\nOdaberi stjuardesu #{i + 1}:");
                selectedCrew.Add(stewardesses[Helpers.ChooseIndex(stewardesses.Count, "stjuardesu")]);
            }

            return selectedCrew;
        }

    }
}
