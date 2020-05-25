using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSimGui
{
    public partial class Form1 : Form
    {
        private Button selectButton;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            selectButton = new Button
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select file"
            };
            selectButton.Click += new EventHandler(SelectButton_Click);
            textBox1 = new TextBox
            {
                Size = new Size(300, 300),
                Location = new Point(15, 40),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            ClientSize = new Size(330, 360);
            Controls.Add(selectButton);
            Controls.Add(textBox1);
        }
        private void SetText(string text)
        {
            textBox1.Text = text;
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    SetText(sr.ReadToEnd());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void selectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        Process.Start("notepad.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
