using System;

namespace BibliotekSystem.Models
{
    public class Tidsskrift : Media
    {
        public int Utgavenummer { get; set; }
        public string Måned { get; set; }

        public Tidsskrift(String tittel, int publiseringsår, int utgavenummer, string måned)
        : base(tittel, publiseringsår)
        {
            Utgavenummer = utgavenummer;
            Måned = måned;
            LånePeriodeDager = 3;
        }

        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] Tidsskrift: '{Tittel}' - Utgave {Utgavenummer}, {Måned} {Publiseringsår}");
        }
    }
}