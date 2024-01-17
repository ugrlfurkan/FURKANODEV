using OkulApp.BLL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.OkulAppSube2BLG
{
    public partial class frmOgrKayit : Form
    {
        public int Ogrenciid { get; set; }
        public frmOgrKayit()
        {
            InitializeComponent();

                txtAd.TextChanged += TextChangedHandler;
                txtSoyad.TextChanged += TextChangedHandler;
                txtNumara.TextChanged += TextChangedHandler;

               
                btnKaydet.Enabled = false;
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
            }

            private void TextChangedHandler(object sender, EventArgs e)
            {
                
                btnKaydet.Enabled = !String.IsNullOrEmpty(txtAd.Text) && !String.IsNullOrEmpty(txtSoyad.Text) && !String.IsNullOrEmpty(txtNumara.Text);
                btnSil.Enabled = !String.IsNullOrEmpty(txtAd.Text) && !String.IsNullOrEmpty(txtSoyad.Text) && !String.IsNullOrEmpty(txtNumara.Text);
                btnGuncelle.Enabled = !String.IsNullOrEmpty(txtAd.Text) && !String.IsNullOrEmpty(txtSoyad.Text) && !String.IsNullOrEmpty(txtNumara.Text);
        }


        


        //Dispose
        //Garbage Collector
        public void btnKaydet_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                //var ogrenci = new Ogrenci();
                //ogrenci.Ad = txtAd.Text.Trim();
                //ogrenci.Soyad = txtSoyad.Text.Trim();
                //ogrenci.Numara = txtNumara.Text.Trim();

                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme başarılı!" : "Ekleme başarısız!!");

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtNumara.Text = "";

            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!!");
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            var frm = new frmOgrBul(this);
            frm.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {

          
            var obl = new OgrenciBL();
            MessageBox.Show(obl.OgrenciSil(Ogrenciid) ? "Silme Başarılı" : "Başarısız!");
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtNumara.Text = "";

            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
}

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {

           
            var obl = new OgrenciBL();
            MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid }) ? "Güncelleme Başarılı" : "Güncelleme Başarısız!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

   
}

//n Katmanlı Mimari

//Öğrenci bulunma durumuna göre Sil ve Güncelle Butonları Aktifliği --------- TAMAM
//Textbox'ların text'lerinin temizlenmesi -------- TAMAM
//Öğrenci bulunduğunda bul formunun kapanması ------- TAMAM
//Try-Catch'ler Katmanlar arası exception yönetimi  ------ TAMAM
//Dispose Pattern - IDisposeble Interface
//Singleton Design Pattern
