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
    public partial class Sort : Form
    {
        SqlConnection con = new SqlConnection(@"Data source = DESKTOP-HLLMIMU;initial catalog = sela ; integrated security =true");
        string user, id;
        int en;

        void show()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from shipment", con);
            DataTable dt = new DataTable();
            dt.Load(com.ExecuteReader());

            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            else
                MessageBox.Show("Null");

            con.Close();
        }
        public Sort(int en1,string user1,string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

            string[] e = { "في المخزن", "جاري الشحن", "تم التسليم", "تم الارجاع", "التالف" };

            comboBox1.Items.AddRange(e);
     
            con.Open();
            SqlCommand com1 = new SqlCommand("select * from city", con);
            SqlDataReader dr1 = com1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox4.Items.Add(dr1["city"]);
            }
            con.Close();

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label3.Font = new Font(fm, 18);
                label4.Font = new Font(fm, 18);
                label6.Font = new Font(fm, 18);
                label7.Font = new Font(fm, 18);
                label5.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                label3.Text = "state";
                label7.Text = "city";
                label4.Text = "from";
                label5.Text = "To";
                button1.Text = "sort";
                label6.Text = "ID";
                en = en1;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label3.Font = new Font(fm, 20, FontStyle.Bold);
                label4.Font = new Font(fm, 20, FontStyle.Bold);
                label6.Font = new Font(fm, 20, FontStyle.Bold);
                label7.Font = new Font(fm, 20, FontStyle.Bold);
                label5.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16);
                label3.Text = "الحالة";
                label7.Text = "المدينة";
                label4.Text = "من";
                label5.Text = "الى";
                button1.Text = "فرز";
                label6.Text = "رقم الشحنة";
                en = en1;
            }

            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from shipment where date_sh between @date1 and @date2 and city=@city and state1=@state", con);
                    com.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString());
                    com.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString());
                    com.Parameters.AddWithValue("@city", comboBox4.SelectedItem.ToString());
                    com.Parameters.AddWithValue("@state", comboBox1.SelectedItem.ToString());

                    DataTable dt = new DataTable();
                    dt.Load(com.ExecuteReader());
                    if (dt.Rows.Count > 0)
                        dataGridView1.DataSource = dt;
                    else
                        MessageBox.Show("Null");


                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from shipment where ID=@id", con);
                    com.Parameters.AddWithValue("@id", textBox1.Text);

                    DataTable dt = new DataTable();
                    dt.Load(com.ExecuteReader());
                    if (dt.Rows.Count > 0)
                        dataGridView1.DataSource = dt;
                    else
                        MessageBox.Show("Null");

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
