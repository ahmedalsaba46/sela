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
   
    public partial class Form2 : Form
    {
        static string user1;

        int en1;
        string id1;
        public Form2(int en,string id,string user) {

            InitializeComponent();

            user1 = user;

            label2.Text = user1;

            if (id[0] == '1')
            {
                id1 = id;
                employee.Enabled = true;
            }
            id1 = id;
            
            if (en == 0)
            {
                pictureBox2.Visible = false;
                FontFamily fm = new FontFamily("Century Schoolbook");
                shipment.Font = new Font(fm, 32, FontStyle.Bold);
                clinet.Font = new Font(fm, 32, FontStyle.Bold);
                employee.Font = new Font(fm, 32, FontStyle.Bold);
                addClinet.Font = new Font(fm, 18, FontStyle.Bold);
                editClinet.Font = new Font(fm, 18, FontStyle.Bold);
                showRecordClinet.Font = new Font(fm, 18, FontStyle.Bold);
                addShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                editShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                sortShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                changeStateShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                aDDDriverToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                searchShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                aDDCityToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                shipment.Text = "Shipment";
                clinet.Text = "Clinet";
                employee.Text = "Employees";
                addClinet.Text = "Add Clinet";
                editClinet.Text = "Edit Clinet";
                showRecordClinet.Text = "Show Record Clinet";
                addShipmentToolStripMenuItem.Text = "Add Shipment";
                editShipmentToolStripMenuItem.Text = "Edit Shipment";
                sortShipmentToolStripMenuItem.Text = "Sort Shipment";
                changeStateShipmentToolStripMenuItem.Text = "Change State Shipment";
                aDDDriverToolStripMenuItem.Text = "Add Driver";
                searchShipmentToolStripMenuItem.Text = "Search Shipment";
                aDDCityToolStripMenuItem.Text = "Add City";
                this.Text = "Home";
                en1 = en;
            }
            else
            {
                pictureBox2.Visible = true;
                FontFamily fm = new FontFamily("Akhbar MT");
                clinet.Font = new Font(fm, 40,FontStyle.Bold);
                shipment.Font = new Font(fm, 40, FontStyle.Bold);
                employee.Font = new Font(fm, 40, FontStyle.Bold);
                employee.Font = new Font(fm, 32, FontStyle.Bold);
                addClinet.Font = new Font(fm, 18, FontStyle.Bold);
                editClinet.Font = new Font(fm, 18, FontStyle.Bold);
                showRecordClinet.Font = new Font(fm, 18, FontStyle.Bold);
                addShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                editShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                sortShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                changeStateShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                aDDDriverToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                searchShipmentToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                aDDCityToolStripMenuItem.Font = new Font(fm, 18, FontStyle.Bold);
                clinet.Text = "   العميل   ";
                shipment.Text = "   الشحنات  ";
                employee.Text = "   الموظفين ";
                addClinet.Text = "اضافة عميل";
                editClinet.Text = "تعديل بيانات عميل";
                showRecordClinet.Text = "عرض سجل عميل";
                addShipmentToolStripMenuItem.Text = "اضافة شحنة";
                editShipmentToolStripMenuItem.Text = "تعديل شحنة";
                sortShipmentToolStripMenuItem.Text = "فرز شحنات";
                changeStateShipmentToolStripMenuItem.Text = "تغيير حالة شحنة";
                aDDDriverToolStripMenuItem.Text = "اضافة مندوب";
                searchShipmentToolStripMenuItem.Text = "البحث عن شحنة";
                aDDCityToolStripMenuItem.Text = "اضافة مدينة";
                this.Text = "الرئيسية";
                en1 = en;
            }
        }


        public Form2()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(en1, user1, id1);
            this.Hide();
            f4.Show();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 fa1 = new Form1();
            this.Hide();
            fa1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(en1,user1,id1);
            this.Hide();
            f3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            shipment s = new shipment(en1, user1, id1);
            this.Hide();
            s.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(en1, user1, id1);
            f3.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(en1, user1, id1);
            f4.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            shipment s = new shipment(en1, user1, id1);
            s.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clinetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_shipment ad = new Add_shipment(en1, user1, id1);
            ad.Show();
        }

        private void editShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_shipment ad = new edit_shipment(en1, user1, id1);
            ad.Show();
        }

        private void sortShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sort ad = new Sort(en1, user1, id1);
            ad.Show();
        }

        private void changeStateShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_state_shipment ad = new edit_state_shipment(en1, user1, id1);
            ad.Show();
        }

        private void aDDDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADD_driver ad = new ADD_driver(en1, user1, id1);
            ad.Show();
        }

        private void searchShipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search_shipment ad = new search_shipment(en1, user1, id1);
            ad.Show();
        }

        private void aDDCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADD_city ad = new ADD_city(en1, user1, id1);
            ad.Show();
        }

        private void employee_Click(object sender, EventArgs e)
        {
            Form3 ad = new Form3(en1, user1, id1);
            ad.Show();
        }

        private void addClinet_Click(object sender, EventArgs e)
        {
            Add_clinet ad = new Add_clinet(en1, user1, id1);
            ad.Show();
        }

        private void editClinet_Click(object sender, EventArgs e)
        {
            edit_clinet ad = new edit_clinet(en1, user1, id1);
            ad.Show();
        }

        private void showRecordClinet_Click(object sender, EventArgs e)
        {
            view_record_cliney ad = new view_record_cliney(en1, user1, id1);
            ad.Show();
        }

        private void shipment_Click(object sender, EventArgs e)
        {

        }
    }
}


