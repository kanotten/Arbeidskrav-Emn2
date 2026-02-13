using System;

namespace BibliotekSystem.Models
{
    public class Lydbok : Media
    {
        private string _forfatter;

        public string Forfatter
        {
            get => _forfatter;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Forfatter kan ikke være tom.");
                _forfatter = value;
            }
        }

        public TimeSpan Varighet { get; set; }

        public Lydbok(string tittel, int publiseringsår, string forfatter, TimeSpan varighet)
            : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            Varighet = varighet;
            LånePeriodeDager = 14;
        }

        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] Lydbok: '{Tittel}' av {Forfatter} - Varighet: {Varighet}");
        }
    }
}
