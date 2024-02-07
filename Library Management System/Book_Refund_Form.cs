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
    public partial class Book_Refund_Form : Form
    {
        Database_Control dc = new Database_Control();
        Order order = null;
        public Book_Refund_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = dc.List_Orders(textBox1.Text, comboBox1.SelectedIndex);
        }

        private void Book_Refund_Form_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = dc.List_Orders(textBox1.Text, comboBox1.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (order != null)
            {
                if (dc.Receive_Book(order))
                {
                    MessageBox.Show("Book refund received.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The book could not be returned.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataGridView1.DataSource = dc.List_Orders(textBox1.Text, comboBox1.SelectedIndex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                int valueOfFirstColumn = Convert.ToInt32(selectedRow.Cells[0].Value);
                order = new Order() { Order_Number = valueOfFirstColumn, Book = new Book()
                {
                    Title = selectedRow.Cells[8].Value.ToString(),
                    Author = selectedRow.Cells[9].Value.ToString(),
                    Category = selectedRow.Cells[10].Value.ToString(),
                    Barcode = selectedRow.Cells[11].Value.ToString(),
                    ISBN = selectedRow.Cells[12].Value.ToString()
                }, Member = selectedRow.Cells[3].Value.ToString() };
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Orders(textBox1.Text, comboBox1.SelectedIndex);
        }
    }
}
