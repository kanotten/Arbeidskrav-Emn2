using system;

namespace BibliotekSystem.Models
{
    public abstract class Media
    {
        private static int _idCounter = 1;

        private string _mediaID;

        public string MediaID => _mediaID;
        
        private string _tittel;
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

        private int _publiseringsår;
        public int Publiseringsår
        {
            get => _publiseringsår;
            set
            {
                if (value < 1800 || value > 2026)
                throw new ArgumentException("Publiseringsår må være mellom 1800 - 2026");
                _publiseringsår = value;
            }
        }

        public bool ErUtlånt {get; protected set; }
        
        public int LånePeriodeDager {get; protected set; }

        protected Media(string tittel, int publiseringsår)
        {
           
            Tittel = tittel;
            Publiseringsår = publiseringsår;
            ErUtlånt = false; 

             _mediaID = $"M{_idCounter:D3}";
            _idCounter++;
        }

        public void MarkerUtlånt()
        {
            ErUtlånt = true;
        }

        public void MarkerTilgjengelig()
        {
            ErUtlånt = false;
        }

        public abstract void VisInfo();
        
    }
}