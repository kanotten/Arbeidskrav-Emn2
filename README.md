📚 BibliotekSystem – Arbeidskrav 1 (C#)
📌 Beskrivelse

Dette prosjektet er et konsollbasert biblioteksystem utviklet i C#.
Systemet håndterer:

 - Registrering av brukere (Medlem / Ansatt)

 - Registrering av medier (Bok, Lydbok, E-bok)

 - Utlån og innlevering

 - Utlånshistorikk

 - Validering av input

 - Maks antall lån for medlemmer

Prosjektet er strukturert etter objektorienterte prinsipper med tydelig ansvarsfordeling mellom klasser.

🏗 Struktur

Prosjektet er delt inn i:

 - Models

 - Inneholder domenelogikken:

 - Media (abstrakt baseklasse)

 - Bok

 - Lydbok

 - EBok

 - Bruker (abstrakt baseklasse)

 - Medlem

 - Ansatt

 - Utlån

 - Services

Bibliotek
Håndterer registrering, utlån, innlevering og oversikter.

Program.cs

Inneholder meny og testdata for å demonstrere funksjonalitet.

▶️ Hvordan kjøre programmet

Kjør følgende kommando i terminal:

dotnet run --project BibliotekSystem/BibliotekSystem.csproj

🧪 Testdata

Programmet starter med:

1 ansatt

1 medlem

1 bok

Dette er tilstrekkelig for å demonstrere:

Utlån

Innlevering

Validering

Begrensning på maks lån

🧠 Objektorienterte prinsipper brukt

Abstrakte baseklasser (Media, Bruker)

Arv

Innkapsling

Collections (List<T>)

Validering i properties

Ansvarsdeling mellom lag (Models / Services / Program)

🤖 Bruk av AI

AI (ChatGPT) ble brukt til:

Planlegging av struktur og prioritering av implementasjon

Diskusjon rundt objektorienterte prinsipper

Generering av XML-kommentarer for public metoder og properties

Hjelp til README-struktur og markdown-syntaks

All logikk, struktur og forståelse av løsningen er gjennomgått og implementert manuelt.

Etter implementert kode har Ai deretter justert koden i form av refractor for enten bedre leselig eller mer organisert kode. 

📎 Teknologi

.NET 8

C#

Konsollapplikasjon

Github link: [text](https://github.com/kanotten/Arbeidskrav-Emn2)