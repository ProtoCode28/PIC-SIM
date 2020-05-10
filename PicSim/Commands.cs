using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PicSim
{
    class Commands
    {
        public Commands()
        {
            Globals.stack = new Stack<int>();
        }
        public void Switchcase(int pc) //pc ist programcounter
        {
            Globals.programcounter++;
                switch  (Globals.programmemory[pc])
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
                    case int n when (n >= 0b00_0000_1000_0000 && n < 0b00_0000_1111_1111): MOVWF(Globals.programmemory[pc]); break; //DONE
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
                    case int n when (n >= 0b11_1110_0000_0000 && n < 0b11_1111_1111_1111): ADDLW(Globals.programmemory[pc]); break; //DONE
                    case int n when (n >= 0b11_1001_0000_0000 && n < 0b11_1001_1111_1111): ANDLW(Globals.programmemory[pc]); break; //DONE
                    case int n when (n >= 0b10_0000_0000_0000 && n < 0b10_0111_1111_1111): CALL(Globals.programmemory[pc]); break; //DONE
                    case int n when (n >= 0b00_0000_0110_0100 && n < 0b00_0000_0110_0100): CLRWDT(); break; //DONE
                    case int n when (n >= 0b10_1000_0000_0000 && n < 0b10_1111_1111_1111): GOTO(); break; //DONE
                    case int n when (n >= 0b11_1000_0000_0000 && n < 0b11_1000_1111_1111): IORLW(Globals.programmemory[pc]); break; //DONE
                    case int n when (n >= 0b11_0000_0000_0000 && n < 0b11_0011_1111_1111): MOVLW(Globals.programmemory[pc]); break; //DONE
                    case int n when (n >= 0b00_0000_0000_1001 && n < 0b00_0000_0000_1001): RETFIE(); break; //DONE
                    case int n when (n >= 0b11_0100_0000_0000 && n < 0b11_0111_1111_1111): RETLW(); break; //DONE
                    case int n when (n >= 0b00_0000_0000_1000 && n < 0b00_0000_0000_1000): RETURN(Globals.stack); break; //DONE
                    case int n when (n >= 0b00_0000_0110_0011 && n < 0b00_0000_0110_0011): SLEEP(); break; //DONE
                    case int n when (n >= 0b11_1100_0000_0000 && n < 0b11_1101_1111_1111): SUBLW(Globals.programmemory[pc]); break; //DONE
                    case int n when (n >= 0b11_1010_0000_0000 && n < 0b11_1010_1111_1111): XORLW(Globals.programmemory[pc]); break; //DONE


                }
        }

        public int ExtractDestination(int cmd) //Destinationbit
        {
            return cmd & 0x80; //Erste Stelle der 8 Bit wird extrahiert  
        }


        public int ExtractAdress(int cmd)
        {
            return cmd & 0x7F; //
        }
        
        public int ExtractLiteral(int cmd)
        {
            return cmd & 0b1111_1111;
        }
        public int ExtractCall(int cmd)
        {
            return cmd & 0x7FF;
        }

        //Befehle des PIC
        //_____________________________________________________________________________________________________

        public void ADDWF()
        {
            System.Console.WriteLine("ADDWF");
        }

        public void ANDWF()
        {
            System.Console.WriteLine("ANDWF");
        }

        public void CLRF()
        {
            System.Console.WriteLine("CLRF");
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
        public void MOVWF(int cmd)
        {
            int adress = ExtractAdress(cmd);
            Globals.bank0[adress] = Globals.w;
            System.Console.WriteLine($"MOVWF adress: {adress} bank: {Globals.bank0[adress]}");
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
        public void ADDLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w = literal;
            Globals.z = 0;
            System.Console.WriteLine($"ADDLW W: {Globals.w} literal {literal}"); //$ + geschwungene klammern formatieren den String
        }
        public void ANDLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w &= literal;
            Globals.z = 0;
            System.Console.WriteLine($"ANDLW W: {Globals.w} literal {literal}"); //$ + geschwungene klammern formatieren den String
        }
        public void CALL(int cmd)
        {
            int address = ExtractCall(cmd);
            Globals.stack.Push(Globals.programcounter + 1);//int stack muss durch echten stack ersetzt werden
            Globals.programcounter = address;
            System.Console.WriteLine($"Programcounter: {Globals.programcounter} adress {address}"); //$ + geschwungene klammern formatieren den String
        }
        public void CLRWDT()
        {

        }
        public void GOTO()
        {

        }
        public void IORLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w |= literal;
            Globals.z = 0;
            System.Console.WriteLine($"IORLW W: {Globals.w} literal {literal}"); //$ + geschwungene klammern formatieren den String
        }
        public void MOVLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w = literal;
            System.Console.WriteLine($"MOVLW w: {Globals.w} literal: {literal}");
        }
        public void RETFIE()
        {

        }
        public void RETLW()
        {

        }
        public void RETURN()
        {
            Globals.programcounter = Globals.stack.Pop();
            System.Console.WriteLine($"Programcounter: {Globals.programcounter}"); //$ + geschwungene klammern formatieren den String

        }
        public void SLEEP()
        {

        }
        public void SUBLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w -= literal;
            if (Globals.w < 0)
            {
                Globals.z = 0;
            }
            else Globals.z = 1;
            System.Console.WriteLine($"SUBLW w: {Globals.w} literal: {literal}");
        }
        public void XORLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w ^= literal;
            Globals.z = 0;
            System.Console.WriteLine($"XORLW W: {Globals.w} literal {literal}"); //$ + geschwungene klammern formatieren den String
        }

    }
}
