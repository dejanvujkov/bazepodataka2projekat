using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace DatabaseAccess
{
    public class DeleteAccess
    {
        private GetAccess get;
        public DeleteAccess()
        {
            get = new GetAccess();
        }

        #region DeleteStanica
        public void DeleteAutobuskaStanica(autobuska_stanica stanica)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var svePoseduje = get.GetAllPoseduje();
                foreach (var v in svePoseduje)
                {
                    if (v.autobuska_stanica_idstanice == stanica.idstanice)
                    {
                        db.posedujes.Attach(v);
                        db.posedujes.Remove(v);
                    }
                }

                var sviRadnici = get.GetAllRadnik();
                foreach(var radnik in sviRadnici)
                {
                    if (radnik.autobuska_stanica_idstanice == stanica.idstanice)
                    {
                        DeleteRadnik(radnik);
                    }
                }
                db.autobuska_stanica.Attach(stanica);
                db.autobuska_stanica.Remove(stanica);
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteAutobus
        public void DeleteAutobus(autobu autobus)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var svePoseduje = db.posedujes.ToList();

                foreach (var poseduje in svePoseduje) //zbog gerunda -> autobus vise ne pripada stanici, te se sve njegove funkcije u istoj brisu
                {
                    foreach (var linija in poseduje.vozna_linija) //brise se vozna linija na kojoj je autobus bio
                    {
                        if (linija.posedujes == poseduje)
                        {
                            db.vozna_linija.Attach(linija);
                            db.vozna_linija.Remove(linija);
                        }
                    }
                    if (poseduje.autobus_brtablica.Equals(autobus.brtablica))
                    {
                        db.posedujes.Attach(poseduje);
                        db.posedujes.Remove(poseduje);
                    }

                }

                db.autobus.Attach(autobus);
                db.autobus.Remove(autobus);
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeletePoseduje
        public void DeletePoseduje(poseduje poseduje)
        {
            using (var db = new AutobuskaStanicaEntities())
            {

                var sviMehanicari = db.mehanicars.ToList();
                foreach (var mehanicar in sviMehanicari)
                {
                    if (mehanicar.posedujes.Contains(poseduje))
                    {
                        mehanicar.posedujes.Remove(poseduje);
                    }
                }

                var sveLinije = db.vozna_linija.ToList();
                foreach (var linija in sveLinije)
                {
                    if (linija.posedujes.Contains(poseduje))
                    {
                        linija.posedujes.Remove(poseduje);
                    }
                }

                var sviAutobusi = db.autobus.ToList();
                foreach (var autobus in sviAutobusi)
                {
                    if (autobus.posedujes.Contains(poseduje))
                    {
                        autobus.posedujes.Remove(poseduje);
                    }
                }

                var sveStanice = db.autobuska_stanica.ToList();
                foreach (var stanica in sveStanice)
                {
                    if (stanica.posedujes.Contains(poseduje))
                    {
                        stanica.posedujes.Remove(poseduje);
                    }
                }
                //TODO: Exception
                db.posedujes.Attach(poseduje);
                db.posedujes.Remove(poseduje);
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteMehanicar
        public void DeleteMehanicar(radnik radnik)
        {
            var mehanicar = get.GetMehanicarByJmbg(radnik.jmbg);

            using (var db = new AutobuskaStanicaEntities())
            {
                db.mehanicars.Attach(mehanicar);
                db.mehanicars.Remove(mehanicar);
                foreach (var poseduje in get.GetAllPoseduje())
                {
                    if (poseduje.mehanicars.Contains(mehanicar))
                    {
                        poseduje.mehanicars.Remove(mehanicar);
                    }
                }
                db.radniks.Attach(radnik);
                db.radniks.Remove(radnik);

                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteProdavac
        public void DeleteProdavac(radnik radnik)
        {
            var prodavac = get.GetProdavacByJmbg(radnik.jmbg);

            using (var db = new AutobuskaStanicaEntities())
            {
                db.prodavacs.Attach(prodavac);
                db.prodavacs.Remove(prodavac);

                db.radniks.Attach(radnik);
                db.radniks.Remove(radnik);

                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteVozac
        public void DeleteVozac(radnik radnik)
        {
            var vozac = get.GetVozacByJmbg(radnik.jmbg);

            using (var db = new AutobuskaStanicaEntities())
            {

                foreach (var linije in get.GetAllVoznaLinija()) //ukoliko je imao neku liniju, obrisi vozaca (njega) sa te linije
                {
                    if (linije.vozacs.Contains(vozac))
                    {
                        linije.vozacs.Remove(vozac);
                    }
                }
                db.vozacs.Attach(vozac);
                db.vozacs.Remove(vozac); //obrisi ga iz tabele vozac
                
                db.radniks.Attach(radnik);
                db.radniks.Remove(radnik); //obrisi ga iz tabele radnik
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteRadnik
        public void DeleteRadnik(radnik radnik)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var sviMehanicari = db.mehanicars.ToList();
                var mehanicar = db.mehanicars.FirstOrDefault(m => m.jmbg.Equals(radnik.jmbg));

                if (sviMehanicari.Contains(mehanicar))
                {
                    DeleteMehanicar(radnik);
                    return;
                }

                var sviProdavci = db.prodavacs.ToList();
                var prodavac = db.prodavacs.FirstOrDefault(m => m.jmbg.Equals(radnik.jmbg));

                if (sviProdavci.Contains(prodavac))
                {
                    DeleteProdavac(radnik);
                    return;
                }

                var sviVozaci = db.vozacs.ToList();
                var vozac = db.vozacs.FirstOrDefault(m => m.jmbg.Equals(radnik.jmbg));

                if (sviVozaci.Contains(vozac))
                {
                    DeleteVozac(radnik);
                    return;
                }

            
                db.radniks.Attach(radnik);
                db.radniks.Remove(radnik);
                db.SaveChanges();
            }
        }
        #endregion

        #region DeletePutnik
        public void DeletePutnik(int id)
        {
            var putnik = get.GetPutnikById(id);

            foreach (var karta in get.GetAllKarte())
            {
                if (karta.putniks.Contains(putnik))
                {
                    karta.putniks.Remove(putnik);
                }
            }

            using (var db = new AutobuskaStanicaEntities())
            {
                db.putniks.Remove(putnik);

                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteKarta
        public void DeleteKarta(string id)
        {
            var karta = get.GetKartaById(id);

            foreach (var prodavac in get.GetAllProdavac())
            {
                if (prodavac.kartas.Contains(karta))
                {
                    prodavac.kartas.Remove(karta);
                }
            }

            foreach (var linija in get.GetAllVoznaLinija())
            {
                if (linija.kartas.Contains(karta))
                {
                    linija.kartas.Remove(karta);
                }
            }

            foreach (var tip in get.GetAllTipKarte())
            {
                if (tip.kartas.Contains(karta))
                {
                    tip.kartas.Remove(karta);
                }
            }

            using (var db = new AutobuskaStanicaEntities())
            {
                foreach (var putnik in get.GetAllPutnik())
                {
                    if (putnik.karta_idkarte.Equals(id))
                    {
                        db.putniks.Remove(putnik);
                    }
                }

                db.kartas.Remove(karta);
                db.SaveChanges();
            }
        }
        #endregion

        #region DeleteTipKarte
        public void DeleteTipKarte(string id)
        {
            var tip = get.GetTip_KarteById(id);

            foreach (var karta in get.GetAllKarte())
            {
                if (karta.tip_karte_idtipa.Equals(id))
                {
                    DeleteKarta(karta.idkarte);
                }
            }

            using (var db = new AutobuskaStanicaEntities())
            {
                db.tip_karte.Remove(tip);
                db.SaveChanges();
            }
        }
        #endregion

        #region DeleteVoznaLinija
        public void DeleteVoznaLinija(string idLinije)
        {
            var linija = get.GetVoznaLinijaById(idLinije);

            foreach (var poseduje in get.GetAllPoseduje())
            {
                if (poseduje.vozna_linija.Contains(linija))
                {
                    poseduje.vozna_linija.Remove(linija);
                }
            }

            foreach (var vozac in get.GetAllVozac())
            {
                if (vozac.vozna_linija.Contains(linija))
                {
                    vozac.vozna_linija.Remove(linija);
                }
            }

            using (var db = new AutobuskaStanicaEntities())
            {
                foreach (var karta in get.GetAllKarte())
                {
                    if (karta.vozna_linija_idlinije.Equals(idLinije))
                    {
                        DeleteKarta(karta.idkarte);
                    }
                }
                db.vozna_linija.Remove(linija);
                db.SaveChanges();
            }
        } 
        #endregion
    }
}
