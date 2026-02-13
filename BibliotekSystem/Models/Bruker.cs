using System;
using System.Collections.Generic;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Abstrakt baseklasse for alle brukere i biblioteket.
    /// </summary>
    public abstract class Bruker
    {
        private static int _idCounter = 1;
        private readonly string _brukerID;
        private string _navn;
        private string _epost;

        /// <summary>
        /// Unik ID for brukeren.
        /// </summary>
        public string BrukerID => _brukerID;

        /// <summary>
        /// Navn på brukeren.
        /// </summary>
        public string Navn
        {
            get => _navn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Navn kan ikke være tomt.");
                _navn = value;
            }
        }

        /// <summary>
        /// E-postadresse til brukeren.
        /// </summary>
        public string Epost
        {
            get => _epost;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Epost må inneholde '@'.");
                _epost = value;
            }
        }

        /// <summary>
        /// Liste over medier brukeren har lånt.
        /// </summary>
        public List<Media> UtlånteMedier { get; private set; }

        /// <summary>
        /// Oppretter ny bruker.
        /// </summary>
        protected Bruker(string navn, string epost)
        {
            Navn = navn;
            Epost = epost;
            _brukerID = $"B{_idCounter:D3}";
            _idCounter++;
            UtlånteMedier = new List<Media>();
        }

        /// <summary>
        /// Legger til et utlånt medie til brukeren.
        /// </summary>
        public void LeggTilUtlåntMedia(Media media)
        {
            if (media == null)
                throw new ArgumentNullException(nameof(media));

            UtlånteMedier.Add(media);
        }

        /// <summary>
        /// Fjerner et utlånt medie fra brukeren.
        /// </summary>
        public void FjernUtlåntMedia(Media media)
        {
            if (media == null)
                throw new ArgumentNullException(nameof(media));

            UtlånteMedier.Remove(media);
        }

        /// <summary>
        /// Angir om brukeren kan låne flere medier.
        /// </summary>
        public abstract bool KanLåne();
    }
}
