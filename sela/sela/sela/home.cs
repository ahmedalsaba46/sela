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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");

        int en = 0;
        string user, pass,id;
        
        public Form1()
        {
            InitializeComponent();

            
            this.Text = "تسجيل الدخول";

            textBox1.TabIndex = 0;
            textBox2.TabIndex = 1;

            string[] s = { "English", "العربية" };

            comboBox1.Items.AddRange(s);
            comboBox1.SelectedIndex=1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from emp where userName = @us", con);
            com.Parameters.AddWithValue("@us", textBox1.Text);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                user = dr["name"].ToString();
                pass = dr["pass"].ToString();
                id = dr["ID"].ToString();

                if (textBox2.Text == pass)
                {
                    Form2 f2 = new Form2(en, id,user);
                    this.Hide();
                    f2.Show();
                }
                else
                    MessageBox.Show("خطأ في كلمة المرور");
            }
            else
                MessageBox.Show("المستخدم غير موجود");

            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from emp where userName = @us", con);
            com.Parameters.AddWithValue("@us", textBox1.Text);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();


            if (dr.Read())
            {
                user = dr["name"].ToString();
                pass = dr["pass"].ToString();
                id = dr["ID"].ToString();

                if (textBox2.Text == pass)
                {
                    //MessageBox.Show("Hello " + user);
                    Form2 f2 = new Form2(en, id, user);
                    this.Hide();
                    f2.Show();
                }
                else
                    MessageBox.Show("خطأ في كلمة المرور");
            }
            else
                MessageBox.Show("خطأ في اسم المستخدم");


            con.Close();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from emp where userName = @us", con);
            com.Parameters.AddWithValue("@us", textBox1.Text);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();


            if (dr.Read())
            {
                user = dr["name"].ToString();
                pass = dr["pass"].ToString();
                id = dr["ID"].ToString();

                if (textBox2.Text == pass)
                {
                    //MessageBox.Show("Hello " + user);
                    Form2 f2 = new Form2(en, id, user);
                    this.Hide();
                    f2.Show();
                }
                else
                    MessageBox.Show("wrong password");
            }
            else
                MessageBox.Show("user does not found");


            con.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "English")
            {
                FontFamily fm = new FontFamily("Century Schoolbook"); 
                label2.Font = new Font(fm, 18);
                label3.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 18);
                checkBox1.Font = new Font(fm, 14);
                label2.Text = "User Name";
                label3.Text = "Password";
                button1.Text = "Login";
                checkBox1.Text = "Show";
                this.Text = "Login";
                en = 0;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label2.Font = new Font(fm, 22);
                label3.Font = new Font(fm, 22);
                button1.Font = new Font(fm, 18);
                checkBox1.Font = new Font(fm, 14);
                label2.Text = "اســم المســتخدم";
                label3.Text = "كــلمة المــرور";
                button1.Text = "تسجيل الدخول";
                checkBox1.Text = "اظهار";
                this.Text = "تسجيل الدخول";

                
                en = 1;
            }
            
        }
    }
}
