using System;

namespace BibliotekSystem.Models
{
    /// <summary>
    /// Representerer en ansatt i biblioteket.
    /// </summary>
    public class Ansatt : Bruker
    {
        /// <summary>
        /// Oppretter ny ansatt.
        /// </summary>
        public Ansatt(string navn, string epost)
            : base(navn, epost)
        {
        }

        /// <summary>
        /// Ansatte har ingen begrensning på antall lån.
        /// </summary>
        public override bool KanLåne()
        {
            return true;
        }
    }
}
