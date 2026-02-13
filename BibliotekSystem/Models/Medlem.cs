using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Representerer et ordinært medlem i biblioteket.
    /// </summary>
    public class Medlem : Bruker
    {
        private const int MaksAntallLån = 5;

        /// <summary>
        /// Oppretter nytt medlem.
        /// </summary>
        public Medlem(string navn, string epost)
            : base(navn, epost)
        {
        }

        /// <summary>
        /// Sjekker om medlemmet kan låne flere medier.
        /// </summary>
        public override bool KanLåne()
        {
            return UtlånteMedier.Count < MaksAntallLån;
        }
    }
}
