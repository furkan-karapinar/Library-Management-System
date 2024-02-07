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
    public partial class Add_Member_Form : Form
    {
        Member member = null;
        Database_Control dc = new Database_Control();
        public Add_Member_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty)
            {
                member = new Member() { name = textBox1.Text, surname = textBox2.Text, id = textBox3.Text, phone = textBox4.Text, address = textBox5.Text };

                if (dc.Add_Member(member) == false) { MessageBox.Show("Failed to add a member.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { MessageBox.Show("Member successfully added", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
