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
    public partial class view_record_cliney : Form
    {
        SqlConnection con = new SqlConnection(@"data source = DESKTOP-HLLMIMU;initial catalog = sela;integrated security= true");
        string user, id,s;
        int en;
        public view_record_cliney(int en1,string user1,string id1)
        {
            InitializeComponent(); user = user1;
            id = id1;

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label2.Font = new Font(fm, 18);
                label13.Font = new Font(fm, 18);
                button3.Font = new Font(fm, 16);
                groupBox1.Font = new Font(fm, 16);
                label13.Text = "ID Clinet";
                label2.Text = "ID Shipment";
                button3.Text = "Search";
                groupBox1.Text = "Search";
                en = en1;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label2.Font = new Font(fm, 20, FontStyle.Bold);
                label13.Font = new Font(fm, 20, FontStyle.Bold);
                button3.Font = new Font(fm, 16, FontStyle.Bold);
                groupBox1.Font = new Font(fm, 16);
                label13.Text = "رقم هوية العميل";
                label2.Text = "رقم الشحنة";
                button3.Text = "بحث";
                groupBox1.Text = "البحث";
                en = en1;
            }

            con.Open();
            SqlCommand cmd = new SqlCommand("show_clinet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            con.Close();
        }

        private void view_record_cliney_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from shipment where ID=@d",con);
            com.Parameters.AddWithValue("@d", comboBox1.SelectedItem.ToString());

            DataTable dt = new DataTable();
            dt.Load(com.ExecuteReader());

            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            
            con.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("select * from clinet where ID=@id", con);
                com.Parameters.AddWithValue("@id", textBox6.Text);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                    s = dr["resourse"].ToString();
                else
                    MessageBox.Show("the clinet does not exist");
                con.Close();
                con.Open();
                SqlCommand com1 = new SqlCommand("select * from shipment where resourse=@i", con);
                com1.Parameters.AddWithValue("@i", s);

                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                    comboBox1.Items.Add(dr1["ID"].ToString());

                con.Close();
                comboBox1.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(en, user, id);
            this.Hide();
            f.Show();
        }
    }
}
