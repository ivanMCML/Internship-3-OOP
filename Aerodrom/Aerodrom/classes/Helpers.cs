namespace Aerodrom.classes
{
    public static class Helpers
    {
        public static DateTime GetDateTime()
        {

            int year;
            while (true)
            {
                Console.Write("Godina: ");
                if (int.TryParse(Console.ReadLine(), out year))
                    break;
                Console.WriteLine("\nNeispravan unos godine.");
            }

            int month;
            while (true)
            {
                Console.Write("Mjesec: ");
                if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                    break;
                Console.WriteLine("\nNeispravan unos mjeseca.");
            }

            int day;
            while (true)
            {
                Console.Write("Dan: ");
                if (int.TryParse(Console.ReadLine(), out day))
                {
                    if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        break;
                }
                Console.WriteLine("\nNeispravan unos dana.");
            }

            int hour;
            while (true)
            {
                Console.Write("Sat (0-23): ");
                if (int.TryParse(Console.ReadLine(), out hour) && hour >= 0 && hour <= 23)
                    break;
                Console.WriteLine("\nNeispravan unos sata.");
            }

            int minute;
            while (true)
            {
                Console.Write("Minute (0-59): ");
                if (int.TryParse(Console.ReadLine(), out minute) && minute >= 0 && minute <= 59)
                    break;
                Console.WriteLine("Neispravan unos minuta.");
            }

            return new DateTime(year, month, day, hour, minute, 0);
        }

        public static int ChooseIndex(int count, string label)
        {
            while (true)
            {
                Console.Write($"Odaberi {label} (1 - {count}): ");
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice >= 1 && choice <= count)
                {
                    return choice - 1;
                }

                Console.WriteLine("Neispravan unos, pokušaj ponovno.");
            }
        }

        public static DateOnly GetDateOnly()
        {

            int year;
            while (true)
            {
                Console.Write("Godina: ");
                if (int.TryParse(Console.ReadLine(), out year))
                    break;
                Console.WriteLine("\nNeispravan unos godine.");
            }

            int month;
            while (true)
            {
                Console.Write("Mjesec: ");
                if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                    break;
                Console.WriteLine("\nNeispravan unos mjeseca.");
            }

            int day;
            while (true)
            {
                Console.Write("Dan: ");
                if (int.TryParse(Console.ReadLine(), out day))
                {
                    if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        break;
                }
                Console.WriteLine("\nNeispravan unos dana.");
            }

            return new DateOnly(year, month, day);
        }


    }
}
