using System;

namespace BibliotekSystem.Models
{
    public class Utlån
    {
        private static int _idCounter = 1;

        private readonly string _utlånsID;
        public string UtlånsID => _utlånsID;

        public Media Media { get; private set; }
        public Bruker Bruker { get; private set; }

        public DateTime UtlånsDato { get; private set; }
        public DateTime ForventetInnleveringsDato { get; private set; }
        public DateTime? InnlevertDato { get; private set; }

        public Utlån(Media media, Bruker bruker)
        {
            if (media == null)
                throw new ArgumentNullException(nameof(media));
            if (bruker == null)
                throw new ArgumentNullException(nameof(bruker));

            Media = media;
            Bruker = bruker;

            UtlånsDato = DateTime.Now;
            ForventetInnleveringsDato = UtlånsDato.AddDays(media.LånePeriodeDager);

            _utlånsID = $"U{_idCounter:D3}";
            _idCounter++;
        }

        public void RegistrerInnlevering()
        {
            InnlevertDato = DateTime.Now;
        }
    }
}
