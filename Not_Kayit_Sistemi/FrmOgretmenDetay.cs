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
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) AS toplam FROM TBLDERS WHERE DURUM = 1", sqlConnection);
            int sonuc = (int)sqlCommand.ExecuteScalar();
            LblGecen.Text = sonuc.ToString();
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand sqlCommand1 = new SqlCommand("SELECT COUNT(*) AS toplam FROM TBLDERS WHERE DURUM = 0", sqlConnection);
            int sonuc1 = (int)sqlCommand1.ExecuteScalar();
            LblKalan.Text = sonuc1.ToString();
            sqlConnection.Close();

        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=AGIT\\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)", sqlConnection);
            cmd.Parameters.AddWithValue("@P1", MskNumara.Text);
            cmd.Parameters.AddWithValue("@P2", TxtAd.Text);
            cmd.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Öğrenci Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtS1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtS2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtS3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            MskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtS1.Text);
            s2 = Convert.ToDouble(TxtS2.Text);
            s3 = Convert.ToDouble(TxtS3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString("0.00");
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Update TBLDERS SET OGRS1=@S1,OGRS2=@S2,OGRS3=@S3,ORTALAMA=@O,DURUM=@D WHERE OGRNUMARA=@S6", sqlConnection);
            cmd.Parameters.AddWithValue("@S1", TxtS1.Text);
            cmd.Parameters.AddWithValue("@S2", TxtS2.Text);
            cmd.Parameters.AddWithValue("@S3", TxtS3.Text);
            cmd.Parameters.AddWithValue("@O", decimal.Parse(LblOrtalama.Text));
            cmd.Parameters.AddWithValue("@S6", MskNumara.Text);
            cmd.Parameters.AddWithValue("@D", durum);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Not Güncellendi");

            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
            sqlConnection.Close();

         

        }
    }
}
