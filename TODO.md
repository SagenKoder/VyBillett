# TODO

- Lage knappene for Voksen, Student, og barnebillett.

	- Legge inn ticket type inn i TicketDTO. int Voksen, int Student, int Barn
	- Legge inn form element for de forskjellige billett-typene. Bruk @Html klassen for å lage dem.

- Lage API som validerer begge stasjonene, og sjekker om stasjonene er i samme Linje.

	- Returnerer true/false. Hvis True så skal den returnere de tidspunktene den linjen går fra stasjonen. 
	Må bare vise avgangene fra tiden skrevet inn i formen, og utover.
	Eks: 12:00 -> 23:59 når 12:00 er skrevet inn i formen.

- Lage validering av [Post] Index(). Sjekke at alle feltene og linjene samsvarer med det som kommer i TicketDTO som trengs i en Ticket.
