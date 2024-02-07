﻿using System;
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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "Password")
            {
                MessageBox.Show("Entry Successful.", "Library Management System",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
