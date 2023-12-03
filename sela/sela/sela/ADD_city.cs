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

namespace sela
{
    public partial class ADD_city : Form
    {

        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");

        string user, id;
        int en;

        private void ADD_city_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            shipment s = new shipment(en,user,id);
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand com = new SqlCommand("insert into city values(@a,@b,@c)",con);
            com.Parameters.AddWithValue("@a", textBox1.Text);
            com.Parameters.AddWithValue("@b", textBox2.Text);
            com.Parameters.AddWithValue("@c", textBox3.Text);

            if (com.ExecuteNonQuery() != 0)
                MessageBox.Show("Done");
            else
                MessageBox.Show("Erorr");

            con.Close();
        }

        private void ADD_city_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public ADD_city(int en1, string user1, string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;
            en = en1;

            if (en == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label3.Font = new Font(fm, 18);
                label4.Font = new Font(fm, 18);
                label5.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                label3.Text = "City";
                label4.Text = "price";
                label5.Text = "time";
                button1.Text = "ADD";
                this.Text = "ADD city";
                en1 = en;

            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label3.Font = new Font(fm, 20, FontStyle.Bold);
                label4.Font = new Font(fm, 20, FontStyle.Bold);
                label5.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16, FontStyle.Bold);
                label3.Text = "المدينة";
                label4.Text = "السعر";
                label5.Text = "الوقت";
                button1.Text = "اضافة";
                this.Text = "اضافة مدينة";
                en1 = en;
            }
        }
    }
}
