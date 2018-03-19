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

        public bool AddAutobus(string brtablica, int brmesta, string ispravan, string marka)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var autobu = new autobu
                    {
                        brtablica = brtablica,
                        brojmesta = brmesta,
                        ispravan = ispravan,
                        marka = marka
                    };

                    db.autobus.Add(autobu);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool AddStanica(int id, string ime, string grad, string ulica)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
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
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
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
        public bool AddKarta(string id, string jednosmerna, string povratna, string mesecna, string idTipa, string idLinije)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
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

                    db.kartas.Add(karta);
                    db.SaveChanges();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Dodavanje radnika kao mehanicar
        /// </summary>
        /// <param name="jmbg">jmbg vec postojenog radnika</param>
        /// <param name="broj">random broj</param>
        /// <returns></returns>
        public bool AddMehanicar(string jmbg, int broj)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var mehanicar = new mehanicar
                    {
                        jmbg = jmbg,
                        brojpopravljenih = broj
                    };

                    db.mehanicars.Add(mehanicar);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Dodavanje autobusa u odredjenu autobusku stanicu
        /// </summary>
        /// <param name="brojTablica"> Broj tablice autobusa </param>
        /// <param name="idStanice"> ID stanice kojoj pripada autobus</param>
        /// <returns></returns>
        public bool AddPoseduje(string brojTablica, int idStanice)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var poseduje = new poseduje
                    {
                        autobus_brtablica = brojTablica,
                        autobuska_stanica_idstanice = idStanice
                    };

                    db.posedujes.Add(poseduje);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Dodavanje prodavca na osnovu postojeceg radnika
        /// </summary>
        /// <param name="jmbg">jmbg vec postojenog radnika</param>
        /// <param name="broj">neki random broj</param>
        /// <returns></returns>
        public bool AddProdavac(string jmbg, int broj)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var prodavac = new prodavac
                    {
                        jmbg = jmbg,
                        brojsaltera = broj
                    };

                    db.prodavacs.Add(prodavac);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Dodavanje novog putnika
        /// </summary>
        /// <param name="idputnika">neki id za putnika</param>
        /// <param name="ime">neko ime</param>
        /// <param name="idkarte">id vec postojene karte</param>
        /// <returns></returns>
        public bool AddPutnik(int idputnika, string ime, string idkarte)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var putnik = new putnik
                    {
                        idputnika = idputnika,
                        ime = ime,
                        karta_idkarte = idkarte
                    };

                    db.putniks.Add(putnik);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
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
        public bool AddRadnik(int idstanice, string ime, string prezime, string jmbg)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var radnik = new radnik
                    {
                        autobuska_stanica_idstanice = idstanice,
                        ime = ime,
                        prezime = prezime,
                        jmbg = jmbg
                    };

                    db.radniks.Add(radnik);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool AddTipKarte(string idtipa, string penzionerska, string decija, string studentska, string odrasli)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
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
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Pravljenje novih vozaca
        /// </summary>
        /// <param name="jmbg">jmbg vec postojeceg radnika</param>
        /// <param name="broj">neki broj</param>
        /// <returns></returns>
        public bool AddVozac(string jmbg, int broj)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                try
                {
                    var vozac = new vozac
                    {
                        jmbg = jmbg,
                        brojvoznihlinija = broj,
                        
                    };

                    db.vozacs.Add(vozac);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool AddVoznaLinija(string idLinije, string polaziste, string odrediste, int vreme)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                try
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

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
