# TODO

- Lage validering av [Post] Index(). Sjekke at alle feltene og linjene samsvarer med det som kommer i TicketDTO som trengs i en Ticket.

- Legge inn javascript validering i Index() for å sørge for at brukeren har faktisk skrevet inn en stasjon som ligger i datalist listen. 
  
  - Nå så skjer valideringen på server siden, men vi må ha en på client siden.
  - Gi hver eneste felt en direkte test og feilmelding hvis det ikke samsvarer med kravene.

- ~~Sette billett Voksen sin verdi til 1 by default.

- Sette default dato/tid til nå.

- Legge til kredittkort form på Departure siden.

- Lagre en ny ticket i Receipt()

- Hvis det er tid: "Neste" og "Forrige" knapp på avganger som viser neste og forrige halvtime med avganger.

- Pynte sidene. Navbar fixed? Super-enkel footer, egen style på input-felt. 

Ting som må nevnes i README:

- Be han dobbelsjekke at .mdf og .ldf filene i App_Data folder vises (add existing item).

- Be han dobbeltsjekke at Microsoft.CodeDom.Providers.DotNetCompilerPlatform er installert. 

- Nevne alle ting som er spesielle med løsningen vår, siden han ikke har en liste av funksjonalitet. Eller liste av all funksjonalitet? 
	- at vi  har Clear input om det er feil verdi og man går ut av den
	- 
