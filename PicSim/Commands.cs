using System;
using System.Collections.Generic;
using System.Text;

namespace PicSim
{
    class Commands
    {
        public void Switchcase()
        {
            LSTParse lst = new LSTParse(@"D:\TPicSim1.LST");
            for (int i = 0; i<1024; i++)
            {
                switch  (lst.Transfer(i))
                {
                        case int n when(n >= 0b00_0111_0000_0000 && n < 0b00_0111_1111_1111): Command_ADDWF(command); break; //DONE


                }
            }
        }10

        public void ADDWF()
        {
           

        }

        public void ANDWF()
        {

        }

        public void CLRF()
        {

        }

        public void CLRW()
        {

        }

        public void COMF()
        {

        }

        public void DECF()
        {

        }
        public void DECFSZ()
        {

        }
        public void INCF()
        {

        }
        public void INCFSZ()
        {

        }
        public void IORWF()
        {

        }
        public void MOVF()
        {

        }
        public void MOVWF()
        {

        }
        public void NOP()
        {

        }
        public void RLF()
        {

        }
        public void RRF()
        {

        }
        public void SUBWF()
        {

        }
        public void SWAPF()
        {

        }
        public void XORWF()
        {

        }
        public void BCF()
        {

        }
        public void BSF()
        {

        }
        public void BTFSC()
        {

        }
        public void BTFSS()
        {

        }
        public void ADDLW()
        {

        }
        public void ANDLW()
        {

        }
        public void CALL()
        {

        }
        public void CLRWDT()
        {

        }
        public void GOTO()
        {

        }
        public void IORLW()
        {

        }
        public void MOVLW()
        {

        }
        public void RETFIE()
        {

        }
        public void RETLW()
        {

        }
        public void RETURN()
        {

        }
        public void SLEEP()
        {

        }
        public void SUBLW()
        {

        }
        public void XORLW()
        {

        }

    }
}
