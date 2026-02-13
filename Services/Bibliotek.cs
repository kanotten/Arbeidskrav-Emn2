using System;
using System.Collections.Generic;
using BibliotekSystem.Models;

namespace BibliotekSystem.Services
{
    public class Bibliotek
    {
        public List<Media> MedieRegister { get; private set; }
        public List<Bruker> BrukerRegister { get; private set; }
        public List<Utlån> UtlånsHistorikk { get; private set; }

        public Bibliotek()
        {
            MedieRegister = new List<Media>();
            BrukerRegister = new List<Bruker>();
            UtlånsHistorikk = new List<Utlån>();
        }
    }
}