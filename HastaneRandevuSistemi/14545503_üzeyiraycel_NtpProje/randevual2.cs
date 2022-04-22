using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14545503_üzeyiraycel_NtpProje
{
    public partial class randevual2form : Form
    {
        public randevual2form()
        {
            InitializeComponent();
        }
        public string doktorid { get; set; }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public void YeniRandevu(string saat,string did,string kullanciid)
        {
            OleDbConnection baglanti = new SqlBaglanti().yeniBaglanti();
            OleDbCommand komut = new OleDbCommand("Insert into Randevular(DoktorID,Tarih,Saat,KullaniciID) Values(@did,@tarih,@saat,@kid)", baglanti);
            komut.Parameters.AddWithValue("@did", int.Parse(did));
            komut.Parameters.AddWithValue("@tarih", DateTime.Parse(dateTimePicker1.Value.ToString()));
            komut.Parameters.AddWithValue("@saat", saat);
            komut.Parameters.AddWithValue("@kid", int.Parse(kullanciid));

            komut.ExecuteNonQuery();
            GuncelRandevular();
        }
        private void randevual2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            GuncelRandevular();

            label3.Text = (randevualform.secilen_doktor.ToString());
            string secilenDoktor = randevualform.secilen_doktor.ToString();
            string doktorID = secilenDoktor.Remove(0, secilenDoktor.IndexOf("[")).Replace("[", "").Replace("]", "");
            this.doktorid = doktorID;
            button13.Visible = true;

            con = new SqlBaglanti().yeniBaglanti();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Listeler where doktor_adi_soyadi like '%@d%';";
            string tarihVerisi = string.Format("{0}", dateTimePicker1.Value.ToShortDateString());

            
            cmd.Parameters.AddWithValue("@d", string.Format($"[{doktorID.ToString()}]"));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string saat = dr["randevu_saat"].ToString();
                foreach (Control item in this.Controls)
                {
                    try
                    {
                        if (item != null)
                        {
                            if ((item is Button) && item.Tag.ToString() == "rsaati")
                            {
                                if (item.Text == saat)
                                {
                                    item.BackColor = Color.Red; item.Enabled = false;
                                   
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
            }
            con.Close();
        }

       

        private void button14_Click(object sender, EventArgs e)
        {
            OleDbConnection con1 = new SqlBaglanti().yeniBaglanti();
            //con1.Open();
            OleDbCommand komut = new OleDbCommand("Insert into Listeler(kullanici_tc,Poliklinik_adi,doktor_adi_soyadi,randevu_tarihi,randevu_saat)Values(@tc,@klink,@doktor,@tarih,@saat)", con1);
            komut.Parameters.AddWithValue("@tc",int.Parse(hastanerandevusistemiformu.kullanici_tc.ToString()));
            komut.Parameters.AddWithValue("@klink", randevualform.poliklinik_adi);
            komut.Parameters.AddWithValue("@doktor", randevualform.doktor_adi_soyadi);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
            komut.Parameters.AddWithValue("@saat", label4.Text);
            komut.ExecuteNonQuery();
            con1.Close();
            button14.Visible = false;
            button13.Visible = true;
        }

        public void GuncelRandevular()
        {
            foreach (Control item in this.Controls)
            {
                try
                {
                    if (item.Tag.ToString() == "rsaati")
                    {
                        ((Button)item).BackColor = SystemColors.ButtonHighlight;
                        ((Button)item).Enabled = true;
                    }
                    else continue;
                }
                catch (Exception)
                {

                    continue;
                }
            }
            OleDbConnection con1 = new SqlBaglanti().yeniBaglanti();
            OleDbCommand komut = new OleDbCommand("Select*from Listeler where doktor_adi_soyadi=@doktor and randevu_tarihi=@tarih", con1);
            komut.Parameters.AddWithValue("@doktor", randevualform.doktor_adi_soyadi);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
            OleDbDataReader okuyucu = komut.ExecuteReader();

            while (okuyucu.Read())
            {
                string saat = (okuyucu["randevu_saat"].ToString());
                foreach (Control item in this.Controls)
                {
                    if (item.Text == saat)
                    {
                        ((Button)item).BackColor = Color.Gray;
                        ((Button)item).Enabled = false;
                    }
                    else continue;
                }
            }

            con1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RandevuAlAction(button11);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            randevualform randevualgeridonus = new randevualform();
            randevualgeridonus.Show();
            this.Hide();
        }

       

        public void RandevuAlAction(Button btnRef)
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    try
                    {
                        if (item.Tag.ToString() != null && item.Tag.ToString() == "rsaati")
                        {
                            if (btnRef.Text == item.Text)
                            {
                                if (btnRef.BackColor == Color.Red)
                                {
                                    ((Button)btnRef).BackColor = Color.Green;
                                }
                                else if (btnRef.BackColor == Color.Green)
                                {
                                    ((Button)btnRef).BackColor = Color.Red;
                                }
                                label4.Text = btnRef.Text.ToString();

                            }
                            else if (btnRef.Text != item.Text)
                            {
                                if (item.BackColor != Color.Gray)
                                {
                                    ((Button)item).BackColor = Color.Green;
                                }

                            }

                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        public void SaatlerTemizle()
        {
            button1.BackColor = SystemColors.ButtonHighlight; button1.Enabled = true;
            button2.BackColor = SystemColors.ButtonHighlight; button2.Enabled = true;
            button3.BackColor = SystemColors.ButtonHighlight; button3.Enabled = true;
            button4.BackColor = SystemColors.ButtonHighlight; button4.Enabled = true;
            button5.BackColor = SystemColors.ButtonHighlight; button5.Enabled = true;
            button6.BackColor = SystemColors.ButtonHighlight; button6.Enabled = true;
            button7.BackColor = SystemColors.ButtonHighlight; button7.Enabled = true;
            button8.BackColor = SystemColors.ButtonHighlight; button8.Enabled = true;
            button9.BackColor = SystemColors.ButtonHighlight; button9.Enabled = true;
            button10.BackColor = SystemColors.ButtonHighlight; button10.Enabled = true;
            button11.BackColor = SystemColors.ButtonHighlight; button11.Enabled = true;

        }
        protected override void OnValidated(EventArgs e)
        {
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            //SaatlerTemizle();
            GuncelRandevular();


        }

        public void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            base.OnValidated(e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            randevugoruntuleform randevugoruntule = new randevugoruntuleform();
            randevugoruntule.Show();
            this.Hide();
        }
    }
}
