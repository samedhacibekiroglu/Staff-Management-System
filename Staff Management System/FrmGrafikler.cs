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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QVJLJII\\SQLEXPRESS;Initial Catalog=PersonelKayıt;Integrated Security=True");
        private void chart1_Click(object sender, EventArgs e)
        {
            //Grafik1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select PersonelŞehir,Count(*) From Tbl_Personel Group By PersonelŞehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
        }
        //Grafik 2
        private void chart2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select PersonelMeslek, Avg(PersonelMaas) From Tbl_Personel Group By PersonelMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
