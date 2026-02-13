using System;

namespace BibliotekSystem.Models
{
    public class Ebok : Media
    {
        private string _forfatter;
        public string Forfatter
        {
            get => _forfatter;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Forfatter kan ikke være tom.");
                _forfatter = value;
            }
        }

        public double FilStørrelseMB { get; set; }

        public EBok(string tittel, int publiseringsår, string forfatter, double filStørrelseMB)
        : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            FilStørrelseMB = filStørrelseMB;
            LånePeriodeDager = 21;
        }

        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] E-bok: '{Tittel}' av {Forfatter} - {FilStørrelseMB} MB");
        }

    }
}