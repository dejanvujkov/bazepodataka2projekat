using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace DatabaseAccess
{
    public class UpdateAccess
    {
        private GetAccess get;
        public UpdateAccess()
        {
            get = new GetAccess();
        }

        public void UpdateAutobus(string brojtablica, int brojmesta, string ispravan, string marka, int kilometri)
        {
            var autobus = get.GetAutobusById(brojtablica);

            using (var db = new AutobuskaStanicaEntities())
            {
                if (autobus.brojmesta != brojmesta)
                {
                    autobus.brojmesta = brojmesta;
                }
                if (autobus.ispravan != ispravan)
                {
                    autobus.ispravan = ispravan;
                }
                if (autobus.marka != marka)
                {
                    autobus.marka = marka;
                }
                if(autobus.kilometri != kilometri)
                {
                    autobus.kilometri = kilometri;
                }
                
                db.Entry(autobus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateAutobuskaStanica(int idStanice, string ime, string grad, string ulica)
        {
            var stanica = get.GetAutobuska_StanicaById(idStanice);

            using (var db = new AutobuskaStanicaEntities())
            {
                if (stanica.ime != ime)
                {
                    stanica.ime = ime;
                }
                if (stanica.grad != grad)
                {
                    stanica.grad = grad;
                }
                if (stanica.ulica != ulica)
                {
                    stanica.ulica = ulica;
                }

                db.Entry(stanica).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateKarta(string idKarte, string jednosmerna, string povratna, string mesecna, string idTipa, string idLinije)
        {
            var karta = get.GetKartaById(idKarte);

            using (var db = new AutobuskaStanicaEntities())
            {
                if (karta.jednosmerna != jednosmerna)
                {
                    karta.jednosmerna = jednosmerna;
                }
                if (karta.povratna != povratna)
                {
                    karta.povratna = povratna;
                }
                if (karta.mesecna != mesecna)
                {
                    karta.mesecna = mesecna;
                }
                if (karta.tip_karte_idtipa != idTipa)
                {
                    karta.tip_karte_idtipa = idTipa;
                }
                if (karta.vozna_linija_idlinije != idLinije)
                {
                    karta.vozna_linija_idlinije = idLinije;
                }

                db.Entry(karta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateMehanicar(string jmbg, int broj)
        {
            var mehanicar = get.GetMehanicarByJmbg(jmbg);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(mehanicar.brojpopravljenih != broj)
                {
                    mehanicar.brojpopravljenih = broj;
                }

                db.Entry(mehanicar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateProdavac(string jmbg, int brojSaltera)
        {
            var prodavac = get.GetProdavacByJmbg(jmbg);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(prodavac.brojsaltera != brojSaltera)
                {
                    prodavac.brojsaltera = brojSaltera;
                }

                db.Entry(prodavac).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdatePutnik(int idPutnika, string ime, string idKarte)
        {
            var putnik = get.GetPutnikById(idPutnika);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(putnik.ime != ime)
                {
                    putnik.ime = ime;
                }
                if(putnik.karta_idkarte != idKarte)
                {
                    putnik.karta_idkarte = idKarte;
                }

                db.Entry(putnik).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateRadnik(string jmbg, int idStanice, string ime, string prezime)
        {
            var radnik = get.GetRadnikByJmbg(jmbg);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(radnik.autobuska_stanica_idstanice != idStanice)
                {
                    radnik.autobuska_stanica_idstanice = idStanice;
                }
                if(radnik.ime != ime)
                {
                    radnik.ime = ime;
                }
                if(radnik.prezime != prezime)
                {
                    radnik.prezime = prezime;
                }
                
                db.Entry(radnik).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateTipKarte(string idTipa, string penzionerska, string studentska, string decija, string odrasli)
        {
            var tip = get.GetTip_KarteById(idTipa);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(tip.penzionerska != penzionerska)
                {
                    tip.penzionerska = penzionerska;
                }
                if(tip.studentska != studentska)
                {
                    tip.studentska = studentska;
                }
                if(tip.decija != decija)
                {
                    tip.decija = decija;
                }
                if(tip.odrasli != odrasli)
                {
                    tip.odrasli = odrasli;
                }

                db.Entry(tip).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateVozac(string jmbg, int broj)
        {
            var vozac = get.GetVozacByJmbg(jmbg);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(vozac.brojvoznihlinija != broj)
                {
                    vozac.brojvoznihlinija = broj;
                }
                

                db.Entry(vozac).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void UpdateVoznaLinija(string idLinije, string polaziste, string odrediste, int vreme)
        {
            var linija = get.GetVoznaLinijaById(idLinije);

            using(var db = new AutobuskaStanicaEntities())
            {
                if(linija.polaziste!=polaziste)
                {
                    linija.polaziste = polaziste;
                }
                if(linija.odrediste != odrediste)
                {
                    linija.vremeputovanja = vreme;
                }

                db.Entry(linija).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
