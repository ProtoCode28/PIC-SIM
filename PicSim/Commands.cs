using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace PicSim
{
    class Commands
    {
        
        Regex rx;
        
        public void Switchcase(int pc) //pc ist programcounter
        {
            for(int i = 0; i <= pc; i++) //muss durch stepbutton methode ersetzt werden
            { 

                switch  (Globals.programmemory[i])
                {
                    case int n when (n >= 0b00_0111_0000_0000 && n < 0b00_0111_1111_1111): ADDWF(); break; //DONE
                    case int n when (n >= 0b00_0101_0000_0000 && n < 0b00_0101_1111_1111): ANDWF(); break; //DONE
                    case int n when (n >= 0b00_0001_1000_0000 && n < 0b00_0001_1111_1111): CLRF(); break; //DONE
                    case int n when (n >= 0b00_0001_0000_0000 && n < 0b00_0001_0111_1111): CLRW(); break; //DONE
                    case int n when (n >= 0b00_1001_0000_0000 && n < 0b00_1001_1111_1111): COMF(); break; //DONE
                    case int n when (n >= 0b00_0011_0000_0000 && n < 0b00_0011_1111_1111): DECF(); break; //DONE
                    case int n when (n >= 0b00_1011_0000_0000 && n < 0b00_1011_1111_1111): DECFSZ(); break; //DONE
                    case int n when (n >= 0b00_1010_0000_0000 && n < 0b00_1010_1111_1111): INCF(); break; //DONE
                    case int n when (n >= 0b00_1111_0000_0000 && n < 0b00_1111_1111_1111): INCFSZ(); break; //DONE
                    case int n when (n >= 0b00_0100_0000_0000 && n < 0b00_0100_1111_1111): IORWF(); break; //DONE
                    case int n when (n >= 0b00_1000_0000_0000 && n < 0b00_1000_1111_1111): MOVF(); break; //DONE
                    case int n when (n >= 0b00_0000_1000_0000 && n < 0b00_0000_1111_1111): MOVWF(); break; //DONE
                    case int n when (n >= 0b00_0000_0000_0000 && n < 0b00_0000_0110_0000): NOP(); break; //DONE
                    case int n when (n >= 0b00_1101_0000_0000 && n < 0b00_1101_1111_1111): RLF(); break; //DONE
                    case int n when (n >= 0b00_1100_0000_0000 && n < 0b00_1100_1111_1111): RRF(); break; //DONE
                    case int n when (n >= 0b00_0010_0000_0000 && n < 0b00_0010_1111_1111): SUBWF(); break; //DONE
                    case int n when (n >= 0b00_1110_0000_0000 && n < 0b00_1110_1111_1111): SWAPF(); break; //DONE
                    case int n when (n >= 0b00_0110_0000_0000 && n < 0b00_0110_1111_1111): XORWF(); break; //DONE
                    case int n when (n >= 0b01_0000_0000_0000 && n < 0b01_0011_1111_1111): BCF(); break; //DONE
                    case int n when (n >= 0b01_0100_0000_0000 && n < 0b01_0111_1111_1111): BSF(); break; //DONE
                    case int n when (n >= 0b01_1000_0000_0000 && n < 0b01_1011_1111_1111): BTFSC(); break; //DONE
                    case int n when (n >= 0b01_1100_0000_0000 && n < 0b01_1111_1111_1111): BTFSS(); break; //DONE
                    case int n when (n >= 0b11_1110_0000_0000 && n < 0b11_1111_1111_1111): ADDLW(); break; //DONE
                    case int n when (n >= 0b11_1001_0000_0000 && n < 0b11_1001_1111_1111): ANDLW(); break; //DONE
                    case int n when (n >= 0b10_0000_0000_0000 && n < 0b10_0111_1111_1111): CALL(); break; //DONE
                    case int n when (n >= 0b00_0000_0110_0100 && n < 0b00_0000_0110_0100): CLRWDT(); break; //DONE
                    case int n when (n >= 0b10_1000_0000_0000 && n < 0b10_1111_1111_1111): GOTO(); break; //DONE
                    case int n when (n >= 0b11_1000_0000_0000 && n < 0b11_1000_1111_1111): IORLW(); break; //DONE
                    case int n when (n >= 0b11_0000_0000_0000 && n < 0b11_0011_1111_1111): MOVLW(); System.Console.WriteLine("ok"); break; //DONE
                    case int n when (n >= 0b00_0000_0000_1001 && n < 0b00_0000_0000_1001): RETFIE(); break; //DONE
                    case int n when (n >= 0b11_0100_0000_0000 && n < 0b11_0111_1111_1111): RETLW(); break; //DONE
                    case int n when (n >= 0b00_0000_0000_1000 && n < 0b00_0000_0000_1000): RETURN(); break; //DONE
                    case int n when (n >= 0b00_0000_0110_0011 && n < 0b00_0000_0110_0011): SLEEP(); break; //DONE
                    case int n when (n >= 0b11_1100_0000_0000 && n < 0b11_1101_1111_1111): SUBLW(); break; //DONE
                    case int n when (n >= 0b11_1010_0000_0000 && n < 0b11_1010_1111_1111): XORLW(); break; //DONE


                }
            }
        }

        public int Cut(int data)
        {
            
            string datas = data.ToString();
            rx = new Regex(@"\d\d\b");
            Match match = rx.Match(datas);
            string var = match.Value;
            int result = int.Parse(var, System.Globalization.NumberStyles.HexNumber);
            System.Console.WriteLine(result);
            return result;
        }
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
