using System;

namespace BibliotekSystem.Models
{
    public class Lydbok : Media
    {
        private string _forfatter;
        public string Forfatter
        {
            get => _forfatter;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Forfatter kan ikke være tom");
                _forfatter = value;
            }
        }

        public Timespan Varighet { get; set; }

        public Lydbok (string tittel, int publiseringsår, string forfatter, Timespan Varighet)
        : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            Varighet = varighet;
            LånePeriodeDager = 7;
        }
        
    
    }
}