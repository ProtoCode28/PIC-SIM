using System.Collections.Generic;

namespace PicSim
{
    public static class Globals
    {
        public static int programcounter; // Modifiable
        public static int[] programmemory;
        public static int w;
        public static int[] bank0;
        public static int[] bank1;
        public static Stack<int> stack;
        public static int prescaler; //auch einfach eine variable, die je nach dem ob der WDT oder der TMR0 sie verwendet, angepasst wird
        public static float WDT; //variable die hoch oder runter gezählt wird, muss aber ein float sein da abhängig von quarz
        public static int Befehlsdauer; // 4/quartz ergibt dauer in microsekunden
        public static float Quartz; //Werte werden von der GUI zugewiesen Quartz => 1/sekunde
        public static int speed = 500;
      
        
    }

}