using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Telephone_Directory
{
    public partial class Phone : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Phone;Integrated Security=True");



        public Phone()
        {
            InitializeComponent();
        }

        private void Phone_Load(Object sender, EventArgs e)
        {

            Display();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       Mobiles
             SET  First ='" + textBox2.Text+"', Last ='"+ textBox3.Text+"', Mobile ='" + textBox4.Text+"', Email ='"+ textBox6.Text+"', Category ='"+ comboBox1.Text+  "'  WHERE (Mobile = '" + textBox4.Text + "')", con);

            cmd.ExecuteNonQuery();




            con.Close();

            MessageBox.Show("Updated Successfully ...!!!!");
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox6.Clear();
            comboBox1.SelectedIndex = -1;
            textBox2.Focus();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Mobiles
                         (First, Last, Mobile, Category, Email)
                         VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "')", con);

            cmd.ExecuteNonQuery();




            con.Close();

            MessageBox.Show("Successfully Saved ...!!!!");
            Display();




        }

        void Display()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobiles", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
             foreach (DataRow item in dt.Rows)
             {
                 int n = dataGridView1.Rows.Add();
                 dataGridView1.Rows[n].Cells[0].Value= item["First"].ToString();
                 dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                 dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                 dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                 dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();

             }

        
    }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           textBox2.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
             SqlCommand cmd = new SqlCommand(@"DELETE FROM Mobiles
              WHERE (Mobile = '" + textBox4.Text +"')", con);

            cmd.ExecuteNonQuery();




            con.Close();

            MessageBox.Show("Successfully ...!!!!");
            Display();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobiles where Mobile like '%" + textBox5.Text+"%' ", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobiles where Mobile like '%" + textBox5.Text + "%' ", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();

            }
        }

       
	
		 
	}
}
