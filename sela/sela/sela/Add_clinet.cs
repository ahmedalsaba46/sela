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
    public partial class Add_clinet : Form
    {
        string user, id;
        int en;

        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");
        public Add_clinet(int en1,string user1,string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;
            label7.Text = user;

            if (en1 == 0)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                FontFamily fm = new FontFamily("Century Schoolbook");
                label1.Font = new Font(fm, 18);
                label8.Font = new Font(fm, 18);
                label9.Font = new Font(fm, 18);
                label10.Font = new Font(fm, 18);
                label11.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                label1.Text = "Clinet Name";
                label8.Text = "ID card";
                label9.Text = "Resourse";
                label10.Text = "Phon Number";
                label11.Text = "Email";
                button1.Text = "ADD";
                this.Text = "ADD Clinet";
                en = en1;
            }
            else
            {
                label1.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                FontFamily fm = new FontFamily("Akhbar MT");
                label2.Font = new Font(fm, 20, FontStyle.Bold);
                label3.Font = new Font(fm, 20, FontStyle.Bold);
                label4.Font = new Font(fm, 20, FontStyle.Bold);
                label5.Font = new Font(fm, 20, FontStyle.Bold);
                label6.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16, FontStyle.Bold);
                label2.Text = "اسم العميل";
                label3.Text = "بطاقة الهوية";
                label4.Text = "اسم الجهة";
                label5.Text = "رقم الهاتف";
                label6.Text = "البريد الالكتروني";
                button1.Text = "اضافة";
                this.Text = "اضافة عميل جديد";
                en = en1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(en,user,id);
            this.Hide();
            f4.Show();
        }

        private void Add_clinet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into clinet values(@name,@ID,@reso,@phon,@email,@his)", con);

                com.Parameters.AddWithValue("@name", textBox1.Text);
                com.Parameters.AddWithValue("@ID", textBox2.Text);
                com.Parameters.AddWithValue("@reso", textBox3.Text);
                com.Parameters.AddWithValue("@phon", textBox4.Text);
                com.Parameters.AddWithValue("@email", textBox5.Text);
                com.Parameters.AddWithValue("@his", user);

                if (com.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("done");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else
                    MessageBox.Show("error");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("this id is already exist");
                con.Close();
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Add_clinet_Load(object sender, EventArgs e)
        {

        }
    }
}
