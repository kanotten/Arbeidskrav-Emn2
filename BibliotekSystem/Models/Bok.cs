using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Representerer en fysisk bok i biblioteket.
    /// </summary>
    public class Bok : Media
    {
        private string _forfatter;

        /// <summary>
        /// Forfatter av boken.
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
        /// Antall sider i boken.
        /// </summary>
        public int AntallSider { get; set; }

        /// <summary>
        /// Oppretter ny bok.
        /// </summary>
        public Bok(string tittel, int publiseringsår, string forfatter, int antallSider)
            : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            AntallSider = antallSider;
            LånePeriodeDager = 14;
        }

        /// <summary>
        /// Viser informasjon om boken.
        /// </summary>
        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] Bok: '{Tittel}' av {Forfatter} ({Publiseringsår}) - {AntallSider} sider");
        }
    }
}
