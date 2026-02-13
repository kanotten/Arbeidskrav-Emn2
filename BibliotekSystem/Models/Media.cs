using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Abstrakt baseklasse for alle medier i biblioteket.
    /// </summary>
    public abstract class Media
    {
        private static int _idCounter = 1;
        private string _mediaID;
        private string _tittel;
        private int _publiseringsår;

        /// <summary>
        /// Unik ID for mediet.
        /// </summary>
        public string MediaID => _mediaID;

        /// <summary>
        /// Tittel på mediet.
        /// </summary>
        public string Tittel
        {
            get => _tittel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tittel kan ikke være tom.");
                _tittel = value;
            }
        }

        /// <summary>
        /// Publiseringsår for mediet.
        /// </summary>
        public int Publiseringsår
        {
            get => _publiseringsår;
            set
            {
                if (value < 1800 || value > 2026)
                    throw new ArgumentException("Publiseringsår må være mellom 1800 og 2026.");
                _publiseringsår = value;
            }
        }

        /// <summary>
        /// Angir om mediet er utlånt.
        /// </summary>
        public bool ErUtlånt { get; protected set; }

        /// <summary>
        /// Antall dager mediet kan lånes.
        /// </summary>
        public int LånePeriodeDager { get; protected set; }

        /// <summary>
        /// Oppretter nytt medieobjekt.
        /// </summary>
        protected Media(string tittel, int publiseringsår)
        {
            Tittel = tittel;
            Publiseringsår = publiseringsår;
            ErUtlånt = false;
            _mediaID = $"M{_idCounter:D3}";
            _idCounter++;
        }

        /// <summary>
        /// Marker mediet som utlånt.
        /// </summary>
        public void MarkerSomUtlånt() => ErUtlånt = true;

        /// <summary>
        /// Marker mediet som tilgjengelig.
        /// </summary>
        public void MarkerSomTilgjengelig() => ErUtlånt = false;

        /// <summary>
        /// Viser informasjon om mediet.
        /// </summary>
        public abstract void VisInfo();
    }
}
