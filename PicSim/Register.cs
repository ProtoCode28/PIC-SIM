using System;
using System.Collections.Generic;
using System.Text;

namespace PicSim
{
    public class Register
    {

        int[] bank0;
        int[] bank1;

        public Register()
        {
            bank0 = new int[128];
            bank1 = new int[128];
        }
        public void Reset()
        {
            bank0[2] = 00;
            bank0[3] = 18;
            bank0[10] = 00;
            bank0[11] = 00;

            bank1[1] = int.Parse("00FF", System.Globalization.NumberStyles.HexNumber);
            bank1[2] = 00;
            bank1[3] = 18;
            bank1[5] = int.Parse("FF", System.Globalization.NumberStyles.HexNumber);
            bank1[6] = int.Parse("FF", System.Globalization.NumberStyles.HexNumber);
            bank1[8] = 00;
            bank1[10] = 00;
            bank1[11] = 00;
        }

        public void Ausgeben()
        {
            for (int i = 0; i < 12; i++)
            {
                System.Console.WriteLine("Bank 0:" + "Stelle: " + i + " " + bank0[i]);
                System.Console.WriteLine("Bank 1:" + "Stelle: " + i + " " + bank1[i]);

            }
        }
    }
}
    //indirekte adressierung
    //pcl als zieladresse müssen wir überlegen ob wir uns eine methode schreiben die die einzelnen mehtoden aufrufen