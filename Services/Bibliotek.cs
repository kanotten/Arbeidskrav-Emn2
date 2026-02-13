using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
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

        public void RegistrerBruker(Bruker bruker)
        {
            
            if (bruker == null)
            throw new ArgumentNullException(nameof(bruker));

            BrukerRegister.Add(bruker); 
        }

        public void LeggTilMedia(Media media, Bruker bruker)
        {
            if (media == null)
            throw new ArgumentNullException(nameof(media));

            if (bruker == null)
            throw new ArgumentNullException(nameof(bruker));

            if (bruker is not Ansatt)
            throw new InvalidOperationException("Kun ansatte kan legge til medier.");

            MedieRegister.Add(media);
        }

        public void LånMedia(string mediaID, string brukerID)
        {
            Media media = MedieRegister.Find(m => m.MediaId == mediaID);
            Bruker bruker = BrukerRegister.Find(b => b.BrukerID = brukerID);

            if (media == null)
            throw new InvalidOperationsException("Media finnes ikke.");
            if (bruker == null)
            throw new InvalidOperationsException("Bruker finnes ikke");
            if (media.ErUtlånt)
            throw new InvalidOperationsException("Media er allerede utlånt.");
            if (!bruker.KanLåne())
            throw new InvalidOperationsException("Bruker har bådd maks antall lån.");

            Utlån utlån = new Utlån(media, bruker);

            UtlånsHistorikk.Add(utlån);
            bruker.LeggTilUtlåntMedia(media);
            media.MarkerSomUtlånt();

        }

        public void LeverInnMedia(string mediaID, string brukerID)
        {
            Media media = MedieRegister.Find(m => m.MediaID == mediaID);
            Bruker bruker = BrukerRegister.Find(b => b.BrukerID == brukerID);

            if (media == null || bruker == null)
                throw new InvalidOperationException("Media eller bruker finnes ikke.");

            Utlån aktivtUtlån = UtlånsHistorikk.Find(u =>
                u.Media.MediaID == mediaID &&
                u.Bruker.BrukerID == brukerID &&
                !u.InnlevertDato.HasValue);

            if (aktivtUtlån == null)
                throw new InvalidOperationException("Ingen aktivt utlån funnet.");

            aktivtUtlån.RegistrerInnlevering();
            bruker.FjernUtlåntMedia(media);
            media.MarkerSomTilgjengelig();
        }

        public void VisTilgjengligeMedier()
        {
            foreach(var mmedia in MedieRegister)
            {
                if (!MediaTypeHeaderValue.ErUtlånt)
                Media.Visinfo();
            }
        }

        public void VisMineUtlån(string brukerID)
        {
            Bruker bruker = BrukerRegister.Find(b => b.BrukerID == brukerID);

            if (bruker == null)
                throw new InvalidOperationException("Bruker finnes ikke.");

            foreach (var media in bruker.UtlånteMedier)
            {
                Console.WriteLine($"[{media.MediaID}] '{media.Tittel}'");
            }

        }
    }
}