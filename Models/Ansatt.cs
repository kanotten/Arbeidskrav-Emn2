using System;
using System.ComponentModel;

namespace BibliotekSystem.Models
{
    public class Ansatt : Bruker
    {
        private const int MaksAntallLån = 10;

        public Ansatt(string navn, string epost)
        : base(navn, epost)
        {
            
        }

        public override bool KanLåne()
        {
            return UtlånteMedier.Count < MaksAntallLån;
        }
    }
}