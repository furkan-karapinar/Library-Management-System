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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Book_Form add_Book_Form = new Add_Book_Form();
            add_Book_Form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Edit_Book_Form edit_Book_Form = new Edit_Book_Form();
            edit_Book_Form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List_Book_Form list_Book_Form = new List_Book_Form();
            list_Book_Form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Member_Form add_Member_Form = new Add_Member_Form();
            add_Member_Form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Edit_Member_Form edit_Member_Form = new Edit_Member_Form();
            edit_Member_Form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List_Member_Form list_Member_Form = new List_Member_Form();
            list_Member_Form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Add_Category_Form add_Category_Form = new Add_Category_Form();
            add_Category_Form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Edit_Category_Form edit_Category_Form = new Edit_Category_Form();
            edit_Category_Form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List_Category_Form list_Category_Form = new List_Category_Form();
            list_Category_Form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Book_Lending_Form book_Lending_Form = new Book_Lending_Form();
            book_Lending_Form.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            List_Loaned_Books_Form list_Loaned_Books_Form = new List_Loaned_Books_Form();
            list_Loaned_Books_Form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Book_Refund_Form book_Refund_Form = new Book_Refund_Form();
            book_Refund_Form.ShowDialog();
        }
    }
}
