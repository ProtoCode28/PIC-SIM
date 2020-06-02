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
                    Globals.programcounter = 0; //nötiger reset sonst wird programm beim letzten befehl gestartet
                }
            }
            UpdateGUI();
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
                    UpdateGUI();
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
            UpdateGUI();
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

        private void WTDTMR_CheckedChanged(object sender, EventArgs e)
        {
            if(WTDTMR.Checked)
            {
                Globals.WDTCheckbox = true;
                Console.WriteLine("checkbox true");
            }
            else
            {
                Globals.WDTCheckbox = false;
                Console.WriteLine("checkbox false");
            }
        }

        private void RA4_Click(object sender, EventArgs e)
        {
           if((Globals.bank0[5] & 0b0001_0000) == 1)
            {
                Globals.bank0[5] -= 16; 
            }
           else
            {
                Globals.bank0[5] += 16;
            }
        }

        private void RA3_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_1000) == 1)
            {
                Globals.bank0[5] -= 8;
            }
            else
            {
                Globals.bank0[5] += 8;
            }
        }

        private void RA2_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_0100) == 1)
            {
                Globals.bank0[5] -= 4;
            }
            else
            {
                Globals.bank0[5] += 4;
            }
        }

        private void RA1_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_0010) == 1)
            {
                Globals.bank0[5] -= 2;
            }
            else
            {
                Globals.bank0[5] += 2;
            }
        }

        private void RA0_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_0001) == 1)
            {
                Globals.bank0[5] -= 1;
            }
            else
            {
                Globals.bank0[5] += 1;
            }
        }

        private void RB7_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b1000_0000) == 1)
            {
                Globals.bank0[6] -= 128;
            }
            else
            {
                Globals.bank0[6] += 128;
            }
        }

        private void RB6_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0100_0000) == 1)
            {
                Globals.bank0[6] -= 64;
            }
            else
            {
                Globals.bank0[6] += 64;
            }
        }

        private void RB5_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0010_0000) == 1)
            {
                Globals.bank0[6] -= 32;
            }
            else
            {
                Globals.bank0[6] += 32;
            }
        }

        private void RB4_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0001_0000) == 1)
            {
                Globals.bank0[6] -= 16;
            }
            else
            {
                Globals.bank0[6] += 16;
            }
        }

        private void RB3_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0000_1000) == 1)
            {
                Globals.bank0[6] -= 8;
            }
            else
            {
                Globals.bank0[6] += 8;
            }
        }

        private void RB2_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0000_0100) == 1)
            {
                Globals.bank0[6] -= 4;
            }
            else
            {
                Globals.bank0[6] += 4;
            }
        }

        private void RB1_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b1000_0010) == 1)
            {
                Globals.bank0[6] -= 2;
            }
            else
            {
                Globals.bank0[6] += 2;
            }
        }

        private void RB0_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0000_0001) == 1)
            {
                Globals.bank0[6] -= 1;
            }
            else
            {
                Globals.bank0[6] += 1;
            }
        }
        private void UpdateGUI()
        {
            IRPVALUE.Text = (Globals.bank0[3] >> 7).ToString();
            //RP1VALUE.Text = (Globals.bank0[3] >> 7).ToString();
            //RP0VALUE.Text = (Globals.bank0[3] >> 7).ToString();
            //IRPVALUE.Text = (Globals.bank0[3] >> 7).ToString();
        }
    }
}
