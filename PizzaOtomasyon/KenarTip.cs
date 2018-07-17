using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyon
{
   public class KenarTip
    {
        public string  KenarAdi { get; set; }
        public int EkFİyat { get; set; }

        public override string ToString()
        {
            return KenarAdi;
        }
    }
}
