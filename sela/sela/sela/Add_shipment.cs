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
using System.Collections;

namespace sela
{
    public partial class Add_shipment : Form
    {
        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");

        string user, id;
        int en;
        
        ArrayList s = new ArrayList();
        ArrayList s1 = new ArrayList();
        ArrayList s2 = new ArrayList();
        public Add_shipment(int en1, string user1, string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

 

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label2.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                button2.Font = new Font(fm, 16);
                label11.Font = new Font(fm, 18);
                label12.Font = new Font(fm, 18);
                label13.Font = new Font(fm, 18);
                label14.Font = new Font(fm, 18);
                label8.Font = new Font(fm, 18);
                label20.Font = new Font(fm, 18);
                label16.Font = new Font(fm, 18);
                label17.Font = new Font(fm, 18);
                label19.Font = new Font(fm, 18);
                label18.Font = new Font(fm, 18);
                label6.Font = new Font(fm, 18);
                label10.Font = new Font(fm, 18);
                label15.Font = new Font(fm, 18);
                label2.Text = "ID Clinet";
                button1.Text = "search";
                button2.Text = "ADD";
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
                label6.Text = "in storage";
                label10.Text = "time";
                label15.Text = "price";
                this.Text = "ADD shipment";
                en = en1;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label2.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16);
                button2.Font = new Font(fm, 16);
                label11.Font = new Font(fm, 20, FontStyle.Bold);
                label12.Font = new Font(fm, 20, FontStyle.Bold);
                label13.Font = new Font(fm, 20, FontStyle.Bold);
                label14.Font = new Font(fm, 20, FontStyle.Bold);
                label8.Font = new Font(fm, 20, FontStyle.Bold);
                label20.Font = new Font(fm, 20, FontStyle.Bold);
                label16.Font = new Font(fm, 20, FontStyle.Bold);
                label17.Font = new Font(fm, 20, FontStyle.Bold);
                label19.Font = new Font(fm, 20, FontStyle.Bold);
                label18.Font = new Font(fm, 20, FontStyle.Bold);
                label6.Font = new Font(fm, 20, FontStyle.Bold);
                label10.Font = new Font(fm, 20, FontStyle.Bold);
                label15.Font = new Font(fm, 20, FontStyle.Bold);
                label2.Text = "رقم العميل";
                button1.Text = "بحث";
                button2.Text = "اضافة";
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
                label6.Text = "في المخزن";
                label10.Text = "المدة";
                label15.Text = "السعر";
                this.Text = "اضفة شحنة";
                en = en1;
            }



            
        }

        private void Add_shipment_Load(object sender, EventArgs e)
        {

        }

        private void Add_shipment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            s.Clear();
            con.Open();
            SqlCommand com1 = new SqlCommand("show_city", con);
            com1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = com1.ExecuteReader();

            
            while (dr1.Read())
            {
                  s.Add(dr1["city"].ToString());
                  s1.Add(dr1["price"].ToString());
                  s2.Add(dr1["time1"].ToString());
            }
            
            con.Close();

            comboBox1.Items.AddRange(s.ToArray());
            

            con.Open();
            SqlCommand com = new SqlCommand("select * from clinet where ID=@id", con);

            com.Parameters.AddWithValue("@id", textBox7.Text);

            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                label4.Text = dr["resourse"].ToString();
                label5.Text = dr["email"].ToString();
            }
            else
                MessageBox.Show("العميل غير موجود");

            con.Close();

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            label3.Text = s1[comboBox1.SelectedIndex].ToString();
            label22.Text = s2[comboBox1.SelectedIndex].ToString();

            con.Open();
            SqlCommand com = new SqlCommand("select * from driv where city = @a", con);
            com.Parameters.AddWithValue("@a", comboBox1.SelectedItem.ToString());

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
                comboBox2.Items.Add(dr["name"]);

            con.Close();
            try
            {
                comboBox2.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("this city does hasnt any driver");
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into shipment values(@email,@reso,@city,@state,@date,@n_p,@pr,@phon1,@phon2,@dis,@driv,@his)", con);

                com.Parameters.AddWithValue("@email", label5.Text);
                com.Parameters.AddWithValue("@reso", label4.Text);
                com.Parameters.AddWithValue("@city", comboBox1.SelectedItem.ToString());
                com.Parameters.AddWithValue("@state", "في المخزن");
                com.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());
                com.Parameters.AddWithValue("@n_p", textBox6.Text);
                com.Parameters.AddWithValue("@pr", textBox4.Text);
                com.Parameters.AddWithValue("@phon1", textBox5.Text);
                com.Parameters.AddWithValue("@phon2", textBox3.Text);
                com.Parameters.AddWithValue("@dis", textBox2.Text);
                com.Parameters.AddWithValue("@driv", comboBox2.SelectedItem.ToString());
                com.Parameters.AddWithValue("@his", user);

                if (com.ExecuteNonQuery() != 0)
                    MessageBox.Show("done");
                else
                    MessageBox.Show("error");
                con.Close();

                textBox6.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
