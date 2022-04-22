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
    public partial class uyeolform : Form
    {
        public uyeolform()
        {
            InitializeComponent();
        }

        //OleDbConnection con;
        //OleDbDataAdapter da;
        ////OleDbCommand cmd;
        //DataSet ds;

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uyeol_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastanerandevusistemiformu anasayfageridonus = new hastanerandevusistemiformu();
            anasayfageridonus.Show();
            this.Hide();
        }
        public static string cinsiyett;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                cinsiyett = "Bay";
            else if (radioButton1.Checked == true)
                cinsiyett = "Bayan";


            OleDbConnection con1 = new SqlBaglanti().yeniBaglanti();
            OleDbCommand komut = new OleDbCommand("insert into Kullanicilar (kullanici_tc,kullanici_adi,kullanici_soyadi,kullanici_cinsiyet,kullanici_yas,kullanici_sifre,kullanici_mail) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + cinsiyett + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "')", con1);
            komut.ExecuteNonQuery();
            MessageBox.Show("Üye Kaydı Yapıldı ");
            con1.Close();
        }
    }
}
