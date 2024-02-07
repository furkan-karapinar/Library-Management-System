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
    public partial class Edit_Book_Form : Form
    {
        Database_Control dc = new Database_Control();

        Book book = new Book();

        public Edit_Book_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Books(textBox1.Text);
            dataGridView1.Columns["id"].Visible = false;
        }

        private void Edit_Book_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Books(textBox1.Text);
            dataGridView1.Columns["id"].Visible = false;
            comboBox1.DataSource = dc.List_Categories();

            comboBox1.DisplayMember = "name";

            comboBox1.ValueMember = "id";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = selectedRow.Cells["isbn"].Value.ToString();
                textBox3.Text = selectedRow.Cells["title"].Value.ToString();
                textBox4.Text = selectedRow.Cells["author"].Value.ToString();
                comboBox1.Text = selectedRow.Cells["category"].Value.ToString();
                textBox5.Text = selectedRow.Cells["barcode"].Value.ToString();


                book.Title = textBox3.Text;
                book.ISBN = textBox2.Text;
                book.Author = textBox4.Text;
                book.Barcode = textBox5.Text;
                book.Category = comboBox1.SelectedValue.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            List<TextBox> texts = new List<TextBox>() { textBox1 , textBox2,textBox3,textBox4,textBox5 };
            foreach (TextBox textBox in texts) { textBox.Clear(); }
            comboBox1.ResetText();
            dataGridView1.DataSource = dc.List_Books(textBox1.Text);
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && comboBox1.Text != String.Empty)
            {
                if ( dc.Delete_Book(book)) { MessageBox.Show("The book was successfully deleted", "Library Management System" , MessageBoxButtons.OK,MessageBoxIcon.Information); }
                else { MessageBox.Show("The book could not be deleted", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && comboBox1.Text != String.Empty)
            {
                book.Title = textBox3.Text;
                book.Author = textBox4.Text;
                book.Barcode = textBox5.Text;
                book.Category = comboBox1.SelectedValue.ToString();

                if (dc.Edit_Book(book)) { MessageBox.Show("Book information has been successfully organized.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Book information could not be edited.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            clear();
        }
    }
}
