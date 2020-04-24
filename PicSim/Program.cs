using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PicSim
{
    class Program
    {
        string path;
        int[] hexnumbers;
        int[] programcounter;
        Regex rx;
        int counter = 0;

        public Program(string path)
        {
            this.path = path;
            hexnumbers = new int[1024];
            programcounter = new int[1024];
            rx = new Regex(@"\b\d{4} (\d|\w){4}\b");
            //reg = new Regex(@"[A-F]");
            
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
                    System.Console.WriteLine(result);
                    programcounter[counter] = Umwandelnhex(result);
                    hexnumbers[counter] = Umwandelnprogramcounter(result);
                    counter++;
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
            for (int i = 0; i < counter; i++)
            {
                System.Console.WriteLine(hexnumbers[i]);
                System.Console.WriteLine(programcounter[i]);
            }
        }


        static void Main(string[] args)
        {
            Program T1 = new Program(@"D:\TPicSim1.LST");
            T1.Einlesen();
            T1.Ausgeben();
        }
    }
}
