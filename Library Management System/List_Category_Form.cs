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
    public partial class List_Category_Form : Form
    {
        Database_Control dc = new Database_Control();
        public List_Category_Form()
        {
            InitializeComponent();
        }

        private void List_Category_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Categories(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Categories(textBox1.Text);
        }
    }
}
