using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_plenum_2.DAL
{
    public class KundeDAL
    {
        public List<Kunde> hentAlle()
        {
            using (var db = new KundeContext())
            {
                List<Kunde> alleKunder = db.Kunder.Select(k=> new Kunde()
                                     {
                                        id = k.ID,
                                        fornavn = k.Fornavn,
                                        etternavn = k.Etternavn,
                                        adresse = k.Adresse,
                                        postnr = k.Postnr,
                                        poststed = k.Poststeder.Poststed
                                     }  
                                ).ToList();
            
                return alleKunder;
            }
        }

        public bool settInn(Kunde innKunde)
        {
            var nyKunde = new Kunder()
            {
                Fornavn = innKunde.fornavn,
                Etternavn = innKunde.etternavn,
                Adresse = innKunde.adresse,
                Postnr = innKunde.postnr
            };


            using (var db = new KundeContext())
            {
                try
                {
                    var eksistererPostnr = db.Poststeder.Find(innKunde.postnr);

                    if (eksistererPostnr == null)
                    {
                        var nyttPoststed = new Poststeder()
                        {
                            Postnr = innKunde.postnr,
                            Poststed = innKunde.poststed
                        };
                        nyKunde.Poststeder = nyttPoststed;
                    }
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            using (var db = new KundeContext())
            {

            
                try
                {
                    Kunder endreKunde = db.Kunder.Find(id);
                    endreKunde.Fornavn = innKunde.fornavn;
                    endreKunde.Etternavn = innKunde.etternavn;
                    endreKunde.Adresse = innKunde.adresse;
                    if (endreKunde.Postnr != innKunde.postnr)
                    {
                        // Postnummeret er endret. Må først sjekke om det nye postnummeret eksisterer i tabellen.
                        Poststeder eksisterendePoststed = db.Poststeder.FirstOrDefault(p => p.Postnr == innKunde.postnr);
                        if (eksisterendePoststed == null)
                        {
                            // poststedet eksisterer ikke, må legges inn
                            var nyttPoststed = new Poststeder()
                            {
                                Postnr = innKunde.postnr,
                                Poststed = innKunde.poststed
                            };
                            db.Poststeder.Add(nyttPoststed);
                        }
                        else
                        {   // poststedet med det nye postnr eksisterer, endre bare postnummeret til kunden
                            endreKunde.Postnr = innKunde.postnr;
                        }
                    };
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool slettKunde(int slettId)
        {
            using (var db = new KundeContext())
            { 
                try
                {
                    Kunder slettKunde = db.Kunder.Find(slettId);
                    db.Kunder.Remove(slettKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        public Kunde hentEnKunde(int id)
        {
            using (var db = new KundeContext())
            {


                var enDbKunde = db.Kunder.Find(id);

                if (enDbKunde == null)
                {
                    return null;
                }
                else
                {
                    var utKunde = new Kunde()
                    {
                        id = enDbKunde.ID,
                        fornavn = enDbKunde.Fornavn,
                        etternavn = enDbKunde.Etternavn,
                        adresse = enDbKunde.Adresse,
                        postnr = enDbKunde.Postnr,
                        poststed = enDbKunde.Poststeder.Poststed
                    };
                    return utKunde;
                }
            }
        }
    }
}