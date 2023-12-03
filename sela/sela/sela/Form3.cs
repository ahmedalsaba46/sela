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
    public partial class Form3 : Form
    {
        static string user;
        int en;
        string id;
        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");
        void show()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from emp", con);
            DataTable dt = new DataTable();
            dt.Load(com.ExecuteReader());
            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            else
                MessageBox.Show("لايوجد موظفين");
            con.Close();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        public Form3(int en1,string user1,string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

            string[] s = { "مدير", "موظف" };

            comboBox1.Items.AddRange(s);
            comboBox1.SelectedIndex = 1;

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label2.Font = new Font(fm, 18);
                label3.Font = new Font(fm, 18);
                label4.Font = new Font(fm, 18);
                label5.Font = new Font(fm, 18);
                label6.Font = new Font(fm, 18);
                label7.Font = new Font(fm, 18);
                label2.Text = "ID";
                label3.Text = "Full Name";
                label4.Text = "User Name";
                label5.Text = "Password";
                label6.Text = "State";
                label7.Text = "Phon Number";
                label9.Text = " ";
                label10.Text = " ";
                label11.Text = " ";
                label12.Text = " ";
                label13.Text = " ";
                label14.Text = " ";
                en = en1;
            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label9.Font = new Font(fm, 20, FontStyle.Bold);
                label10.Font = new Font(fm, 20, FontStyle.Bold);
                label11.Font = new Font(fm, 20, FontStyle.Bold);
                label12.Font = new Font(fm, 20, FontStyle.Bold);
                label13.Font = new Font(fm, 20, FontStyle.Bold);
                label14.Font = new Font(fm, 20, FontStyle.Bold);
                label9.Text = "رقم القيد";
                label10.Text = " الاسم الثلاثي ";
                label11.Text = "اسم المستخدم";
                label12.Text = "كلمة المرور";
                label13.Text = "الوظيفة";
                label14.Text = "رقم الهاتف";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                this.Text = "الموظفين";
                en = en1;
            }

            

            comboBox1.Enabled = false;

            show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2(en,id,user);
            this.Hide();
            f2.Show();
            
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
            string s1 = textBox1.Text;
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.BalloonTipText = "please enter the ID";
                notifyIcon1.BalloonTipTitle = "Alert";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(5000);
            }
            else
            {
                if (s1[0] == '1')
                    comboBox1.SelectedIndex = 0;
                else
                    comboBox1.SelectedIndex = 1;
            }
            con.Open();
            SqlCommand com = new SqlCommand("select * from emp where ID=@id", con);

            com.Parameters.AddWithValue("@id",textBox1.Text);

            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr["name"].ToString();
                textBox3.Text = dr["userName"].ToString();
                textBox4.Text = dr["pass"].ToString();
                textBox5.Text = dr["phon_num"].ToString();
            }


            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("insert into emp values(@id,@name,@user_name,@pass,@state,@phon,@his)", con);
            string s = textBox1.Text;
            if (s[0] == '1')
            {
                if (MessageBox.Show("هل انت تريد اضافة مدير جديد الى المنضومة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true) == DialogResult.Yes)
                {
                    com.Parameters.AddWithValue("@id", textBox1.Text);
                    com.Parameters.AddWithValue("@name", textBox2.Text);
                    com.Parameters.AddWithValue("@user_name", textBox3.Text);
                    com.Parameters.AddWithValue("@pass", textBox4.Text);
                    com.Parameters.AddWithValue("@state", comboBox1.SelectedItem);
                    com.Parameters.AddWithValue("@phon", textBox5.Text);
                    com.Parameters.AddWithValue("@his", user);

                    if (com.ExecuteNonQuery() != 0)
                        MessageBox.Show("done");
                    else
                        MessageBox.Show("error");
                    MessageBox.Show("من فضلك ادخل من جديد");
                }
            }
            else
            {
                com.Parameters.AddWithValue("@id", textBox1.Text);
                com.Parameters.AddWithValue("@name", textBox2.Text);
                com.Parameters.AddWithValue("@user_name", textBox3.Text);
                com.Parameters.AddWithValue("@pass", textBox4.Text);
                com.Parameters.AddWithValue("@state", comboBox1.SelectedItem);
                com.Parameters.AddWithValue("@phon", textBox5.Text);
                com.Parameters.AddWithValue("@his", user);

                if (com.ExecuteNonQuery() != 0)
                    MessageBox.Show("done");
                else
                    MessageBox.Show("error");
            }
            con.Close();
            show();
            clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("update emp set ID=@id,name=@name,userName=@user,pass=@pass,state_emp=@state,phon_num=@phon,history=@his where ID=@id", con);
            com.Parameters.AddWithValue("@id", textBox1.Text);
            com.Parameters.AddWithValue("@name", textBox2.Text);
            com.Parameters.AddWithValue("@user", textBox3.Text);
            com.Parameters.AddWithValue("@pass", textBox4.Text);
            com.Parameters.AddWithValue("@state", comboBox1.SelectedItem);
            com.Parameters.AddWithValue("@phon", textBox5.Text);
            com.Parameters.AddWithValue("@his", user);

            if (com.ExecuteNonQuery() != 0)
                MessageBox.Show("تم التعديل");
            else
                MessageBox.Show("لا يوجد موظف برقم القيد الذي قمت بادخاله");
            con.Close();

            show();
            clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("delete from emp where ID=@id", con);
            com.Parameters.AddWithValue("@id", textBox1.Text);
            if (com.ExecuteNonQuery() == 1)
                MessageBox.Show("تمت عملية الجذف بنجاح");
            else
                MessageBox.Show("لا يوجد موظف برقم القيد الذي قمت بادخاله");
            con.Close();

            show();
            clear();
        }
    }
}
