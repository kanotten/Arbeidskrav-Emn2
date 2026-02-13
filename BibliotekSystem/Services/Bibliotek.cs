using System;
using System.Collections.Generic;
using BibliotekSystem.Models;

namespace BibliotekSystem.Services
{
    /// <summary>
    /// Håndterer registrering av medier, brukere og utlån i biblioteket.
    /// </summary>
    public class Bibliotek
    {
        /// <summary>
        /// Register over alle medier.
        /// </summary>
        public List<Media> MedieRegister { get; private set; }

        /// <summary>
        /// Register over alle brukere.
        /// </summary>
        public List<Bruker> BrukerRegister { get; private set; }

        /// <summary>
        /// Historikk over alle utlån.
        /// </summary>
        public List<Utlån> UtlånsHistorikk { get; private set; }

        /// <summary>
        /// Oppretter nytt bibliotek.
        /// </summary>
        public Bibliotek()
        {
            MedieRegister = new List<Media>();
            BrukerRegister = new List<Bruker>();
            UtlånsHistorikk = new List<Utlån>();
        }

        /// <summary>
        /// Registrerer ny bruker i systemet.
        /// </summary>
        public void RegistrerBruker(Bruker bruker)
        {
            if (bruker == null)
                throw new ArgumentNullException(nameof(bruker));

            BrukerRegister.Add(bruker);
        }

        /// <summary>
        /// Legger til nytt medie i biblioteket (kun ansatte).
        /// </summary>
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

        /// <summary>
        /// Registrerer utlån av et medie til en bruker.
        /// </summary>
        public void LånMedia(string mediaID, string brukerID)
        {
            Media media = MedieRegister.Find(m => m.MediaID == mediaID);
            Bruker bruker = BrukerRegister.Find(b => b.BrukerID == brukerID);

            if (media == null)
                throw new InvalidOperationException("Media finnes ikke.");
            if (bruker == null)
                throw new InvalidOperationException("Bruker finnes ikke.");
            if (media.ErUtlånt)
                throw new InvalidOperationException("Media er allerede utlånt.");
            if (!bruker.KanLåne())
                throw new InvalidOperationException("Bruker har nådd maks antall lån.");

            Utlån utlån = new Utlån(media, bruker);

            UtlånsHistorikk.Add(utlån);
            bruker.LeggTilUtlåntMedia(media);
            media.MarkerSomUtlånt();
        }

        /// <summary>
        /// Registrerer innlevering av et medie.
        /// </summary>
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

        /// <summary>
        /// Viser alle tilgjengelige medier.
        /// </summary>
        public void VisTilgjengeligeMedier()
        {
            foreach (var media in MedieRegister)
            {
                if (!media.ErUtlånt)
                    media.VisInfo();
            }
        }

        /// <summary>
        /// Viser alle utlån for en bruker.
        /// </summary>
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
