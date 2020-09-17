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

namespace letter_scrambler
{
    public partial class Form1 : Form
    {
        string line;      
            string[] fonts = new string[] {"Arial","Courier New","Helvetica","Tahoma","Palatino","Times New Roman","Courier","Comic Sans MS","Impact"};
        string nameOfFile = "test.txt";
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (nameOfFile == "test.txt")
            {
                richTextBox1.Text = "please select a file first";
                
            }
            else
            {
            generateText(nameOfFile);
            mixFonts(fonts);
            }


        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // reads what's in the linked .txt document en puts it in the textbox
        public void generateText(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                line = sr.ReadLine();


                while (line != null)
                {

                    richTextBox1.Text += line;
                    richTextBox1.AppendText(Environment.NewLine);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                richTextBox1.Text = "exception: " + e.Message;
            }
        }
// changes the font of given text
        public void mixFonts(string[] fonts)
        {
                Random rand = new Random();
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                richTextBox1.SelectionFont = new Font(fonts[rand.Next(0, fonts.Length)], 12, FontStyle.Regular);
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        // file select and returning filename
        private void fileSelect_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                string type = selectedFile.Substring((selectedFile.Length - 3), 3);
                if (type == "txt")
                {
                    nameOfFile = selectedFile;
                }
                else
                {
                    richTextBox1.Text = "file must be a .txt file";
                }
            }
        }
    }
}
