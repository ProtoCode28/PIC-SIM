using System;
using System.Collections.Generic;
using System.Text;

namespace PicSim
{
    public class Register
    {
  

        public Register()
        {
            Globals.bank0 = new int[128];//Globale Variable
            Globals.bank1 = new int[128];//
        }
        public void Reset()
        {
            Globals.bank0[2] = 00;
            Globals.bank0[3] = 18;
            Globals.bank0[10] = 00;
            Globals.bank0[11] = 00;

            Globals.bank1[1] = int.Parse("00FF", System.Globalization.NumberStyles.HexNumber);
            Globals.bank1[2] = 00;
            Globals.bank1[3] = 18;
            Globals.bank1[5] = int.Parse("FF", System.Globalization.NumberStyles.HexNumber);
            Globals.bank1[6] = int.Parse("FF", System.Globalization.NumberStyles.HexNumber);
            Globals.bank1[8] = 00;
            Globals.bank1[10] = 00;
            Globals.bank1[11] = 00;
            Globals.programcounter = 0;

        }

        public void Ausgeben()
        {
            for (int i = 0; i < 12; i++)
            {
                System.Console.WriteLine("Bank 0:" + "Stelle: " + i + " " + Globals.bank0[i]);
                System.Console.WriteLine("Bank 1:" + "Stelle: " + i + " " + Globals.bank1[i]);

            }
        }
    }
}
    //indirekte adressierung
    //pcl als zieladresse müssen wir überlegen ob wir uns eine methode schreiben die die einzelnen mehtoden aufrufen
    //für UI hilfsmethode die UI regelmäßig refreshed nach jedem Step/execution