using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCrawler
{
    public partial class LoginDB : Form
    {
        public LoginDB()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Sign In (Misc Accept button = True)
        {
            Database.SignIN(textBox1.Text, textBox2.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Exit
        {
            Environment.Exit(0);
        }

        private void LoginDB_Load(object sender, EventArgs e)
        {

        }
    }
}
