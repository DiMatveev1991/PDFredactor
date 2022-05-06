using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using F_res;
using ConsoleApp20;
using pdfslit;

namespace MasterPoveritel2
{
    public partial class Form1 : Form
    {
        Parsimfile myclass = new Parsimfile();
       



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox1.Text = fbd.SelectedPath;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox2.Text = fbd.SelectedPath;
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox1.Text)) || (String.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("неверная дирректория");

            }
            else
            {
                myclass.df(textBox1.Text, textBox2.Text);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox1.Text)) || (String.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("неверная дирректория");

            }
            else
            {
                slitpdf.Merge(textBox2.Text);

            }

        }
    }
}
