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
        public void DeleteAutobuskaStanica(int id)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var svePoseduje = get.GetAllPoseduje();
                foreach (var v in svePoseduje)
                {
                    if (v.autobuska_stanica_idstanice == id)
                    {
                        db.posedujes.Remove(v);
                    }
                }

                db.autobuska_stanica.Remove(get.GetAutobuska_StanicaById(id));
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteAutobus
        public void DeleteAutobus(string brojTablica)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var svePoseduje = get.GetAllPoseduje();

                foreach (var poseduje in svePoseduje) //zbog gerunda -> autobus vise ne pripada stanici, te se sve njegove funkcije u istoj brisu
                {
                    foreach (var linija in poseduje.vozna_linija) //brise se vozna linija na kojoj je autobus bio
                    {
                        if (linija.posedujes == poseduje)
                        {
                            db.vozna_linija.Remove(linija);
                        }
                    }
                    if (poseduje.autobus_brtablica.Equals(brojTablica))
                    {
                        db.posedujes.Remove(poseduje);
                    }

                }

                db.autobus.Remove(get.GetAutobusById(brojTablica));
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeletePoseduje
        public void DeletePoseduje(string brojTablica, int idStanice)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                var poseduje = get.GetPoseduje(brojTablica, idStanice);

                foreach (var mehanicar in get.GetAllMehanicar())
                {
                    if (mehanicar.posedujes.Contains(poseduje))
                    {
                        mehanicar.posedujes.Remove(poseduje);
                    }
                }

                foreach (var linija in get.GetAllVoznaLinija())
                {
                    if (linija.posedujes.Contains(poseduje))
                    {
                        linija.posedujes.Remove(poseduje);
                    }
                }

                foreach (var autobus in get.GetAllAutobus())
                {
                    if (autobus.posedujes.Contains(poseduje))
                    {
                        autobus.posedujes.Remove(poseduje);
                    }
                }

                foreach (var stanica in get.GetAllAutobuskaStanica())
                {
                    if (stanica.posedujes.Contains(poseduje))
                    {
                        stanica.posedujes.Remove(poseduje);
                    }
                }


                db.posedujes.Remove(poseduje);
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteMehanicar
        public void DeleteMehanicar(string jmbg)
        {
            var mehanicar = get.GetMehanicarByJmbg(jmbg);

            using (var db = new AutobuskaStanicaEntities())
            {
                db.mehanicars.Remove(mehanicar);
                foreach (var poseduje in get.GetAllPoseduje())
                {
                    if (poseduje.mehanicars.Contains(mehanicar))
                    {
                        poseduje.mehanicars.Remove(mehanicar);
                    }
                }

                db.radniks.Remove(get.GetRadnikByJmbg(jmbg));

                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteProdavac
        public void DeleteProdavac(string jmbg)
        {
            var prodavac = get.GetProdavacByJmbg(jmbg);

            using (var db = new AutobuskaStanicaEntities())
            {
                db.prodavacs.Remove(prodavac);

                db.radniks.Remove(get.GetRadnikByJmbg(jmbg));

                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteVozac
        public void DeleteVozac(string jmbg)
        {
            var vozac = get.GetVozacByJmbg(jmbg);

            using (var db = new AutobuskaStanicaEntities())
            {

                foreach (var linije in get.GetAllVoznaLinija()) //ukoliko je imao neku liniju, obrisi vozaca (njega) sa te linije
                {
                    if (linije.vozacs.Contains(vozac))
                    {
                        linije.vozacs.Remove(vozac);
                    }
                }
                db.vozacs.Remove(vozac); //obrisi ga iz tabele vozac
                db.radniks.Remove(get.GetRadnikByJmbg(jmbg)); //obrisi ga iz tabele radnik
                db.SaveChanges();
            }
        } 
        #endregion

        #region DeleteRadnik
        public void DeleteRadnik(string jmbg)
        {
            if (get.GetAllMehanicar().Contains(get.GetMehanicarByJmbg(jmbg)))
            {
                DeleteMehanicar(jmbg);
            }
            else if (get.GetAllProdavac().Contains(get.GetProdavacByJmbg(jmbg)))
            {
                DeleteProdavac(jmbg);
            }
            else if (get.GetAllVozac().Contains(get.GetVozacByJmbg(jmbg)))
            {
                DeleteVozac(jmbg);
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
