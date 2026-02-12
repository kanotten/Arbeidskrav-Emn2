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
    }
}