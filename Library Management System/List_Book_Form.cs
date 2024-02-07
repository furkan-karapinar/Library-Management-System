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
    public partial class List_Book_Form : Form
    {
        Database_Control dc = new Database_Control();
        public List_Book_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Books(textBox1.Text);
            dataGridView1.Columns["id"].Visible = false;
        }

        private void List_Book_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Books(textBox1.Text);
            dataGridView1.Columns["id"].Visible = false;
        }
    }
}
