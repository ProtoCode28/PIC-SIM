using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSim
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            LSTParse T1 = new LSTParse(@"C:\vm\TPicSim6.LST"); //Pfad Marcel @"D:\TPicSim6.LST" //Pfad Max @"C:\vm\TPicSim6.LST"
            T1.Einlesen();
            T1.Ausgeben();
            Register R1 = new Register();
            R1.PowerReset();
            //R1.Ausgeben();
            //Commands cmd = new Commands();
            //cmd.Switchcase(Globals.programcounter); wird von buttons aufgerufen

            Buttons but = new Buttons();
            /*  but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton();
              but.StepButton(); */

            but.GoButton();

        }
    }
}
