using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Staff_Management_System
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QVJLJII\\SQLEXPRESS;Initial Catalog=PersonelKayıt;Integrated Security=True");
        void temizle()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtProfession.Text = "";
            mskSalary.Text = "";
            cmbCity.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtName.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
           
            
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter1.Fill(this.personelKayıtDataSet2.Tbl_Personel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PersonelAd,PersonelSoyad,PersonelŞehir,PersonelMaas,PersonelMeslek,PersonelDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtName.Text);
            komut.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut.Parameters.AddWithValue("@p3", cmbCity.Text);
            komut.Parameters.AddWithValue("@p4", mskSalary.Text);
            komut.Parameters.AddWithValue("@p5", txtProfession.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Staff Added");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text =  "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { 
            if (radioButton2.Checked == false)
            {
                label8.Text = "False";
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbCity.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskSalary.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtProfession.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text ==" True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text =="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel where PersonelId=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtId.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PersonelAd=@a1,PersonelSoyad=@a2,PersonelŞehir=@a3,PersonelMaas=@a4,PersonelDurum=@a5,PersonelMeslek=@a6 where PersonelId=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtName.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtSurname.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbCity.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskSalary.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtProfession.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtId.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi");
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Frmstatistikler frİ = new Frmstatistikler();
            frİ.Show();
        }

        private void btnGraphics_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg1 = new FrmGrafikler();
            frg1.Show();
        }
    }
}
