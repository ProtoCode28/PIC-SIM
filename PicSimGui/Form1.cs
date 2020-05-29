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
                    T1.Ausgeben();
                    
                    int pc = Globals.programcounter;
                    for(int i = 0; i <= pc; i++ )
                    {
                        string pm = Globals.programmemory[i].ToString("X");
                        string counter = i.ToString("X");
                        Ausgabe.Items.Add(counter).SubItems.Add(pm);
                    }
                    Globals.programcounter = 0; //nötiger reset sonst wird programm beim letzten befehl gestartet
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(Globals.speed);
                    but.StepButton();
                }
            }
        }
        private void Go_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Step_Click(object sender, EventArgs e)
        {
            //Buttons.StepButton();
            but.StepButton();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Register R1 = new Register();
            R1.PowerReset();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Globals.Quartz = 32;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Globals.Quartz = 64;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Globals.Quartz = 128;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Globals.speed = 5000;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                Globals.speed = 500;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                Globals.speed = 50;
            }
        }
    }
}
