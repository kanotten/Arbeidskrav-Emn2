using System;

namespace BibliotekSystem.Models
{
    public class Bok : Media
    {
        private string _forfatter;
        public string _forfatter
        {
            get => _forfatter;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Forfatter kan ikke være tom.");
                _forfatter = value;
            }
        }

        public int AntallSider { get; set; }
        
    }
}