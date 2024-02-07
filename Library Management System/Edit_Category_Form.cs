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
    public partial class Edit_Category_Form : Form
    {
        Database_Control dc = new Database_Control();
        public Edit_Category_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            List<TextBox> texts = new List<TextBox>() { textBox1, textBox2, textBox3 };
            foreach (TextBox textBox in texts) { textBox.Clear(); }
            dataGridView1.DataSource = dc.List_Categories(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty)
            {
                if (dc.Delete_Category(Convert.ToInt32(textBox2.Text))) { MessageBox.Show("The category was successfully deleted", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("The category could not be deleted", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                clear();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty)
            {
                if (dc.Edit_Category(new Category() { Name = textBox3.Text }, Convert.ToInt32(textBox2.Text))) { MessageBox.Show("Category name successfully updated.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("The category name could not be updated.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = selectedRow.Cells["id"].Value.ToString();
                textBox3.Text = selectedRow.Cells["name"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Categories(textBox1.Text);
        }

        private void Edit_Category_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Categories(textBox1.Text);
        }
    }
}
