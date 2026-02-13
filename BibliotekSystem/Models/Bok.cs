using System;

namespace BibliotekSystem.Models
{
    public class Bok : Media
    {
        private string _forfatter;

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

        public int AntallSider { get; set; }

        public Bok(string tittel, int publiseringsår, string forfatter, int antallSider)
            : base(tittel, publiseringsår)
        {
            Forfatter = forfatter;
            AntallSider = antallSider;
            LånePeriodeDager = 14;
        }

        public override void VisInfo()
        {
            Console.WriteLine($"[{MediaID}] Bok: '{Tittel}' av {Forfatter} ({Publiseringsår}) - {AntallSider} sider");
        }
    }
}
