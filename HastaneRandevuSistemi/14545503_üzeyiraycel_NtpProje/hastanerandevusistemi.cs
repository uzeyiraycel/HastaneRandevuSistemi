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
    public partial class hastanerandevusistemiformu : Form
    {
        public hastanerandevusistemiformu()
        {
            InitializeComponent();
        }

        
        OleDbCommand cmd;
        OleDbDataReader dr;

        public static string kullaniciid;
        public static string kullanici_tc;

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglantim = new SqlBaglanti().yeniBaglanti();
            cmd = new OleDbCommand();
            cmd.Connection = baglantim;
            cmd.CommandText = "SELECT * FROM Kullanicilar where kullanici_tc='" + textBox1.Text + "' AND kullanici_sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                kullaniciid = dr["kullanici_id"].ToString();
                baglantim.Close();
                randevualform randevual = new randevualform();
                randevual.Show();
                this.Hide();
                kullanici_tc = textBox1.Text;
                
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız veya Kullanıcı Şifreniz Hatalı. Lütfen Kontrol Ediniz !");
            }

            baglantim.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeolform yeniuye = new uyeolform();
            yeniuye.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, new EventArgs { });
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sifreguncelleform sifreguncelle = new sifreguncelleform();
            sifreguncelle.Show();
            this.Hide();
        }
    }
}
