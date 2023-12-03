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
    public partial class search_shipment : Form
    {
        string user, id;
        int en;

        SqlConnection con = new SqlConnection(@"data source = DESKTOP-HLLMIMU;initial catalog = sela;integrated security = true");

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shipment s = new shipment(en, user, id);
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from shipment where ID=@id", con);
            com.Parameters.AddWithValue("@id", textBox7.Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                label3.Text = dr["email"].ToString();
                label4.Text = dr["resourse"].ToString();
                label5.Text = dr["city"].ToString();
                label6.Text = dr["state1"].ToString();
                label7.Text = dr["date_sh"].ToString();
                label9.Text = dr["num_peas"].ToString();
                label10.Text = dr["price"].ToString();
                label25.Text = dr["phon1"].ToString();
                label15.Text = dr["phon2"].ToString();
                label22.Text = dr["dis_sh"].ToString();
                label23.Text = dr["drive"].ToString();
            }
            else
                MessageBox.Show("Shipment does not exist");
            con.Close();
        }

        private void search_shipment_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public search_shipment(int en1,string user1,string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label2.Font = new Font(fm, 18);
                label8.Font = new Font(fm, 18);
                label11.Font = new Font(fm, 18);
                label12.Font = new Font(fm, 18);
                label13.Font = new Font(fm, 18);
                label14.Font = new Font(fm, 18);
                label16.Font = new Font(fm, 18);
                label17.Font = new Font(fm, 18);
                label18.Font = new Font(fm, 18);
                label19.Font = new Font(fm, 18);
                label20.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                label2.Text = "ID Shipment";
                button1.Text = "Search";
                label11.Text = "Resource";
                label12.Text = "Email";
                label13.Text = "state";
                label14.Text = "City";
                label8.Text = "Date";
                label20.Text = "Num_peace";
                label16.Text = "Phon_num";
                label17.Text = "price";
                label19.Text = "discrepchin";
                label18.Text = "Driver";
                en = en1;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label2.Font = new Font(fm, 20, FontStyle.Bold);
                label8.Font = new Font(fm, 20, FontStyle.Bold);
                label11.Font = new Font(fm, 20, FontStyle.Bold);
                label12.Font = new Font(fm, 20, FontStyle.Bold);
                label13.Font = new Font(fm, 20, FontStyle.Bold);
                label14.Font = new Font(fm, 20, FontStyle.Bold);
                label16.Font = new Font(fm, 20, FontStyle.Bold);
                label17.Font = new Font(fm, 20, FontStyle.Bold);
                label18.Font = new Font(fm, 20, FontStyle.Bold);
                label19.Font = new Font(fm, 20, FontStyle.Bold);
                label20.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16);
                label2.Text = "رقم الشحنة";
                button1.Text = "البحث";
                label11.Text = "اسم الجهة او الصفحة";
                label12.Text = "البريد الالكتروني";
                label13.Text = "الحالة";
                label14.Text = "المدينة";
                label8.Text = "التاريخ";
                label20.Text = "عدد القطع";
                label16.Text = "رقم الهاتف";
                label17.Text = "السعر";
                label19.Text = "الوصف";
                label18.Text = "المندوب";
                en = en1;
            }

            label3.Text = " ";
            label4.Text = " ";
            label5.Text = " ";
            label6.Text = " ";
            label7.Text = " ";
            label9.Text = " ";
            label10.Text = " ";
            label25.Text = " ";
            label15.Text = " ";
            label22.Text = " ";
            label23.Text = " ";
        }
    }
}
