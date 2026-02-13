using System;
using System.Collections.Generic;

namespace BibliotekSystem.Models
{

    public abstract class Bruker
    {
        private static int _idCounter = 1;

        private readonly string _brukerID;
        public string BrukerID => _brukerID;

        private string _navn;
        public string Navn
        {
            get => _navn;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Navn kan ikke være tomt.");
                _navn = value;
            }
        }

        private string _epost;
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

        public List<Media> UtlånteMedier { get; private set; }

        protected Bruker(string navn, string epost)
        {
            Navn = navn;
            Epost = epost;

            _brukerID = $"B{_idCounter:D3}";
            _idCounter++;

            UtlånteMedier = new List<Media>();

           
        }

        public void LeggTilUtlåntMedia (Media media)
        {
            if (media == null)
            throw new ArgumentNullException(nameof(media));

            UtlånteMedier.Add(media);
        }
        public void FjernUtlåntMedia(Media media)
        {
            if (media == null)
                throw new ArgumentNullException(nameof(media));

            UtlånteMedier.Remove(media);
        }

        public abstract bool KanLåne();

        
    }
}