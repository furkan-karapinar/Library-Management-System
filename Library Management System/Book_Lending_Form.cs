using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Book_Lending_Form : Form
    {
        Database_Control dc = new Database_Control();

        Catalog catalog = null;
        string member_id = null;
        public Book_Lending_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           dataGridView2.DataSource =  dc.List_Categories_With_CheckBox(textBox2.Text);
            dataGridView2.Columns["id"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            catalog = new Catalog();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value == true)
                    {
                        catalog.Add_Book(row.Cells[4].Value.ToString(),new Book() { Title = row.Cells[2].Value.ToString() , Author = row.Cells[3].Value.ToString() ,
                        Category = row.Cells[4].Value.ToString() , Barcode = row.Cells[5].Value.ToString() , ISBN = row.Cells[6].Value.ToString() });

                        list.Add(row.Cells[2].Value.ToString());
                       
                        if (dc.Add_Orders(member_id,row.Cells[1].Value.ToString(), dateTimePicker1.Value, dateTimePicker2.Value))
                        {
                            MessageBox.Show("The book was lent.", "Library Management System" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }else
                        {
                            MessageBox.Show("The book could not be lent.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }

            if (list.Count == 0 && label6.Text == "-")
            {
                MessageBox.Show("Please select person and books.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Makbuz ve Fatura

            }
            
        }

        private void Book_Lending_Form_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = dc.List_Categories_With_CheckBox(textBox2.Text);
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
            dataGridView2.Columns["id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string cell2Value = selectedRow.Cells[1].Value.ToString();
                string cell3Value = selectedRow.Cells[2].Value.ToString();

                label6.Text = cell2Value + " " + cell3Value;
                member_id = selectedRow.Cells[0].Value.ToString();
            }
        }
    }
}
