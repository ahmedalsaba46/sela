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
    public partial class edit_shipment : Form
    {
        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");
        int en;
        string user, id;

        ArrayList s = new ArrayList();
        ArrayList s1 = new ArrayList();
        ArrayList s2 = new ArrayList();

        void show()
        {
            con.Open();
            SqlCommand com2 = new SqlCommand("select * from shipment where ID=@id", con);
            com2.Parameters.AddWithValue("@id", textBox7.Text);

            SqlDataReader dr2 = com2.ExecuteReader();

            if (dr2.Read())
            {
                label23.Text = dr2["email"].ToString();
                label24.Text = dr2["resourse"].ToString();
                label26.Text = dr2["city"].ToString();
                label25.Text = dr2["state1"].ToString();
                label27.Text = dr2["date_sh"].ToString();
                label28.Text = dr2["num_peas"].ToString();
                label30.Text = dr2["price"].ToString();
                label29.Text = dr2["phon1"].ToString();
                label34.Text = dr2["phon2"].ToString();
                label31.Text = dr2["dis_sh"].ToString();
                label32.Text = dr2["drive"].ToString();
            }
            else
                MessageBox.Show("shipment does not exist");
            con.Close();
        }
        public edit_shipment(int en1 ,string user1,string id1)
        {
            InitializeComponent();
            user = user1;
            id = id1;

            label23.Text = " ";
            label24.Text = " ";
            label26.Text = " ";
            label25.Text = " ";
            label27.Text = " ";
            label28.Text = " ";
            label30.Text = " ";
            label29.Text = " ";
            label34.Text = " ";
            label31.Text = " ";
            label32.Text = " ";

            if (en1 == 0)
            {
                label18.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label8.Visible = false;
                label20.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label19.Visible = false;
                FontFamily fm = new FontFamily("Century Schoolbook");
                label2.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                button2.Font = new Font(fm, 16);
                label1.Font = new Font(fm, 18);
                label6.Font = new Font(fm, 18);
                label21.Font = new Font(fm, 18);
                label36.Font = new Font(fm, 18);
                label35.Font = new Font(fm, 18);
                label37.Font = new Font(fm, 18);
                label38.Font = new Font(fm, 18);
                label39.Font = new Font(fm, 18);
                label40.Font = new Font(fm, 18);
                label41.Font = new Font(fm, 18);
                label10.Font = new Font(fm, 18);
                label15.Font = new Font(fm, 18);
                label2.Text = "ID shipment";
                button1.Text = "veiw";
                button2.Text = "edit";
                label1.Text = "Resource";
                label6.Text = "Email";
                label21.Text = "state";
                label36.Text = "City";
                label35.Text = "Date";
                label37.Text = "Num_peace";
                label38.Text = "Phon_num";
                label39.Text = "price";
                label40.Text = "discrepchin";
                label41.Text = "Driver";
                label10.Text = "time";
                label15.Text = "price";
                this.Text = "ADD shipment";
                en = en1;
            }
            else
            {
                label1.Visible = false;
                label6.Visible = false;
                label21.Visible = false;
                label36.Visible = false;
                label35.Visible = false;
                label37.Visible = false;
                label38.Visible = false;
                label39.Visible = false;
                label40.Visible = false;
                label41.Visible = false;
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
                label10.Font = new Font(fm, 20, FontStyle.Bold);
                label15.Font = new Font(fm, 20, FontStyle.Bold);
                label2.Text = "رقم الشحنة";
                button1.Text = "عرض";
                button2.Text = "تعديل";
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
                label10.Text = "المدة";
                label15.Text = "الزمن";
                this.Text = "اضفة شحنة";
                en = en1;
            }
        }

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

            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             comboBox1.Items.Clear();
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
            comboBox1.SelectedIndex = 0;

            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("update shipment set city=@city,num_peas=@n_p,price=@pr,phon1=@phon1,phon2=@phon2,dis_sh=@dis,drive=@driv,history=@his where ID=@id", con);

                com.Parameters.AddWithValue("@id", textBox7.Text);
                com.Parameters.AddWithValue("@city", comboBox1.SelectedItem.ToString());
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

                show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
