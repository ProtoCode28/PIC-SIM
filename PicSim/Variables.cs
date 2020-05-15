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
        public static int prescaler;
        public static int WDT;
    }

}