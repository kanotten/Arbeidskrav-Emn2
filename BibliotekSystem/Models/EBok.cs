using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Representerer en e-bok i biblioteket.
    /// </summary>
    public class EBok : Media
    {
        private string _forfatter;

        /// <summary>
        /// Forfatter av e-boken.
        /// </summary>
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

        /// <summary>
        /// Filstørrelse i MB.
        /// </summary>
        public double FilStørrelseMB { get; set; }

        /// <summary>
        /// Oppretter ny e-bok.
        /// </summary>
        public EBok(string tittel, int publiseringsår, string forfatter, double filStørrelseMB)
            : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            FilStørrelseMB = filStørrelseMB;
            LånePeriodeDager = 21;
        }

        /// <summary>
        /// Viser informasjon om e-boken.
        /// </summary>
        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] E-Bok: '{Tittel}' av {Forfatter} ({Publiseringsår}) - {FilStørrelseMB} MB");
        }
    }
}
