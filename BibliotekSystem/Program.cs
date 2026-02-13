using System;
using BibliotekSystem.Models;
using BibliotekSystem.Services;

class Program
{
    static void Main()
    {
        Bibliotek bibliotek = new Bibliotek();

        //Test
        Ansatt ansatt = new Ansatt("Admin", "admin@bibliotek.no");
        Medlem medlem = new Medlem("Ola Nordmann", "ola@mail.no");

        bibliotek.RegistrerBruker(ansatt);
        bibliotek.RegistrerBruker(medlem);

        Bok bok1 = new Bok("Haien", 1995, "Kenneth Sheikh", 300);
        bibliotek.LeggTilMedia(bok1, ansatt);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Vis tilgjengelige medier");
            Console.WriteLine("2. Lån media");
            Console.WriteLine("3. Lever media");
            Console.WriteLine("4. Avslutt");
            Console.Write("Velg: ");

            string valg = Console.ReadLine();

            try
            {
                switch (valg)
                {
                    case "1":
                        bibliotek.VisTilgjengeligeMedier();
                        break;

                    case "2":
                        Console.Write("MediaID: ");
                        string mediaID = Console.ReadLine();

                        Console.Write("BrukerID: ");
                        string brukerID = Console.ReadLine();

                        bibliotek.LånMedia(mediaID, brukerID);
                        Console.WriteLine("Lån registrert.");
                        break;

                    case "3":
                        Console.Write("MediaID: ");
                        string mediaID2 = Console.ReadLine();

                        Console.Write("BrukerID: ");
                        string brukerID2 = Console.ReadLine();

                        bibliotek.LeverInnMedia(mediaID2, brukerID2);
                        Console.WriteLine("Innlevering registrert.");
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                        }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Feil: {ex.Message}");
            }
        }
    }
}

                
            
