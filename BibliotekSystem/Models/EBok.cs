using System;

namespace BibliotekSystem.Models
{
    public class EBok : Media
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

        private double _filStørrelseMB;
        public double FilStørrelseMB
        {
            get => _filStørrelseMB;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Filstørrelse må være større enn 0.");
                _filStørrelseMB = value;
            }
        }

        public EBok(string tittel, int publiseringsår, string forfatter, double filStørrelseMB)
            : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            FilStørrelseMB = filStørrelseMB;
            LånePeriodeDager = 21;
        }

        public override void VisInfo()
        {
            Console.WriteLine($"[E-BOK] {MediaID} - {Tittel} ({Publiseringsår}) - {Forfatter} - {FilStørrelseMB} MB");
        }
    }
}
