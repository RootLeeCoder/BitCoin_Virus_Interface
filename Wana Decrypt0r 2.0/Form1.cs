using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wana_Decrypt0r_2._0
{
    public partial class Form1 : Form
    {
        DateTime d_now = DateTime.Now;
        DateTime d_3 = DateTime.Now.AddDays(3);
        DateTime d_7 = DateTime.Now.AddDays(7);

        private void setColor(int lines)
        {
            if (lines == 1 || lines == 6 || lines == 16 || lines == 24)
                richTextBox1.SelectionFont = new Font("YaHeiConsola", 12, FontStyle.Bold);
            else if (lines == 27)
                richTextBox1.SelectionColor = Color.Red;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int start = 0;
            int count = 1;
            int index = richTextBox1.Text.IndexOf('\n', start);
            while (index > -1)
            {
                richTextBox1.Select(start, index - start);
                setColor(count);
                count++;
                start = index + 1;
                index = richTextBox1.Text.IndexOf('\n', start);
            }
            richTextBox1.Select(start, richTextBox1.Text.Length - start);
            setColor(count);

            label4.Text = d_3.ToString();
            label8.Text = d_7.ToString();
            timer1.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Bitcoin");  //利用Process.Start来打开
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bitcoin.com/");  //利用Process.Start来打开
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            TimeSpan d1 = d_3.Subtract(DateTime.Now);
            label6.Text = d1.Days.ToString() + " : " + d1.Hours.ToString() + " : " +
                          d1.Minutes.ToString() + " : " + d1.Seconds.ToString();
            TimeSpan d2 = d_7.Subtract(DateTime.Now);
            label10.Text = d2.Days.ToString() + " : " + d2.Hours.ToString() + " : " +
                          d2.Minutes.ToString() + " : " + d2.Seconds.ToString();
        }
    }
}
