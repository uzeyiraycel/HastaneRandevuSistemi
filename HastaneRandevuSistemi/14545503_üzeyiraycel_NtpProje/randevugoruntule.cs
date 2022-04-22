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
    public partial class randevugoruntuleform : Form
    {
        //OleDbConnection con1 = null;
        //DataTable tablo = new DataTable();
        //OleDbCommand cmd = new OleDbCommand();
        //OleDbDataAdapter dr = new OleDbDataAdapter();
        public randevugoruntuleform()
        {
            InitializeComponent();
        }

        private void randevugoruntule_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            randevual2form randevual2geridonus = new randevual2form();
            randevual2geridonus.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl.Clear();
            string a = hastanerandevusistemiformu.kullanici_tc;
            if (hastanerandevusistemiformu.kullanici_tc == textBox1.Text)
            {
                OleDbConnection baglanti = new SqlBaglanti().yeniBaglanti();
                OleDbCommand komut = new OleDbCommand("Select*From Listeler Where kullanici_tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", int.Parse(textBox1.Text));
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = komut;
                da.Fill(tbl);
                dataGridView1.DataSource = tbl;
                da.Dispose();
                baglanti.Close();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
               OleDbConnection con1 = new SqlBaglanti().yeniBaglanti();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con1;
                cmd.CommandText = "delete from Listeler where kayit_id=@id";
                cmd.Parameters.AddWithValue("@id", int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cmd.ExecuteNonQuery();
                con1.Close();
                button1_Click(sender, e);
            }
        }
    }
}
