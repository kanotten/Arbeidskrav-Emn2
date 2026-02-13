using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Representerer et utlån av et medie til en bruker.
    /// </summary>
    public class Utlån
    {
        private static int _idCounter = 1;
        private readonly string _utlånsID;

        /// <summary>
        /// Unik ID for utlånet.
        /// </summary>
        public string UtlånsID => _utlånsID;

        /// <summary>
        /// Mediet som er lånt.
        /// </summary>
        public Media Media { get; private set; }

        /// <summary>
        /// Brukeren som har lånt mediet.
        /// </summary>
        public Bruker Bruker { get; private set; }

        /// <summary>
        /// Dato for når utlånet ble registrert.
        /// </summary>
        public DateTime UtlånsDato { get; private set; }

        /// <summary>
        /// Forventet dato for innlevering.
        /// </summary>
        public DateTime ForventetInnleveringsDato { get; private set; }

        /// <summary>
        /// Faktisk dato for innlevering (null hvis ikke levert).
        /// </summary>
        public DateTime? InnlevertDato { get; private set; }

        /// <summary>
        /// Oppretter nytt utlån.
        /// </summary>
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

        /// <summary>
        /// Registrerer at mediet er levert tilbake.
        /// </summary>
        public void RegistrerInnlevering()
        {
            InnlevertDato = DateTime.Now;
        }
    }
}
