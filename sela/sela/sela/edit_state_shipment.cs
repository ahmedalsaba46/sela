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
    public partial class edit_state_shipment : Form
    {
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
        
        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");
    
        public edit_state_shipment(int en1,string user1,string id1)
        {
            
            InitializeComponent();

            user = user1;
            id = id1;

            string[] e = { "في المخزن", "جاري الشحن", "تم التسليم", "تم الارجاع", "التالف" };

            comboBox1.Items.AddRange(e);
            comboBox5.Items.AddRange(e);

            
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
                label8.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                button2.Font = new Font(fm, 16);
                label3.Text = "state";
                label8.Text = "state";
                label7.Text = "city";
                label4.Text = "from";
                label5.Text = "To";
                button1.Text = "sort";
                button2.Text = "Edit";
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
                label8.Font = new Font(fm, 20, FontStyle.Bold);
                label5.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16);
                button2.Font = new Font(fm, 16);
                label3.Text = "الحالة";
                label8.Text = "الحالة";
                label7.Text = "المدينة";
                label4.Text = "من";
                label5.Text = "الى";
                button1.Text = "فرز";
                button2.Text = "تعديل";
                label6.Text = "رقم الشحنة";
                en = en1;
            }

            show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("update shipment set state1=@state1 where date_sh between @date1 and @date2 and state1=@state and city=@city", con);
                    com.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString());
                    com.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString());
                    com.Parameters.AddWithValue("@city", comboBox4.SelectedItem.ToString());
                    com.Parameters.AddWithValue("@state", comboBox1.SelectedItem.ToString());
                    com.Parameters.AddWithValue("@state1", comboBox5.SelectedItem.ToString());

                    if (com.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("done");
                        con.Close();
                        con.Open();
                        SqlCommand com1 = new SqlCommand("select * from shipment where date_sh between @date12 and @date22 and city=@city2 and state1=@state2", con);
                        com1.Parameters.AddWithValue("@date12", dateTimePicker1.Value.ToString());
                        com1.Parameters.AddWithValue("@date22", dateTimePicker2.Value.ToString());
                        com1.Parameters.AddWithValue("@city2", comboBox4.SelectedItem.ToString());
                        com1.Parameters.AddWithValue("@state2", comboBox1.SelectedItem.ToString());

                        DataTable dt = new DataTable();
                        dt.Load(com1.ExecuteReader());
                        if (dt.Rows.Count > 0)
                            dataGridView1.DataSource = dt;
                        else
                            MessageBox.Show("Null");


                     
                    }
                    else
                    {
                        
                        MessageBox.Show("Error");
                    }
                    con.Close();
                }else
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("update shipment set state1=@state1 where ID=@id", con);
                    com.Parameters.AddWithValue("@id", textBox1.Text);
                    com.Parameters.AddWithValue("@state1", comboBox5.SelectedItem.ToString());

                    if (com.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("done");
                        con.Close();
                        con.Open();
                        SqlCommand com2 = new SqlCommand("select * from shipment where ID=@id1", con);
                        com2.Parameters.AddWithValue("@id1", textBox1.Text);

                        DataTable dt = new DataTable();
                        dt.Load(com2.ExecuteReader());
                        if (dt.Rows.Count > 0)
                            dataGridView1.DataSource = dt;
                        else
                            MessageBox.Show("Null");

                        con.Close();
                    }
                    else
                        MessageBox.Show("Error");

                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void edit_state_shipment_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            shipment s = new shipment(en, user, id);
            this.Hide();
            s.Show();
        }
    }
}
