using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class AddAccess
    {

        public AddAccess() { }

        public void AddAutobus(string brtablica, int brmesta, string ispravan, string marka, int kilometri)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var autobu = new autobu
                {
                    brtablica = brtablica,
                    brojmesta = brmesta,
                    ispravan = ispravan,
                    marka = marka,
                    kilometri = kilometri
                };

                db.autobus.Add(autobu);
                db.SaveChanges();

            }
        }

        public void AddStanica(int id, string ime, string grad, string ulica)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var stanica = new autobuska_stanica
                {
                    idstanice = id,
                    ime = ime,
                    grad = grad,
                    ulica = ulica
                };

                db.autobuska_stanica.Add(stanica);
                db.SaveChanges();

            }
        }
        /// <summary>
        /// Dodavanje karte
        /// </summary>
        /// <param name="id">neki id</param>
        /// <param name="jednosmerna">da li jeste ili nije</param>
        /// <param name="povratna">da li jeste ili nije</param>
        /// <param name="mesecna">da li jeste ili nije</param>
        /// <param name="idTipa">id vec postojenog tipa</param>
        /// <param name="idLinije">id postojane linije</param>
        /// <returns></returns>
        public void AddKarta(string id, string jednosmerna, string povratna, string mesecna, string idTipa, string idLinije)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var karta = new karta
                {
                    idkarte = id,
                    jednosmerna = jednosmerna,
                    povratna = povratna,
                    mesecna = mesecna,
                    tip_karte_idtipa = idTipa,
                    vozna_linija_idlinije = idLinije
                };
                var tip = db.tip_karte.FirstOrDefault(t => t.idtipa.Equals(idTipa));
                tip.kartas.Add(karta);

                var linija = db.vozna_linija.FirstOrDefault(l => l.idlinije.Equals(idLinije));
                linija.kartas.Add(karta);

                db.kartas.Add(karta);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Dodavanje radnika kao mehanicar
        /// </summary>
        /// <param name="jmbg">jmbg vec postojenog radnika</param>
        /// <param name="broj">random broj</param>
        /// <returns></returns>
        public void AddMehanicar(string jmbg, int broj)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var mehanicar = new mehanicar
                {
                    jmbg = jmbg,
                    brojpopravljenih = broj
                };
                
                db.mehanicars.Add(mehanicar);
            }
        }
        /// <summary>
        /// Dodavanje autobusa u odredjenu autobusku stanicu
        /// </summary>
        /// <param name="brojTablica"> Broj tablice autobusa </param>
        /// <param name="idStanice"> ID stanice kojoj pripada autobus</param>
        /// <returns></returns>
        public void AddPoseduje(string brojTablica, int idStanice)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var poseduje = new poseduje
                {
                    autobus_brtablica = brojTablica,
                    autobuska_stanica_idstanice = idStanice
                };

                var autobus = db.autobus.FirstOrDefault(a => a.brtablica.Equals(brojTablica));
                autobus.posedujes.Add(poseduje);

                poseduje.autobu = autobus;

                var stanica = db.autobuska_stanica.FirstOrDefault(s => s.idstanice.Equals(idStanice));
                stanica.posedujes.Add(poseduje);

                poseduje.autobuska_stanica = stanica;
                

                db.posedujes.Add(poseduje);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Dodavanje prodavca na osnovu postojeceg radnika
        /// </summary>
        /// <param name="jmbg">jmbg vec postojenog radnika</param>
        /// <param name="broj">neki random broj</param>
        /// <returns></returns>
        public void AddProdavac(string jmbg, int broj)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var prodavac = new prodavac
                {
                    jmbg = jmbg,
                    brojsaltera = broj
                };

                db.prodavacs.Add(prodavac);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Dodavanje novog putnika
        /// </summary>
        /// <param name="idputnika">neki id za putnika</param>
        /// <param name="ime">neko ime</param>
        /// <param name="idkarte">id vec postojene karte</param>
        /// <returns></returns>
        public void AddPutnik(int idputnika, string ime, string idkarte)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var putnik = new putnik
                {
                    idputnika = idputnika,
                    ime = ime,
                    karta_idkarte = idkarte
                };

                var karta = db.kartas.FirstOrDefault(k => k.idkarte.Equals(idkarte));
                karta.putniks.Add(putnik);

                db.putniks.Add(putnik);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Dodavanje novog radnika
        /// </summary>
        /// <param name="idstanice">id vec postojene autobuske stanice</param>
        /// <param name="ime">ime radnika</param>
        /// <param name="prezime">prezime radnika</param>
        /// <param name="jmbg">jmbg radnika</param>
        /// <returns></returns>
        public void AddRadnik(int idstanice, string ime, string prezime, string jmbg)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var radnik = new radnik
                {
                    autobuska_stanica_idstanice = idstanice,
                    ime = ime,
                    prezime = prezime,
                    jmbg = jmbg
                };

                db.radniks.Add(radnik);
                var stanica = db.autobuska_stanica.FirstOrDefault(s => s.idstanice.Equals(idstanice));
                stanica.radniks.Add(radnik);

                db.SaveChanges();

            }
        }

        public void AddTipKarte(string idtipa, string penzionerska, string decija, string studentska, string odrasli)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var tip = new tip_karte
                {
                    idtipa = idtipa,
                    penzionerska = penzionerska,
                    decija = decija,
                    studentska = studentska,
                    odrasli = odrasli
                };

                db.tip_karte.Add(tip);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Pravljenje novih vozaca
        /// </summary>
        /// <param name="jmbg">jmbg vec postojeceg radnika</param>
        /// <param name="broj">neki broj</param>
        /// <returns></returns>
        public void AddVozac(string jmbg, int broj)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var vozac = new vozac
                {
                    jmbg = jmbg,
                    brojvoznihlinija = broj,

                };

                db.vozacs.Add(vozac);
                db.SaveChanges();
            }
        }

        public void AddVoznaLinija(string idLinije, string polaziste, string odrediste, int vreme)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var linija = new vozna_linija
                {
                    idlinije = idLinije,
                    polaziste = polaziste,
                    odrediste = odrediste,
                    vremeputovanja = vreme
                };

                db.vozna_linija.Add(linija);
                db.SaveChanges();
            }
        }

        public void AddVozi(string vozacJmbg, string idVozneLinije)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var linija = db.vozna_linija.FirstOrDefault(l => l.idlinije.Equals(idVozneLinije));
                var vozac = db.vozacs.FirstOrDefault(v => v.jmbg.Equals(vozacJmbg));
                linija.vozacs.Add(vozac);
                vozac.vozna_linija.Add(linija);
                db.SaveChanges();
            }
        }

        public void AddPopravlja(string mehanicarJmbg, string posedujeIdStanice, string posedujeIdTablica)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var mehanicar = db.mehanicars.FirstOrDefault(m => m.jmbg.Equals(mehanicarJmbg));
                var poseduje = db.posedujes.FirstOrDefault(p => p.autobuska_stanica_idstanice.Equals(posedujeIdStanice) && p.autobus_brtablica.Equals(posedujeIdTablica));

                mehanicar.posedujes.Add(poseduje);
                poseduje.mehanicars.Add(mehanicar);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Dodavanje autobusa na neku voznu liniju
        /// </summary>
        /// <param name="idLinije">id vozne linije</param>
        /// <param name="posedujeIdStanice">poseduje_idstanice</param>
        /// <param name="posedujeIdTablica">poseduje_brtablica</param>
        public void AddKoji(string idLinije, string posedujeIdStanice, string posedujeIdTablica)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var linija = db.vozna_linija.FirstOrDefault(l => l.idlinije.Equals(idLinije));
                var poseduje = db.posedujes.FirstOrDefault(p => p.autobuska_stanica_idstanice.Equals(posedujeIdStanice) && p.autobus_brtablica.Equals(posedujeIdTablica));

                linija.posedujes.Add(poseduje);
                poseduje.vozna_linija.Add(linija);

                db.SaveChanges();
            }
        }
    }
}
