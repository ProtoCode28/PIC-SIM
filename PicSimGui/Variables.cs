using System.Collections.Generic;
using System.Windows.Forms;

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
        public static float WDT = 0; //variable die hoch oder runter gezählt wird, muss aber ein float sein da abhängig von quarz
        public static float Befehlsdauer; // 4/quartz ergibt dauer in microsekunden
        public static float Quartz; //Werte werden von der GUI zugewiesen Quartz => 1/sekunde
        public static int speed = 500;
        public static bool WDTCheckbox;
        public static int backgroundcolorindex;
        public static bool Interrupt;

        //Timer zählt scheinbar nicht richtig? Muss zero-flag bei Timer überlauf gesetzt werden?
        //Mehrzyklische Befehle verändern prescaler? oder verändern direkt den timer? oder verändern nur Laufzeit?


        //GPR Implementieren
        //Messagebox bei WDT
        //GIE TOIE && TOIF dann addresse 4

    }

}