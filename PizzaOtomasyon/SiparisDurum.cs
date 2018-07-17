using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyon
{
  public  class SiparisDurum
    {
        public int SepetAdet { get; set; }
        public Pizza Pizza { get; set; }
      

        public override string ToString()
        {
            string spr = " ";

            spr += Pizza.Ebati.Adi+",";
            spr += Pizza.KenarTipi + ",";
            spr += Pizza.Ad+ ",";

            foreach (string mlz in Pizza.Malzemeler)
            {
                spr += string.Format("{0},", mlz);
            }

            spr = spr.Remove(spr.Length - 1, 1);
            spr += string.Format("{0} x {1} = {2}", SepetAdet,Pizza.Tutar,SepetAdet*Pizza.Tutar);

            return spr;
        }
    }
}
