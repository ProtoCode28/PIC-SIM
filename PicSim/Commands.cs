
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
            switch (Globals.programmemory[pc])
            {
                case int n when (n >= 0b00_0111_0000_0000 && n < 0b00_0111_1111_1111): ADDWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0101_0000_0000 && n < 0b00_0101_1111_1111): ANDWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0001_1000_0000 && n < 0b00_0001_1111_1111): CLRF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0001_0000_0000 && n < 0b00_0001_0111_1111): CLRW(); break; //DONE
                case int n when (n >= 0b00_1001_0000_0000 && n < 0b00_1001_1111_1111): COMF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0011_0000_0000 && n < 0b00_0011_1111_1111): DECF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1011_0000_0000 && n < 0b00_1011_1111_1111): DECFSZ(); break; //DONE
                case int n when (n >= 0b00_1010_0000_0000 && n < 0b00_1010_1111_1111): INCF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1111_0000_0000 && n < 0b00_1111_1111_1111): INCFSZ(); break; //DONE
                case int n when (n >= 0b00_0100_0000_0000 && n < 0b00_0100_1111_1111): IORWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1000_0000_0000 && n < 0b00_1000_1111_1111): MOVF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0000_1000_0000 && n < 0b00_0000_1111_1111): MOVWF(Globals.programmemory[pc]); break; //DONE
                case int n when ((n == 0b00_0000_0000_0000) || (n == 0b00_0000_0010_0000) || (n == 0b00_0000_0100_0000) || (n == 0b00_0000_0110_0000)): NOP(); break; //DONE 0 oder 32 oder 64 oder 96
                case int n when (n >= 0b00_1101_0000_0000 && n < 0b00_1101_1111_1111): RLF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1100_0000_0000 && n < 0b00_1100_1111_1111): RRF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0010_0000_0000 && n < 0b00_0010_1111_1111): SUBWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1110_0000_0000 && n < 0b00_1110_1111_1111): SWAPF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0110_0000_0000 && n < 0b00_0110_1111_1111): XORWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b01_0000_0000_0000 && n < 0b01_0011_1111_1111): BCF(); break; //DONE
                case int n when (n >= 0b01_0100_0000_0000 && n < 0b01_0111_1111_1111): BSF(); break; //DONE
                case int n when (n >= 0b01_1000_0000_0000 && n < 0b01_1011_1111_1111): BTFSC(); break; //DONE
                case int n when (n >= 0b01_1100_0000_0000 && n < 0b01_1111_1111_1111): BTFSS(); break; //DONE
                case int n when (n >= 0b11_1110_0000_0000 && n < 0b11_1111_1111_1111): ADDLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b11_1001_0000_0000 && n < 0b11_1001_1111_1111): ANDLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b10_0000_0000_0000 && n < 0b10_0111_1111_1111): CALL(Globals.programmemory[pc]); break; //DONE
                case int n when (n == 0b00_0000_0110_0100): CLRWDT(); break; //DONE
                case int n when (n >= 0b10_1000_0000_0000 && n < 0b10_1111_1111_1111): GOTO(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b11_1000_0000_0000 && n < 0b11_1000_1111_1111): IORLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b11_0000_0000_0000 && n < 0b11_0011_1111_1111): MOVLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n == 0b00_0000_0000_1001): RETFIE(); break; //DONE
                case int n when (n >= 0b11_0100_0000_0000 && n < 0b11_0111_1111_1111): RETLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n == 0b00_0000_0000_1000): RETURN(); break; //DONE
                case int n when (n == 0b00_0000_0110_0011): SLEEP(); break; //DONE
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
            return cmd & 0x7F; //hinteren 7 bits für die adresse
        }

        public int ExtractLiteral(int cmd)
        {
            return cmd & 0b1111_1111;
        }

        public int ExtractCall(int cmd)
        {
            return cmd & 0x7FF;
        }

        public int ExtractCFlag()
        {
            return Globals.bank0[3] & 0b0000_0001;
        }

        public int ExtractDCFlag()
        {
            return Globals.bank0[3] & 0b0000_0010;
        }

        public int ExtractZFlag()
        {
            return Globals.bank0[3] & 0b0000_0100;
        }

        public int ExtractRP0()
        {
            return Globals.bank0[3] & 0b0010_0000;
        }

        public int ExtractRP1()
        {
            return Globals.bank0[3] & 0b0100_0000;
        }

        public int ExtractIRP()
        {
            return Globals.bank0[3] & 0b1000_0000;
        }

        public int GetData(int cmd)
        {
            int address = ExtractAdress(cmd);
            int result;
            if(ExtractRP0() == 32)
            {
                result = Globals.bank1[address];
            }
            else
            {
                result = Globals.bank0[address];
            }
            return result;
        }

        public void SetData(int cmd, int result)
        {
            int address = ExtractAdress(cmd);
            
            if (ExtractRP0() == 32)
            {
               Globals.bank1[address] = result;
            }
            else
            {
                Globals.bank0[address] = result;
            }
        }

        public void ChangeZ(int result)
        {
            if(result == 0)
            {
                Globals.bank0[3] |= 0b0000_0100; 
                Globals.bank1[3] |= 0b0000_0100;
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1011;
                Globals.bank1[3] &= 0b1111_1011;
            }
        }

        public void ChangeC(int result)
        {
            if(result > 255 )
            {
                Globals.bank0[3] |= 0b0000_0001;
                Globals.bank1[3] |= 1;              // geht weil zahl <9
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1110;
                Globals.bank1[3] &= 0b1111_1110;
            }
        }

        public void WoF(int cmd, int result)
        {
            if(ExtractDestination(cmd) == 0)
            {
                Globals.w = result;
            }
            else
            {
                SetData(cmd, result);
            }
        }

        public void ChangeDCADD(int w, int data)
        {
            w &= 15;
            data &= 15;
            int a = w + data;
            if(a > 15)
            {
                Globals.bank0[3] |= 0b0000_0010;
                Globals.bank1[3] |= 2;
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1101;
                Globals.bank1[3] &= 0b1111_1101;
            }
        }

        public void ChangeDCSUB(int w, int data)
        {
            w &= 15;
            data &= 15;
            int a = w - data;
            if (a >= 0)
            {
                Globals.bank0[3] |= 0b0000_0010;
                Globals.bank1[3] |= 2;
            }
            else
            {
                Globals.bank0[3] &= 0b1111_1101;
                Globals.bank1[3] &= 0b1111_1101;
            }
        }

        //Befehle des PIC
        //Verwendung der Behilfsmethoden aus dem oberen Block
        //_____________________________________________________________________________________________________

        public void ADDWF(int cmd)
        {
            int result = Globals.w + GetData(cmd);
            ChangeDCADD(Globals.w, GetData(cmd));
            ChangeZ(result);
            ChangeC(result);
            WoF(cmd, result & 255); //&255 da nur die 8 bit gültig sind und der übertrag im ChangeC steht
            System.Console.WriteLine($"ADDWF-> address: {GetData(cmd)} result: {result} w: {Globals.w}");
        }

        public void ANDWF(int cmd)
        {
            int result = Globals.w & GetData(cmd);
            WoF(cmd, result & 255);
            ChangeZ(result);
            ChangeC(result);
            System.Console.WriteLine($"ANDWF-> Data: {GetData(cmd)} w: {Globals.w} result {result}");
        }

        public void CLRF(int cmd)
        {
            int result = 0;
            SetData(cmd, result);
            ChangeZ(result);
        }

        public void CLRW()
        {
            int result = 0;
            Globals.w = result;
            ChangeZ(result);
        }

        public void COMF(int cmd) 
        {
            int result = GetData(cmd) ^ 255;
            WoF(cmd, result);
            System.Console.WriteLine($"COMF-> result: {result}");
            ChangeZ(result);
        }

        public void DECF(int cmd)
        {
            int result = GetData(cmd) - 1;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"DECF-> result: {result}");
        }

        public void DECFSZ()
        {

        }

        public void INCF(int cmd)
        {
            int result = GetData(cmd) + 1;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"INCF-> result: {result}");
        }

        public void INCFSZ()
        {

        }

        public void IORWF(int cmd)
        {
            int result = Globals.w | GetData(cmd);
            WoF(cmd, result);
            System.Console.WriteLine($"IORWF-> w: {Globals.w}");
            ChangeZ(result);
        }   //Z-Flag invertiert?

        public void MOVF(int cmd)
        {
            int result = GetData(cmd);
            WoF(cmd, result);
            ChangeZ(result);
        }

        public void MOVWF(int cmd)
        {
            int result = GetData(cmd);
            WoF(cmd, result);
            System.Console.WriteLine($"MOVWF result: {result} Programcounter: {Globals.programcounter}");
        }

        public void NOP()
        {
            System.Console.WriteLine($"Nop von Programcounter: {Globals.programcounter}");
        }

        public void RLF(int cmd)
        {
            int result = GetData(cmd);
            result <<= 1;
            WoF(cmd, result);
            ChangeC(result);
        }

        public void RRF(int cmd)
        {
            int result = GetData(cmd);
            result >>= 1;
            WoF(cmd, result);
            ChangeC(result);
            System.Console.WriteLine($"RRF-> result: {result} w: {Globals.w}");
        }

        public void SUBWF(int cmd)
        {
            int result = GetData(cmd) - Globals.w;
            WoF(cmd, result);
            ChangeC(result);
            ChangeDCSUB(Globals.w, GetData(cmd));
            ChangeZ(result);
            System.Console.WriteLine($"SUBWF-> result: {result} w: {Globals.w}");
        }

        public void SWAPF(int cmd)
        {
            int a = GetData(cmd) & 0b0000_1111;
            int b = GetData(cmd) & 0b1111_0000;
            a <<= 4;  //shift nach links
            b >>= 4;  //shift nach rechts
            int res = a | b;
            WoF(cmd, res);
            System.Console.WriteLine($"SWAPF-> result: {res} w: {Globals.w}");
        }

        public void XORWF(int cmd)
        {
            int result = Globals.w ^ GetData(cmd);
            WoF(cmd, result);
            ChangeZ(result);
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

        public void ADDLW(int cmd) //wieso wird DC beeinflusst?
        {            
            int literal = ExtractLiteral(cmd);
            int result = Globals.w + literal;
            WoF(cmd, result);
            ChangeC(result);
            ChangeDCADD(Globals.w, literal);
            ChangeZ(result);
            System.Console.WriteLine($"ADDLW W: {Globals.w} literal {literal} Programcounter: {Globals.programcounter}"); //$ + geschwungene klammern formatieren den String
        }

        public void ANDLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            int result = Globals.w & literal;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"ANDLW W: {Globals.w} literal {literal} Programcounter: {Globals.programcounter}"); //$ + geschwungene klammern formatieren den String
        }

        public void CALL(int cmd)
        {
            int address = ExtractCall(cmd);
            Globals.stack.Push(Globals.programcounter);
            Globals.programcounter = address;
            System.Console.WriteLine($"Programcounter: {Globals.programcounter} adress {address} "); 
        }

        public void CLRWDT()    //watchdogtimer
        {

        }

        public void GOTO(int cmd)
        {
            int address = ExtractCall(cmd);
            Globals.programcounter = address;
            System.Console.WriteLine($"GOTO-> Programcounter: {Globals.programcounter} adress {address} ");
        }

        public void IORLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            int result = Globals.w | literal;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"IORLW W: {Globals.w} literal {literal}"); //$ + geschwungene klammern formatieren den String
        }

        public void MOVLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w = literal;
            System.Console.WriteLine($"MOVLW w: {Globals.w} literal: {literal}");
        }

        public void RETFIE()    //Interrupt
        {

        }

        public void RETLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w = literal;
            Globals.programcounter = Globals.stack.Pop();
            System.Console.WriteLine($"RETLW w: {Globals.w} literal: {literal}");
        }

        public void RETURN()
        {
            Globals.programcounter = Globals.stack.Pop();
            System.Console.WriteLine($"Programcounter: {Globals.programcounter} ");
        }

        public void SLEEP()
        {

        }

        public void SUBLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            int result = Globals.w - literal;
            Globals.w = result;
            WoF(cmd, result);
            ChangeZ(result);
            ChangeC(result);
            ChangeDCSUB(Globals.w, literal);            
            System.Console.WriteLine($"SUBLW w: {Globals.w} literal: {literal}");
        }

        public void XORLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            int result = Globals.w ^ literal;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"XORLW W: {Globals.w} literal {literal}"); 
        }
    }
}

