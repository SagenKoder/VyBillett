Oblig 2:

Prosjektoppgave i Webapplikasjoner i .NET MVC , Del 2.
M�l

    Lage et administrasjonsgrensesnitt for prosjektoppgave 1 implementert i MVC.
    Lagdele applikasjonen i MVC, Model, BLL og DAL
    Lage  enhetstester

Funksjonalitet:  

L�sningen b�r blant annet inneholde:

    Administrasjon av strekninger,  avganger og priser  etc.  Alts� de entitetene dere har i deres database fra oppgave 1.
    Innloggingsmekanisme for admin-brukere.
    Logging av endringer til database.
    Logging av feilsituasjoner til fil. Det betyr bla. de som kan oppst� n�r databasen aksesseres.

Ved evaluering av oppgaven vil det bla. bli vektlagt:

    Design / layout tilsvarende l�sningen i tidligere prosjektoppgaver.
    Ryddig og forst�elig kode.
    Kompletthet av enhetstest for denne l�sningen (ikke n�dvendig � lage det for tidligere deler).

Hva skal leveres:

Registrer dere p� en av gruppene som er opprettet under Gruppeoppgave2.

En zip. fil som inneholder hele MVC-l�sningen i Canvas. L�sningen skal integreres i den allerede eksiterende l�sning fra oppgave 1. Det er ikke n�dvendig � endre l�sningen fra oppgave 1 p� noen m�te (det kreves alts� ikke at denne lagdeles). Der skal det ogs� refereres til evt. kode som ikke er egenutviklet eller laget av meg. P�loggingsinformasjon for admin-bruker m� oppgis i en fil kalt Readme.txt. Denne filen m� ligge i l�sningen p� �verste niv� (sett fra Solution Explorer). 

Dersom l�sningen kj�res p� en skyl�sning m� URL'en oppgis i Readme.txt filen.

 

Oppgaven teller med 1/3 av totalen. Det vil blir satt forel�pige karakterer p� oppgavene, men sluttkarakter vil skje etter en totalvurdering til slutt.

 




 Oblig 1:


 MERK:
 Det kan v�re lurt � dobbelsjekke at .mdf og .ldf filene i App_Data folder vises (add existing item).


 Antagelser/valg:

 - Vi har valgt � tolke oppgaven slik at man skal bare kunne reise direkte mellom stasjoner uten bytte. 

 - Vi har antatt at vi ikke skal lagre kredittkortinformasjon og annen personlig informasjon i databasen grunnet GDPR og vi ikke kan se at dette
 skal v�re n�dvendig i forhold til oppgaven. 


 Et par ting � nevne ved prosjektet v�rt:

 - Vi fjerner input i stasjoner-input dersom det ikke er en godkjent stasjon slik at man ikke kan 
skrive f.eks. "Berg" i "reise fra" og g� videre til "reise til". 

- Vi har lagt inn avganger i minst 6 til 9 dager frem i tid (fra prosjekt kj�res). Lagt til i DbInit.cs


 V�rt system og funksjonalitet kort oppsummert:
 
 - Vi har en Station som representerer en stasjon
 - En Line representerer en tog-strekning (f.eks. R20 - Oslo s - Halden).
 - En LineStation representerer en stasjon p� en linje. Denne har en kolonne "Minutes" som er antall minutter dette stoppet er fra f�rste stasjon p� linjen.
 Dette tillater beregning av reisetid. 
  - Departure representerer n�r et tog forlater f�rste stasjon p� linjen. Man kan videre beregne n�r tog er p� de neste stasjonene med "Minutes" p� LineStation.
  - Category inneholder priskategorier
  - Ticket representerer en kj�pt billett. 
  
  Flyt:
  - P� forsiden kan man velge stasjon fra/til, samt dato/tid og antall billetter av de forskjellige kategoriene. 
  - P� neste side f�r man en liste over alle avganger fra valgt stasjon 30 minutter frem i tid fra valgt tidspunkt. Man fyller ogs� ut betalingsinformasjon
  p� denne siden. 
  - P� siste side f�r man kvittering for kj�p med info om avgang, ankomst, pris, antall billetter og type billetter. 

