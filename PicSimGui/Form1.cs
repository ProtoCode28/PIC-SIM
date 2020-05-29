using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSim
{
    public partial class Form1 : Form
    {
        Buttons but = new Buttons();
        public Form1()
        {
            InitializeComponent();
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            
            
            Ausgabe.Text = "";
            

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    Register R1 = new Register();
                    R1.PowerReset();
              
                    LSTParse T1 = new LSTParse(filePath);
                    T1.Einlesen();
                    
                    int pc = Globals.programcounter;
                    for(int i = 0; i <= pc; i++ )
                    {
                        string pm = Globals.programmemory[i].ToString("X");
                        string counter = i.ToString("X");
                        Ausgabe.Items.Add(counter).SubItems.Add(pm);
                    }
                }
            }
        }

        private void Go_Click(object sender, EventArgs e)
        {
            but.GoButton();
            //Buttons.GoButton();
        }

        private void Step_Click(object sender, EventArgs e)
        {
            //Buttons.StepButton();
            but.StepButton();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
