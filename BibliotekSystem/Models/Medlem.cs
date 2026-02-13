using System;

namespace BibliotekSystem.Models
{
    public class Medlem : Bruker
    {
        private const int MaksAntallLån = 5;

        public Medlem(string navn, string epost)
        : base(navn, epost)
        {
        }

        public override bool KanLåne()
        {
            return UtlånteMedier.Count < MaksAntallLån;
        }
    
    }
}
