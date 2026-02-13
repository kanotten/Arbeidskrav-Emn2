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
        public string _navn
        {
            get => _navn;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Navn kan ikke være tomt.");
                _navn = value;
            }
        }

        public List<Media> UtlånteMedier { get; private set; }

        protected Bruker(string navn, stirng epost)
        {
          
            Navn = navn;
            Epost = epost;
            UtlånteMedier = new List<Media>();

              -brukerID =$"B{_idCounter:D3}";
            _idCounter++;

        }

        public voind LeggTilUtlåntMedia (Media media)
        {
            if (media == null)
            throw new ArgumentException(nameof(media));

            UtlånteMedier.Add(media);
        }

        
    }
}