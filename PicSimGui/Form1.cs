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
                Globals.Quartz = 100;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Globals.Quartz = 500;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                Globals.Quartz = 1000;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                Globals.Quartz = 2000;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                Globals.Quartz = 4000;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                Globals.Quartz = 8000;
            }
            if (comboBox1.SelectedIndex == 7)
            {
                Globals.Quartz = 12000;
            }
            if (comboBox1.SelectedIndex == 8)
            {
                Globals.Quartz = 16000;
            }
            if (comboBox1.SelectedIndex == 9)
            {
                Globals.Quartz = 20000;
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
           if((Globals.bank0[5] & 0b0001_0000) == 16)
            {
                Globals.bank0[5] -= 16; 
            }
           else
            {
                Globals.bank0[5] += 16;
            }
            UpdateGUI();
        }

        private void RA3_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_1000) == 8)
            {
                Globals.bank0[5] -= 8;
            }
            else
            {
                Globals.bank0[5] += 8;
            }
            UpdateGUI();
        }

        private void RA2_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_0100) == 4)
            {
                Globals.bank0[5] -= 4;
            }
            else
            {
                Globals.bank0[5] += 4;
            }
            UpdateGUI();
        }

        private void RA1_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[5] & 0b0000_0010) == 2)
            {
                Globals.bank0[5] -= 2;
            }
            else
            {
                Globals.bank0[5] += 2;
            }
            UpdateGUI();
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
            UpdateGUI();
        }

        private void RB7_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b1000_0000) == 128)
            {
                Globals.bank0[6] -= 128;
            }
            else
            {
                Globals.bank0[6] += 128;
            }
            UpdateGUI();
        }

        private void RB6_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0100_0000) == 64)
            {
                Globals.bank0[6] -= 64;
            }
            else
            {
                Globals.bank0[6] += 64;
            }
            UpdateGUI();
        }

        private void RB5_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0010_0000) == 32)
            {
                Globals.bank0[6] -= 32;
            }
            else
            {
                Globals.bank0[6] += 32;
            }
            UpdateGUI();
        }

        private void RB4_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0001_0000) == 16)
            {
                Globals.bank0[6] -= 16;
            }
            else
            {
                Globals.bank0[6] += 16;
            }
            UpdateGUI();
        }

        private void RB3_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0000_1000) == 8)
            {
                Globals.bank0[6] -= 8;
            }
            else
            {
                Globals.bank0[6] += 8;
            }
            UpdateGUI();
        }

        private void RB2_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b0000_0100) == 4)
            {
                Globals.bank0[6] -= 4;
            }
            else
            {
                Globals.bank0[6] += 4;
            }
            UpdateGUI();
        }

        private void RB1_Click(object sender, EventArgs e)
        {
            if ((Globals.bank0[6] & 0b1000_0010) == 2)
            {
                Globals.bank0[6] -= 2;
            }
            else
            {
                Globals.bank0[6] += 2;
            }
            UpdateGUI();
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
            UpdateGUI();
        }
        private void UpdateGUI()
        {
            Watchdogvalue.Text = Globals.WDT.ToString();
            WregisterVALUE.Text = Globals.w.ToString();
            PrescalerVALUE.Text = "1:" + Globals.prescaler.ToString();

            IRPVALUE.Text = ((Globals.bank0[3] & 0b1000_0000) >> 7).ToString();
            RP1VALUE.Text = ((Globals.bank0[3] & 0b0100_0000) >> 6).ToString();
            RP0VALUE.Text = ((Globals.bank0[3] & 0b0010_0000) >> 5).ToString();
            TOVALUE.Text = ((Globals.bank0[3] & 0b0001_0000) >> 4).ToString();
            PDVALUE.Text = ((Globals.bank0[3] & 0b0000_1000) >> 3).ToString();
            ZVALUE.Text = ((Globals.bank0[3] & 0b0000_0100) >> 2).ToString();
            DCVALUE.Text = ((Globals.bank0[3] & 0b0000_0010) >> 1).ToString();
            CVALUE.Text = (Globals.bank0[3] & 0b0000_0001).ToString();

            RBPUVALUE.Text = ((Globals.bank1[1] & 0b1000_0000) >> 7).ToString();
            INTEDGVALUE.Text = ((Globals.bank1[1] & 0b0100_0000) >> 6).ToString();
            T0CSVALUE.Text = ((Globals.bank1[1] & 0b0010_0000) >> 5).ToString();
            T0SEVALUE.Text = ((Globals.bank1[1] & 0b0001_0000) >> 4).ToString();
            PSAVALUE.Text = ((Globals.bank1[1] & 0b0000_1000) >> 3).ToString();
            PS2VALUE.Text = ((Globals.bank1[1] & 0b0000_0100) >> 2).ToString();
            PS1VALUE.Text = ((Globals.bank1[1] & 0b0000_0010) >> 1).ToString();
            PS0VALUE.Text = (Globals.bank1[1] & 0b0000_0001).ToString();

            GIEVALUE.Text = ((Globals.bank0[11] & 0b1000_0000) >> 7).ToString();
            EEIEVALUE.Text = ((Globals.bank0[11] & 0b0100_0000) >> 6).ToString();
            T0IEVALUE.Text = ((Globals.bank0[11] & 0b0010_0000) >> 5).ToString();
            INTEVALUE.Text = ((Globals.bank0[11] & 0b0001_0000) >> 4).ToString();
            RBIEVALUE.Text = ((Globals.bank0[11] & 0b0000_1000) >> 3).ToString();
            T0IFVALUE.Text = ((Globals.bank0[11] & 0b0000_0100) >> 2).ToString();
            INTFVALUE.Text = ((Globals.bank0[11] & 0b0000_0010) >> 1).ToString();
            RBIFVALUE.Text = (Globals.bank0[11] & 0b0000_0001).ToString();

            RA4VALUE.Text = ((Globals.bank0[5] & 0b0001_0000) >> 4).ToString();
            RA3VALUE.Text = ((Globals.bank0[5] & 0b0000_1000) >> 3).ToString();
            RA2VALUE.Text = ((Globals.bank0[5] & 0b0000_0100) >> 2).ToString();
            RA1VALUE.Text = ((Globals.bank0[5] & 0b0000_0010) >> 1).ToString();
            RA0VALUE.Text = (Globals.bank0[5] & 0b0000_0001).ToString();

            RB7VALUE.Text = ((Globals.bank0[6] & 0b1000_0000) >> 7).ToString();
            RB6VALUE.Text = ((Globals.bank0[6] & 0b0100_0000) >> 6).ToString();
            RB5VALUE.Text = ((Globals.bank0[6] & 0b0010_0000) >> 5).ToString();
            RB4VALUE.Text = ((Globals.bank0[6] & 0b0001_0000) >> 4).ToString();
            RB3VALUE.Text = ((Globals.bank0[6] & 0b0000_1000) >> 3).ToString();
            RB2VALUE.Text = ((Globals.bank0[6] & 0b0000_0100) >> 2).ToString();
            RB1VALUE.Text = ((Globals.bank0[6] & 0b0000_0010) >> 1).ToString();
            RB0VALUE.Text = (Globals.bank0[6] & 0b0000_0001).ToString();
        }
    }
}
