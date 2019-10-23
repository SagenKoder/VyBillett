 
 Entity framework Find() First() FirstOrDefault() Single() SingleOrDefault() forklaring
 https://stackoverflow.com/questions/3485317/entity-framework-4-single-vs-first-vs-firstordefault


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

