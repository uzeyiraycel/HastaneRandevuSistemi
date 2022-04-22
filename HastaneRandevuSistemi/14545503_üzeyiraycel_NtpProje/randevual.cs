using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _14545503_üzeyiraycel_NtpProje
{
    public partial class randevualform : Form
    {
        public static string secilen_doktor;
        public randevualform()
        {
            InitializeComponent();
            secilen_doktor = null;
        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        protected override void OnLoad(EventArgs e)
        {
            con = new SqlBaglanti().yeniBaglanti();

            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select poliklinik_adi from Poliklinikler";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string gelenKlinik = dr["poliklinik_adi"].ToString();
                if (!comboBox1.Items.Contains(gelenKlinik))
                {
                    comboBox1.Items.Add(gelenKlinik);
                }
            }
            con.Close();

        }
        public static string poliklinik_adi;
        public static string doktor_adi_soyadi;

        private void randevual_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                if (comboBox2.SelectedIndex!=-1)
                {
                    poliklinik_adi = comboBox1.Text;
                    doktor_adi_soyadi = comboBox2.Text;
                    secilen_doktor = comboBox2.SelectedItem.ToString();
                    randevual2form randevual2 = new randevual2form();
                    randevual2.Show();
                    this.Hide();
                }
                else MessageBox.Show("Lütfen doktor seçimi yapınız");
            }
            else MessageBox.Show("Lütfen poliklinik seçimi yapınız");

        }

        private void Polikliniklercombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                comboBox2.Items.Clear();
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastanerandevu.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Poliklinikler where poliklinik_adi=@k_adi";
                cmd.Parameters.AddWithValue("@k_adi", comboBox1.SelectedItem.ToString());
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    string gelenDoktorAdi = string.Format("{0}-[{1}]", dr["doktor_adi_soyadi"].ToString(), dr["doktor_id"].ToString());
                    if (!comboBox2.Items.Contains(gelenDoktorAdi))
                    {
                        comboBox2.Items.Add(gelenDoktorAdi);
                    }
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastanerandevusistemiformu anasayfayageridonus2 = new hastanerandevusistemiformu();
            anasayfayageridonus2.Show();
            this.Hide();
        }

        private void doktorcombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                secilen_doktor = comboBox2.SelectedItem.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1)
            {
                comboBox2.Items.Clear();
                string secilenPoliklinik = comboBox1.SelectedItem.ToString();
                OleDbConnection baglantim = new SqlBaglanti().yeniBaglanti();
                OleDbCommand komut = new OleDbCommand("Select*From Poliklinikler Where poliklinik_adi=@secilenp", baglantim);
                komut.Parameters.AddWithValue("@secilenp", secilenPoliklinik);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    string gelenDoktorAdi = string.Format("{0}-[{1}]", okuyucu["doktor_adi_soyadi"].ToString(), okuyucu["doktor_id"].ToString()); 
                    comboBox2.Items.Add(gelenDoktorAdi);
                }
                baglantim.Close();
            }
        }
    }
}
