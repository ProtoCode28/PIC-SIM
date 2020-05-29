
namespace PicSim
{
    public class Register
    {


        public Register()
        {
            Globals.bank0 = new int[128];//Globale Variable
            Globals.bank1 = new int[128];//
        }
        public void PowerReset()
        {
            Globals.bank0[2] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);     //PCL
            Globals.bank0[3] = int.Parse("0018", System.Globalization.NumberStyles.HexNumber);     //Statusregister Bit0 = c, Bit1 = DC, Bit2 = z; bit3 = PD; bit4 = TO
            Globals.bank0[10] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);    //PCLATH
            Globals.bank0[11] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);    //INTCON

            Globals.bank1[1] = int.Parse("00FF", System.Globalization.NumberStyles.HexNumber);     //OPTION
            Globals.bank1[2] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);     //PCL
            Globals.bank1[3] = int.Parse("0018", System.Globalization.NumberStyles.HexNumber);     //Statusregister
            Globals.bank1[5] = int.Parse("00FF", System.Globalization.NumberStyles.HexNumber);     //TRISA
            Globals.bank1[6] = int.Parse("00FF", System.Globalization.NumberStyles.HexNumber);     //TRISB
            Globals.bank1[8] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);     //nicht benannt
            Globals.bank1[10] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);    //PCLATH
            Globals.bank1[11] = int.Parse("0000", System.Globalization.NumberStyles.HexNumber);    //INTCON
            Globals.programcounter = 0;

        }

        public static void Reset()
        {
            setByte(2, false, "cccccccc");
            setByte(3, false, "cccxxxxx");
            setByte(10, false, "cccccccc");
            setByte(11, false, "cccccccx");

            setByte(1, true, "ssssssss");
            setByte(2, true, "cccccccc");
            setByte(3, true, "cccxxxxx");
            setByte(5, true, "cccsssss");
            setByte(6, true, "ssssssss");
            setByte(8, true, "ccccxccc");
            setByte(10, true, "cccccccc");
            setByte(11, true, "cccccccx");
            Globals.programcounter = 0;

        }

        public static void setByte(int adresse, bool bank, string mask)
        {
            if(mask.Length != 8)
            {
                System.Console.WriteLine("ERROR: length of mask not correct");
                return;
            }
            for (int i = 7; i > 0; i--)
            {
                if (mask[i] == 's')
                {
                    if (bank == false)
                    {
                        Globals.bank0[adresse] |= (1 << (7-i));
                    }
                    else
                    {
                        Globals.bank1[adresse] |= (1 << (7-i));
                    }
                }
                if (mask[i] == 'c')
                {
                    if (bank == false)
                    {
                        Globals.bank0[adresse] &= ~(1 << i);
                    }
                    else
                    {
                        Globals.bank1[adresse] &= ~(1 << i);
                    }
                }
            }
        }



public static void Ausgeben()
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