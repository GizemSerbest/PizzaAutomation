using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucukEbat = new Ebat { Adi = "Küçük", Carpan = 1 };
            Ebat ortaEbat = new Ebat { Adi = "Orta", Carpan = 1.25 };
            Ebat buyukEbat = new Ebat { Adi = "Büyük", Carpan = 1.75 };
            Ebat maxiEbat = new Ebat { Adi = "Maxi", Carpan = 2 };

            cmbebatlar.Items.Add(kucukEbat);
            cmbebatlar.Items.Add(ortaEbat);
            cmbebatlar.Items.Add(buyukEbat);
            cmbebatlar.Items.Add(maxiEbat);

            Pizza klasik = new Pizza { Ad = "Klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Ad = "Karışık", Fiyat = 17 };
            Pizza turkish = new Pizza { Ad = "Türk Usulü", Fiyat = 20 };
            Pizza tuna = new Pizza { Ad = "Tuna", Fiyat = 21 };
            Pizza akdeniz = new Pizza { Ad = "Akdeniz", Fiyat = 19 };
            Pizza karadeniz = new Pizza { Ad = "Karadeniz", Fiyat = 22 };

            lstpizzalar.Items.Add(klasik);
            lstpizzalar.Items.Add(karisik);
            lstpizzalar.Items.Add(turkish);
            lstpizzalar.Items.Add(tuna);
            lstpizzalar.Items.Add(akdeniz);
            lstpizzalar.Items.Add(karadeniz);

            KenarTip ince = new KenarTip { KenarAdi = "İnce Kenar", EkFİyat = 0 };
            rdbince.Tag = ince;
            KenarTip kalin = new KenarTip { KenarAdi = "Kalın Kenar", EkFİyat = 2 };
            rdbkalin.Tag = kalin;




        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza p = (Pizza)lstpizzalar.SelectedItem;
            p.Ebati = (Ebat)cmbebatlar.SelectedItem;
            p.KenarTipi = rdbince.Checked ? (KenarTip)rdbince.Tag : (KenarTip)rdbkalin.Tag;
            p.Malzemeler = new List<string>();
            foreach (CheckBox malzeme in groupBox1.Controls)
            {
                if (malzeme.Checked) {
                p.Malzemeler.Add(malzeme.Text);
                }

            }
               decimal tutar = p.Tutar * nudadet.Value;

            txtTutar.Text = tutar.ToString();

            s = new SiparisDurum();
            foreach (CheckBox item in groupBox1.Controls)
            {
                item.Checked = false;
            }
            s.Pizza = p;
            s.SepetAdet = (int)nudadet.Value;
        }
        SiparisDurum s;
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (s != null)
            {
                lstSepet.Items.Add(s);
            }
        }

        private void btnsiparisOnayla_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int sayac = 0;
            foreach (SiparisDurum  spr in lstSepet.Items)
            {
                toplamTutar += (spr.SepetAdet * spr.Pizza.Tutar);
                sayac++;
            }
            lblToplamTutar.Text = toplamTutar.ToString();
            MessageBox.Show(string.Format("Toplam sipariş adetiniz: {0} \n Toplam sipariş tutarınız : {1}",sayac,toplamTutar));
        }
    }
}
