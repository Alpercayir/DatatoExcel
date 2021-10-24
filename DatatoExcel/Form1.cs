using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace DatatoExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection linking = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Hakan\Desktop\Vehicles.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'");

        void Data() 
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Sayfa1$]", linking);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "0")
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }
        }     
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Data();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Data();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            linking.Open();
            OleDbCommand order = new OleDbCommand("insert into [Sayfa1$] ([Year],[Model],[BodyType],[EngineType],[Status]) values(@p1,@p2,@p3,@p4,@p5)",linking);
            order.Parameters.AddWithValue("@p1", TxtYear.Text);
            order.Parameters.AddWithValue("@p2", TxtModel.Text);
            order.Parameters.AddWithValue("@p3", TxtBodyType.Text);
            order.Parameters.AddWithValue("@p3", TxtEngineType.Text);
            order.Parameters.AddWithValue("@p5", TxtStatus.Text);
            order.ExecuteNonQuery();        
            linking.Close();
            MessageBox.Show("Vehicle has been recorded.","inform",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Data();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            TxtYear.Text = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            TxtModel.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            TxtBodyType.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            TxtEngineType.Text = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            TxtStatus.Text = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            linking.Open();
            OleDbCommand order = new OleDbCommand("update [Sayfa1$] set Model=@p2,BodyType=@p3,EngineType=@p4 where Year=@p1", linking);
            
            order.Parameters.AddWithValue("@p2", TxtModel.Text);
            order.Parameters.AddWithValue("@p3", TxtBodyType.Text);
            order.Parameters.AddWithValue("@p4", TxtEngineType.Text);
            order.Parameters.AddWithValue("@p5", TxtStatus.Text);
            order.Parameters.AddWithValue("@p1", TxtYear.Text);
            order.ExecuteNonQuery();
            linking.Close();
            MessageBox.Show("Information of vehicle has been updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void TxtStatus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
