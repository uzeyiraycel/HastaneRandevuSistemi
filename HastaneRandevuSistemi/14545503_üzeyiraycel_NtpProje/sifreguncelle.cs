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
    public partial class sifreguncelleform : Form
    {
        public sifreguncelleform()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=J:\\14545503_üzeyiraycel_ntpProje\\14545503_üzeyiraycel_NtpProje\\14545503_üzeyiraycel_NtpProje\\hastanerandevu.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter dr = new OleDbDataAdapter();
        private void sifreguncelle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastanerandevusistemiformu anasayfageridonus3 = new hastanerandevusistemiformu();
            anasayfageridonus3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con1 = new SqlBaglanti().yeniBaglanti();
            OleDbCommand komut = new OleDbCommand("update Kullanicilar set kullanici_sifre='"+textBox2.Text+"' where kullanici_tc='"+textBox1.Text+"'", con1);
            komut.ExecuteNonQuery();
            MessageBox.Show("Şifre Güncellemesi Yapıldı ! ");
            con1.Close();
        }
    }
}
