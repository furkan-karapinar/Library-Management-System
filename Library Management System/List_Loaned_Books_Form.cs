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
    public partial class List_Loaned_Books_Form : Form
    {
        Database_Control dc = new Database_Control();
        public List_Loaned_Books_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Orders(textBox1.Text,comboBox1.SelectedIndex); 
        }

        private void List_Loaned_Books_Form_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = dc.List_Orders(textBox1.Text,comboBox1.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Orders(textBox1.Text, comboBox1.SelectedIndex);
        }
    }
}
