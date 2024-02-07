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
    public partial class Add_Category_Form : Form
    {
        Database_Control dc = new Database_Control();
        public Add_Category_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
               if ( dc.Add_Category(new Category() { Name = textBox1.Text })) { MessageBox.Show("The category is already available.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { MessageBox.Show("The category was successfully added.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
