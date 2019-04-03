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
    public partial class MainForm : Form
    {
        List<string> ArticleList = new List<string> { };
        int index = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e) // Все новости
        {
            index = 0;
            ArticleList = Database.ShowArticles();
            label2.Text = (index + 1).ToString() + "/" + ArticleList.Count();
            richTextBox1.Text = ArticleList[index];
            richTextBox1.Refresh();
            label2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e) // Выход
        {
            this.Close(); 
        }

        private void button4_Click(object sender, EventArgs e) // Поиск по ключу
        {
            index = 0;
            ArticleList = Database.SearchNotesByKey(textBox2.Text);
            label2.Text = (index + 1).ToString() + "/" + ArticleList.Count();
            richTextBox1.Text = ArticleList[index];
            richTextBox1.Refresh();
            label2.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Поле для ввода заголовка
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // Поиск по заголовку
        {
            index = 0;
            ArticleList = Database.SearchNoteByTitle(textBox1.Text);
            label2.Text = (index + 1).ToString() + "/" + ArticleList.Count();
            richTextBox1.Text = ArticleList[index];
            richTextBox1.Refresh();
            label2.Refresh();
        }

        private void button6_Click(object sender, EventArgs e) // Назад
        {
            --index;
            if (index < 0)
                index = 0;
            label2.Text = (index + 1).ToString() + "/" + ArticleList.Count();
            richTextBox1.Text = ArticleList[index];
            richTextBox1.Refresh();
            label2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e) // Дальше
        {
            ++index;
            if (index > ArticleList.Count - 1)
                index = ArticleList.Count - 1;
            label2.Text = (index + 1).ToString() + "/" + ArticleList.Count();
            richTextBox1.Text = ArticleList[index];
            richTextBox1.Refresh();
            label2.Refresh();
        }

        private void label2_Click(object sender, EventArgs e) // Счетчик
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // Поле для ввода ключевого слова
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
