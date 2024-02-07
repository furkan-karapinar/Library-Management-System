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
    public partial class List_Member_Form : Form
    {
        Database_Control dc = new Database_Control();
        public List_Member_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
        }

        private void List_Member_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
        }
    }
}
