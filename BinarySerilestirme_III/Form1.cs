using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySerilestirme_III
{
    public partial class Form1 : Form
    {
        private List<Urun> urunListe = new List<Urun>();

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void AyarlariKaydet()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("settings.dat", FileMode.Create);
            formatter.Serialize(fs, urunListe);
            fs.Close();
            fs.Dispose();
        }
        List<Urun> AyarlariYukle()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("settings.dat", FileMode.Open);
            List<Urun> yuklenenListe = (List<Urun>)formatter.Deserialize(fs);
            fs.Close();
            fs.Dispose();
            return yuklenenListe;
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            AyarlariKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            urunListe.Remove(listBox1.SelectedItem);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var urun = new Urun(Convert.ToInt32(txtUrunID.Text), txtUrunAdi.Text, Convert.ToDouble(txtFiyat.Text));
            urunListe.Add(urun);

            lstUrunler.Items.Add(urun);
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            var urunler = AyarlariYukle();

            lstUrunler.DataSource = urunler;
            lstUrunler.DisplayMember = "UrunAd";
            lstUrunler.ValueMember = "UrunId";
        }
    }
}
