using System;
using BibliotekSystem.Models;
using BibliotekSystem.Services;

class Program
{
    static void Main()
    {
        Bibliotek bibliotek = new Bibliotek();

        //Test
        Ansatt ansatt = new Ansatt("Admin", "admin@bibliotek.no");
        Medlem medlem = new Medlem("Ola Nordmann", "ola@mail.no");

        bibliotek.RegistrerBruker(ansatt);
        bibliotek.RegistrerBruker(medlem);

        Bok bok1 = new Bok("Haien", 1974, "Peter Benchley", 300);
        bibliotek.LeggTilMedia(bok1, ansatt);
    }
}

