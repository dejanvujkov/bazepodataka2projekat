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

        public IEnumerable<int> GetAllAutobuskaStanicaId()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                var sve = db.autobuska_stanica.ToList();
                var ret = new List<int>();

                foreach(var v in sve)
                {
                    ret.Add(v.idstanice);
                }

                return ret;
            }
        }

        public IEnumerable<string> GetAllRadnikJmbg()
        {
            using(var db = new AutobuskaStanicaEntities())
            {
                var sve = db.radniks.ToList();

                var ret = new List<string>();

                foreach (var v in sve)
                {
                    ret.Add(v.jmbg);
                }

                return ret;
            }
        }
    }
}
