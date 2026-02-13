using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Representerer en lydbok i biblioteket.
    /// </summary>
    public class Lydbok : Media
    {
        private string _forfatter;

        /// <summary>
        /// Forfatter av lydboken.
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
        /// Varighet på lydboken.
        /// </summary>
        public TimeSpan Varighet { get; set; }

        /// <summary>
        /// Oppretter ny lydbok.
        /// </summary>
        public Lydbok(string tittel, int publiseringsår, string forfatter, TimeSpan varighet)
            : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            Varighet = varighet;
            LånePeriodeDager = 14;
        }

        /// <summary>
        /// Viser informasjon om lydboken.
        /// </summary>
        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] Lydbok: '{Tittel}' av {Forfatter} - Varighet: {Varighet}");
        }
    }
}
