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
    public partial class UpdateNews : Form
    {
        public UpdateNews()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Wait"; 
            AbotClass.Conf();
            label1.Text = "OK"; 
         }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void UpdateNews_Load(object sender, EventArgs e)
        {

        }
    }
}
