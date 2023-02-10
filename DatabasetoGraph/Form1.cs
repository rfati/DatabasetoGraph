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

namespace DatabasetoGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PJIG1NN;Initial Catalog=Cinema;Integrated Security=True");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand command1 = new SqlCommand("select NAME, POINT from TblFilm", con);
            con.Open();
            SqlDataReader dr = command1.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Film"].Points.AddXY(dr[0].ToString(), Convert.ToDouble(dr[1].ToString()));
            }
            con.Close();
        }
    }
}
