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
    public partial class shipment : Form
    {
        string user, id;
        int en;

        private void button6_Click(object sender, EventArgs e)
        {
            Add_shipment as1 = new Add_shipment(en, user, id);
            this.Hide();
            as1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2(en, id, user);
            this.Hide();
            f3.Show();
        }

        private void shipment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void shipment_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ADD_city c = new ADD_city(en, user, id);
            this.Hide();
            c.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2(en, id, user);
            this.Hide();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADD_driver a = new ADD_driver(en, user, id);
            this.Hide();
            a.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            edit_shipment ex = new edit_shipment(en,user,id);
            this.Hide();
            ex.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit_state_shipment ex = new edit_state_shipment(en, user, id);
            this.Hide();
            ex.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sort s = new Sort(en, user, id);
            this.Hide();
            s.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            search_shipment s = new search_shipment(en, user, id);
            this.Hide();
            s.Show();
        }

        public shipment(int en1, string user1, string id1)
        {
            InitializeComponent();

            user = user1;
            id = id1;

            label2.Text = user;

            if (id[0] == '1')
                button8.Visible = true;


            pictureBox1.Image = Image.FromFile(@"C:\Users\ahmed\Desktop\sela\sela\sela.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            


            if (en1 == 0)
            {
                label1.Text = "Sela";
                button6.Text = "ADD shipment";
                button4.Text = "Edit shipment";
                button5.Text = "Sort shipment";
                button2.Text = "Change state shipment";
                button3.Text = "ADD driver";
                button7.Text = "Search shipment";
                button8.Text = "ADD city";
                this.Text = "shipment";
                en = en1;
            }
            else
            {
                label1.Text = "شــركة صــلة";
                button6.Text = "اضافة شحنة";
                button4.Text = "تعديل شحنة";
                button5.Text = "فرز شحنة";
                button2.Text = "تغيير حالة شحنة";
                button3.Text = "اضافة مندوب";
                button7.Text = "البحث عن شحنة";
                button8.Text = "اضافة مدينة";
                this.Text = "شحنة";
                en = en1;
            }
        }
    }
}
