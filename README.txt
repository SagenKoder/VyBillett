 
 Entity framework Find() First() FirstOrDefault() Single() SingleOrDefault() forklaring
 https://stackoverflow.com/questions/3485317/entity-framework-4-single-vs-first-vs-firstordefault


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

