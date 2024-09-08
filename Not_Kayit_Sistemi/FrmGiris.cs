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
namespace Not_Kayit_Sistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frmOgrenciDetay = new FrmOgrenciDetay();
            frmOgrenciDetay.numara = maskedTextBox1.Text;
            frmOgrenciDetay.Show();


        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                FrmOgretmenDetay frm = new FrmOgretmenDetay();
                frm.Show();
            }
        }
    }
}
