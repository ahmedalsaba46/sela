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
    public partial class ADD_driver : Form
    {
        SqlConnection con = new SqlConnection(@"data source =DESKTOP-HLLMIMU;initial catalog = sela ; integrated security= true");
        int en;
        string user, id;
        public ADD_driver(int en1,string user1, string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label3.Font = new Font(fm, 18);
                label4.Font = new Font(fm, 18);
                label6.Font = new Font(fm, 18);
                label7.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                label3.Text = "Name";
                label4.Text = "phon";
                label6.Text = "city";
                label7.Text = "ID";
                button1.Text = "ADD";
                this.Text = "ADD Driver";
                en = en1;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label3.Font = new Font(fm, 20, FontStyle.Bold);
                label4.Font = new Font(fm, 20, FontStyle.Bold);
                label6.Font = new Font(fm, 20, FontStyle.Bold);
                label7.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16);
                label3.Text = "الاسم";
                label4.Text = "رقم الهاتف";
                label6.Text = "المدينة";
                label7.Text = "رقم الهوية";
                button1.Text = "اضافة";
                this.Text = "اضافة مندوب";
                en = en1;
            }
            
            con.Open();
            SqlCommand com = new SqlCommand("select * from city", con);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
                comboBox1.Items.Add(dr["city"].ToString());
            con.Close();
        }

        private void ADD_driver_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into driv values(@a,@b,@c,@d,@e)", con);
                com.Parameters.AddWithValue("@a", textBox1.Text);
                com.Parameters.AddWithValue("@b", textBox3.Text);
                com.Parameters.AddWithValue("@c", textBox2.Text);
                com.Parameters.AddWithValue("@d", comboBox1.SelectedItem.ToString());
                com.Parameters.AddWithValue("@e", textBox4.Text);

                if (com.ExecuteNonQuery() != 0)
                    MessageBox.Show("Done");
                else
                    MessageBox.Show("Error");

                con.Close();
            }
            catch(Exception ex)
            {
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.BalloonTipText = "This ID is exist";
                notifyIcon1.BalloonTipTitle = "Alert";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(5000);
                textBox1.Clear();
            }
        }

        private void ADD_driver_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            shipment s = new shipment(en, user, id);
            this.Hide();
            s.Show();
        }
    }
}
