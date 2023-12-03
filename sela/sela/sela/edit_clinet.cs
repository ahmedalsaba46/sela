using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sela
{
    public partial class edit_clinet : Form
    {
        string user, id;
        int en;

        SqlConnection con = new SqlConnection(@"Data source=DESKTOP-HLLMIMU;Initial Catalog = sela;Integrated security = true");

        void show()
        {
            SqlCommand com = new SqlCommand("select * from clinet where ID = @id", con);
            com.Parameters.AddWithValue("@id", textBox6.Text);

            con.Open();

            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                label12.Text = dr["name"].ToString();
                label11.Text = dr["ID"].ToString();
                label10.Text = dr["resourse"].ToString();
                label9.Text = dr["phon"].ToString();
                label8.Text = dr["email"].ToString();
            }
            else
                MessageBox.Show("This clinet does not exist");

            con.Close();
        }

        public edit_clinet(int en1, string user1, string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

            if (en1 == 0)
            {
                FontFamily fm = new FontFamily("Century Schoolbook");
                label2.Font = new Font(fm, 18);
                label3.Font = new Font(fm, 18);
                label4.Font = new Font(fm, 18);
                label5.Font = new Font(fm, 18);
                label6.Font = new Font(fm, 18);
                button1.Font = new Font(fm, 16);
                groupBox1.Font = new Font(fm, 10);
                button3.Font = new Font(fm, 16);
                label13.Font = new Font(fm, 16);
                label2.Text = "Clinet Name";
                label3.Text = "ID card";
                label4.Text = "Resourse";
                label5.Text = "Phon Number";
                label6.Text = "Email";
                button1.Text = "ADD";
                this.Text = "edit Clinet";
                en = en1;
                groupBox1.Text = "search";
                label13.Text = "ID card";
                button3.Text = "search";

            }
            else
            {
                FontFamily fm = new FontFamily("Akhbar MT");
                label2.Font = new Font(fm, 20, FontStyle.Bold);
                label3.Font = new Font(fm, 20, FontStyle.Bold);
                label4.Font = new Font(fm, 20, FontStyle.Bold);
                label5.Font = new Font(fm, 20, FontStyle.Bold);
                label6.Font = new Font(fm, 20, FontStyle.Bold);
                button1.Font = new Font(fm, 16, FontStyle.Bold);
                groupBox1.Font = new Font(fm, 16, FontStyle.Bold);
                button3.Font = new Font(fm, 16, FontStyle.Bold);
                label13.Font = new Font(fm, 20, FontStyle.Bold);
                label2.Text = "اسم العميل";
                label3.Text = "بطاقة الهوية";
                label4.Text = "اسم الجهة";
                label5.Text = "رقم الهاتف";
                label6.Text = "البريد الالكتروني";
                button1.Text = "تعديل";
                this.Text = "تعديل بيانات عميل";
                en = en1;
                groupBox1.Text = "البحث";
                label13.Text = "بطاقة الهوية";
                button3.Text = "البحث";
            }
            textBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(en, user, id);
            this.Hide();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            con.Open();

            SqlCommand com = new SqlCommand("update clinet set name=@name,ID=@ID,resourse=@reso,phon=@phon,email=@email,history=@his where ID=@ID", con);

            com.Parameters.AddWithValue("@ID", textBox2.Text);
            if(textBox1.Text.Length != 0)
                com.Parameters.AddWithValue("@name", textBox1.Text);
            else
                com.Parameters.AddWithValue("@name", label12.Text);
            if (textBox3.Text.Length != 0)
                com.Parameters.AddWithValue("@reso", textBox3.Text);
            else
                com.Parameters.AddWithValue("@reso", label10.Text);
            if (textBox4.Text.Length != 0)
                com.Parameters.AddWithValue("@phon", textBox4.Text);
            else
                com.Parameters.AddWithValue("@phon", label9.Text);
            if (textBox5.Text.Length != 0)
                com.Parameters.AddWithValue("@email", textBox5.Text);
            else
                com.Parameters.AddWithValue("@email", label8.Text);
            com.Parameters.AddWithValue("@his", user);

            if (com.ExecuteNonQuery() != 0)
                MessageBox.Show("done");
            else
                MessageBox.Show("error");

            con.Close();

            show();
        }

        private void edit_clinet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            show();
            textBox2.Text = label11.Text;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void edit_clinet_Load(object sender, EventArgs e)
        {

        }
    }
}
