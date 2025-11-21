using Aerodrom.classes;

namespace Aerodrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACIJA ZA UPRAVLJANJE AERODROMOM");

            while (true)
            {
                int choice = mainMenu();

                switch(choice)
                {
                    case 1:
                        passengerMenu();
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

        public static void passengerMenu()
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
                        register();
                    else if (answer == 2) 
                        login();
                    else return;
                }
            }
        }
    }
}
