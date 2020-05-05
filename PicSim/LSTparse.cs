using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PicSim
{
    
    public class LSTParse
    {
        
        string path;
        
        Regex rx;
        
      
        public LSTParse(string path)
        {
            this.path = path;
            Globals.programmemory = new int[1024];

            rx = new Regex(@"\b\d{4} (\d|\w){4}\b");
        }

        public void Einlesen()
        {
            string line;
            MatchCollection matches;
            System.IO.StreamReader file = new System.IO.StreamReader(@path);

            while ((line = file.ReadLine()) != null)
            {
                matches = rx.Matches(line);
                foreach (Match match in matches)
                {
                    string result = match.Value;
                    //System.Console.WriteLine(result);
                
                    Globals.programmemory[Globals.programcounter = Umwandelnprogramcounter(result)] = Umwandelnhex(result);
                    

                }
            }
            file.Close();
        }

        public int Umwandelnhex(string res)
        {
            Regex rx = new Regex(@"\b (\d|\w){4}\b");
            Match match = rx.Match(res);
            string var = match.Value;
            int result = int.Parse(var, System.Globalization.NumberStyles.HexNumber);
            return result;
        }



        public int Umwandelnprogramcounter(string res)
        {
            Regex rx = new Regex(@"\b\d{4} \b");
            Match match = rx.Match(res);
            string var = match.Value;
            int result = Convert.ToInt32(var);
            return result;
        }

        public void Ausgeben()
        {
            for (int i = 0; i < Globals.programcounter; i++)
            {
                System.Console.WriteLine(Globals.programmemory[i]);
                System.Console.WriteLine(Globals.programcounter);
            }
        }
 
        public int Transferprogrammemory(int i)
        {
            return Globals.programmemory[i];
        }

        static void Main(string[] args)
        {
            LSTParse T1 = new LSTParse(@"D:\TPicSim1.LST");
            T1.Einlesen();
            T1.Ausgeben();
            Register R1 = new Register();
            R1.Reset();
            //R1.Ausgeben();
            //Commands cmd = new Commands();
            //cmd.Switchcase(Globals.programcounter); wird von buttons aufgerufen

            Buttons but = new Buttons();
            but.StepButton();
            but.StepButton();



        }
    }
}
