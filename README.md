Oblig 2:

Prosjektoppgave i Webapplikasjoner i .NET MVC , Del 2.
Mål

    Lage et administrasjonsgrensesnitt for prosjektoppgave 1 implementert i MVC.
    Lagdele applikasjonen i MVC, Model, BLL og DAL
    Lage  enhetstester

Funksjonalitet:  

Løsningen bør blant annet inneholde:

    Administrasjon av strekninger,  avganger og priser  etc.  Altså de entitetene dere har i deres database fra oppgave 1.
    Innloggingsmekanisme for admin-brukere.
    Logging av endringer til database.
    Logging av feilsituasjoner til fil. Det betyr bla. de som kan oppstå når databasen aksesseres.

Ved evaluering av oppgaven vil det bla. bli vektlagt:

    Design / layout tilsvarende løsningen i tidligere prosjektoppgaver.
    Ryddig og forståelig kode.
    Kompletthet av enhetstest for denne løsningen (ikke nødvendig å lage det for tidligere deler).

Hva skal leveres:

Registrer dere på en av gruppene som er opprettet under Gruppeoppgave2.

En zip. fil som inneholder hele MVC-løsningen i Canvas. Løsningen skal integreres i den allerede eksiterende løsning fra oppgave 1. Det er ikke nødvendig å endre løsningen fra oppgave 1 på noen måte (det kreves altså ikke at denne lagdeles). Der skal det også refereres til evt. kode som ikke er egenutviklet eller laget av meg. Påloggingsinformasjon for admin-bruker må oppgis i en fil kalt Readme.txt. Denne filen må ligge i løsningen på øverste nivå (sett fra Solution Explorer). 

Dersom løsningen kjøres på en skyløsning må URL'en oppgis i Readme.txt filen.

 

Oppgaven teller med 1/3 av totalen. Det vil blir satt foreløpige karakterer på oppgavene, men sluttkarakter vil skje etter en totalvurdering til slutt.

 




 Oblig 1:


 MERK:
 Det kan være lurt å dobbelsjekke at .mdf og .ldf filene i App_Data folder vises (add existing item).


 Antagelser/valg:

 - Vi har valgt å tolke oppgaven slik at man skal bare kunne reise direkte mellom stasjoner uten bytte. 

 - Vi har antatt at vi ikke skal lagre kredittkortinformasjon og annen personlig informasjon i databasen grunnet GDPR og vi ikke kan se at dette
 skal være nødvendig i forhold til oppgaven. 


 Et par ting å nevne ved prosjektet vårt:

 - Vi fjerner input i stasjoner-input dersom det ikke er en godkjent stasjon slik at man ikke kan 
skrive f.eks. "Berg" i "reise fra" og gå videre til "reise til". 

- Vi har lagt inn avganger i minst 6 til 9 dager frem i tid (fra prosjekt kjøres). Lagt til i DbInit.cs


 Vårt system og funksjonalitet kort oppsummert:
 
 - Vi har en Station som representerer en stasjon
 - En Line representerer en tog-strekning (f.eks. R20 - Oslo s - Halden).
 - En LineStation representerer en stasjon på en linje. Denne har en kolonne "Minutes" som er antall minutter dette stoppet er fra første stasjon på linjen.
 Dette tillater beregning av reisetid. 
  - Departure representerer når et tog forlater første stasjon på linjen. Man kan videre beregne når tog er på de neste stasjonene med "Minutes" på LineStation.
  - Category inneholder priskategorier
  - Ticket representerer en kjøpt billett. 
  
  Flyt:
  - På forsiden kan man velge stasjon fra/til, samt dato/tid og antall billetter av de forskjellige kategoriene. 
  - På neste side får man en liste over alle avganger fra valgt stasjon 30 minutter frem i tid fra valgt tidspunkt. Man fyller også ut betalingsinformasjon
  på denne siden. 
  - På siste side får man kvittering for kjøp med info om avgang, ankomst, pris, antall billetter og type billetter. 

