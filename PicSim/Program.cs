using System;

namespace PicSim
{
    class Program
    {
        string path;
        int[] buffer;
        int counter = 0;
        public Program(string path)
        {
            this.path = path;
            this.buffer = new int[1024];
        }

        public void einlesen()
        {
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@path);

            while ((line = file.ReadLine()) != null)
            {
                buffer[counter] = Convert.ToInt32(line);
                counter++;

            }

            file.Close();
        }
        public void ausgeben()
        {
            for(int i = 0; i < counter; i++)
            {
                System.Console.WriteLine(buffer[i]);
            }
        }


        static void Main(string[] args)
        {
            Program T1 = new Program(@"D:\TPicSim1.LST");
            T1.einlesen();
            T1.ausgeben();
        }
    }
}
