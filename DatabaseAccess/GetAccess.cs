using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class GetAccess
    {

        public GetAccess() { }

        public autobuska_stanica GetAutobuska_StanicaById(int idStanice)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.autobuska_stanica.FirstOrDefault(s => s.idstanice.Equals(idStanice));
            }
        }

        public autobu GetAutobusById(string brojTablica)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.autobus.FirstOrDefault(a => a.brtablica.Equals(brojTablica));
            }
        }

        public karta GetKartaById(string id)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.kartas.FirstOrDefault(k => k.idkarte.Equals(id));
            }
        }

        public radnik GetRadnikByJmbg(string jmbg)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.radniks.FirstOrDefault(r => r.jmbg.Equals(jmbg));
            }
        }

        public tip_karte GetTip_KarteById(string id)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.tip_karte.FirstOrDefault(t => t.idtipa.Equals(id));
            }
        }

        public List<int> GetAllAutobuskaStanicaId()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                var sve = GetAllAutobuskaStanica();
                var ret = new List<int>();

                foreach(var v in sve)
                {
                    ret.Add(v.idstanice);
                }

                return ret;
            }
        }
        
        public List<string> GetAllRadnikJmbg()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                var sve = GetAllRadnik();

                var ret = new List<string>();

                foreach (var v in sve)
                {
                    ret.Add(v.jmbg);
                }

                return ret;
            }
        }

        public List<autobu> GetAllAutobus()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.autobus.ToList();
            }
        }

        public List<autobuska_stanica> GetAllAutobuskaStanica()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.autobuska_stanica.ToList();
            }
        }

        public List<karta> GetAllKarte()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.kartas.ToList();
            }
        }

        public List<mehanicar> GetAllMehanicar()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.mehanicars.ToList();
            }
        }

        public List<poseduje> GetAllPoseduje()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.posedujes.ToList();
            }
        }

        public List<prodavac> GetAllProdavac()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.prodavacs.ToList();
            }
        }

        public List<putnik> GetAllPutnik()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.putniks.ToList();
            }
        }

        public List<radnik> GetAllRadnik()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.radniks.ToList();
            }
        }

        public List<tip_karte> GetAllTipKarte()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.tip_karte.ToList();
            }
        }

        public List<vozac> GetAllVozac()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.vozacs.ToList();
            }
        }

        public List<vozna_linija> GetAllVoznaLinija()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.vozna_linija.ToList();
            }
        }

        public mehanicar GetMehanicarByJmbg(string jmbg)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.mehanicars.FirstOrDefault(m => m.jmbg.Equals(jmbg));
            }
        }

        public prodavac GetProdavacByJmbg(string jmbg)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.prodavacs.FirstOrDefault(m => m.jmbg.Equals(jmbg));
            }
        }

        public vozac GetVozacByJmbg(string jmbg)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.vozacs.FirstOrDefault(m => m.jmbg.Equals(jmbg));
            }
        }

        public putnik GetPutnikById(int id)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.putniks.FirstOrDefault(m => m.idputnika.Equals(id));
            }
        }

        public vozna_linija GetVoznaLinijaById(string id)
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                return db.vozna_linija.FirstOrDefault(l => l.idlinije.Equals(id));
            }
        }

        public poseduje GetPoseduje(string brojTablica, int idStanice)
        {
            using (var db = new AutobuskaStanicaEntities())
            {
                return db.posedujes.FirstOrDefault(p => p.autobus_brtablica.Equals(brojTablica) && p.autobuska_stanica_idstanice.Equals(idStanice));
            }
        }

    }
}
