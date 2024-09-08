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

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        public string numara;
        SqlConnection sqlConnection = new SqlConnection("Data Source=AGIT\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;TrustServerCertificate=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLDERS where OGRNUMARA=@P1", sqlConnection);
            cmd.Parameters.AddWithValue("@P1", numara);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LblAdSoyad.Text = reader[2].ToString() + " " + reader[3].ToString();
                Lbls1.Text = reader[4].ToString();
                Lbls2.Text = reader[5].ToString();
                Lbls3.Text = reader[6].ToString();
                LblOrtalama.Text = reader[7].ToString();
                LblDurum.Text = reader[8].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();

            // SqlCommand Sorgusu
          
            
        }
    }
}