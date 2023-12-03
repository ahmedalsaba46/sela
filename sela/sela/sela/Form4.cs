using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sela
{
    public partial class Form4 : Form
    {
        string user, id;
        int en;
        public Form4(int en1, string user1, string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;
            label2.Text = user;


            pictureBox1.Image = Image.FromFile(@"C:\Users\ahmed\Desktop\sela\sela\sela.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            

            if (en1 == 0)
            {
                label1.Text = "Sela";
                button4.Text = "Add New Clinet";
                button1.Text = "edit Clinet";
                button3.Text = "Show Record Clinet";
                this.Text = "Clinets";
                en = en1;
            }
            else
            {
                label1.Text = "شــركة صــلة";
                button4.Text = "اضافة عميل جديد";
                button1.Text = "تعديل بيانات عميل";
                button3.Text = "عرض سجل عميل";
                this.Text = "الموظفين";
                en = en1;
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_clinet a2 = new Add_clinet(en,user,id);
            this.Hide();
            a2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            edit_clinet e2 = new edit_clinet(en, user, id);
            this.Hide();
            e2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_record_cliney v = new view_record_cliney(en, user, id);
            this.Hide();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(en, id,user);
            this.Hide();
            f2.Show();
        }
    }
}
