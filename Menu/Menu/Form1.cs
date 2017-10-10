using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Form1 : Form
    {
        private string path;
        private bool newfile;
        private string copyText = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Title(string text) {
            Text = text;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream stream = ((sender as OpenFileDialog).OpenFile()) as FileStream)
            {
                byte[] text = new byte[stream.Length];
                stream.Read(text, 0, text.Length);
                RichTextBoxEditor.Text = Encoding.ASCII.GetString(text);
            }
            path = (sender as OpenFileDialog).FileName;
            Title(path);
            newfile = false;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!newfile)
            {
                using (FileStream stream = File.Open(path, FileMode.Open))
                {
                    byte[] text = new byte[RichTextBoxEditor.Text.Length];
                    text = Encoding.ASCII.GetBytes(RichTextBoxEditor.Text);
                    stream.Write(text, 0, text.Length);
                }
                Title(path);
            }
           
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyText = RichTextBoxEditor.SelectedText;
        }
    }
}
