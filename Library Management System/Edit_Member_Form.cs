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
    public partial class Edit_Member_Form : Form
    {
        Database_Control dc = new Database_Control();
        Member member = new Member();
        public Edit_Member_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = selectedRow.Cells["id"].Value.ToString();
                textBox3.Text = selectedRow.Cells["name"].Value.ToString();
                textBox4.Text = selectedRow.Cells["surname"].Value.ToString();
                textBox5.Text = selectedRow.Cells["phone"].Value.ToString();
                richTextBox1.Text = selectedRow.Cells["address"].Value.ToString();


                member.name = textBox3.Text;
                member.id = textBox2.Text;
                member.surname = textBox4.Text;
                member.phone = textBox5.Text;
                member.address = richTextBox1.Text;

            }
        }

        private void Edit_Member_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            List<TextBox> texts = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5 };
            foreach (TextBox textBox in texts) { textBox.Clear(); }
            richTextBox1.ResetText();
            dataGridView1.DataSource = dc.List_Members(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox5.Text != String.Empty && richTextBox1.Text != String.Empty)
            {
                if (dc.Delete_Member(member)) { MessageBox.Show("The member was successfully deleted.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("The member could not be deleted.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox5.Text != String.Empty && richTextBox1.Text != String.Empty)
            {
                member.name = textBox3.Text;
                member.surname = textBox4.Text;
                member.phone = textBox5.Text;
                member.address = richTextBox1.Text;


                if (dc.Edit_Member(member)) { MessageBox.Show("Member information has been successfully organized.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Member information could not be edited.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill in the blanks.", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            clear();
        }
    }
}
