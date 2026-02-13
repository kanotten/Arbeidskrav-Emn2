using System;
using System.ComponentModel;
using System.Net.Http.Headers;

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
        public DateTime ForventetInnLeveringDato { get; private set; }
        public DateTime? InnlevertDato { get; private set; }

        public Utlån(Media media, Bruker bruker)
        {
            
        }

    }
}