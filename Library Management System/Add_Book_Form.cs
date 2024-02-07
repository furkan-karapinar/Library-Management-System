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
    public partial class Add_Book_Form : Form
    {
        Database_Control dc = new Database_Control();
        Book book = null;
        public Add_Book_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && comboBox1.Text != string.Empty)
            {
                book = new Book() { Title = textBox1.Text , Author = textBox2.Text, Category = comboBox1.SelectedValue.ToString() , Barcode = textBox3.Text , ISBN = textBox4.Text};

                if (dc.Add_Book(book) == false) { MessageBox.Show("The book is already available.","Library Management System",MessageBoxButtons.OK,MessageBoxIcon.Error); }
                else { MessageBox.Show("The book was successfully added.", "Library Management System",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);}

            
        }

        private void Add_Book_Form_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = dc.List_Categories();
            
            comboBox1.DisplayMember = "name";

            comboBox1.ValueMember = "id";
        }
    }
}
