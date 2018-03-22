using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class RezultatFunkcije
    {

        public int IdStanice { get; set; }

        public int BrojZaposlednih { get; set; }

        public RezultatFunkcije()
        {

        }

        public RezultatFunkcije(int idstanice, int brojzaposlenih)
        {
            IdStanice = idstanice;
            BrojZaposlednih = brojzaposlenih;
        }
    }
}
