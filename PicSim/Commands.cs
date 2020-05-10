
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
                case int n when (n >= 0b00_0000_0000_0000 && n < 0b00_0000_0110_0000): NOP(); break; //DONE
                case int n when (n >= 0b00_1101_0000_0000 && n < 0b00_1101_1111_1111): RLF(); break; //DONE
                case int n when (n >= 0b00_1100_0000_0000 && n < 0b00_1100_1111_1111): RRF(); break; //DONE
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
                case int n when (n >= 0b00_0000_0110_0100 && n < 0b00_0000_0110_0100): CLRWDT(); break; //DONE
                case int n when (n >= 0b10_1000_0000_0000 && n < 0b10_1111_1111_1111): GOTO(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b11_1000_0000_0000 && n < 0b11_1000_1111_1111): IORLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b11_0000_0000_0000 && n < 0b11_0011_1111_1111): MOVLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0000_0000_1001 && n < 0b00_0000_0000_1001): RETFIE(); break; //DONE
                case int n when (n >= 0b11_0100_0000_0000 && n < 0b11_0111_1111_1111): RETLW(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0000_0000_1000 && n < 0b00_0000_0000_1000): RETURN(); break; //DONE
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






        public void ADDWF(int cmd)
        {
            int address = ExtractAdress(cmd);

            if(ExtractDestination(cmd) == 0)
            {
                Globals.w += Globals.bank0[address];
                System.Console.WriteLine($"ADDWF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
                Globals.bank0[address] += Globals.w;
                System.Console.WriteLine($"ADDWF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error ADDWF");
            }

            Globals.z = 0;
            Globals.c = 0;
        }






        public void ANDWF(int cmd)
        {
            int address = ExtractAdress(cmd);

            if (ExtractDestination(cmd) == 0)
            {
                Globals.w &= Globals.bank0[address];
                System.Console.WriteLine($"ANDWF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
                Globals.bank0[address] &= Globals.w;
                System.Console.WriteLine($"ANDWF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error ANDWF");
            }
            Globals.z = 0;
            Globals.c = 0;
        }





        public void CLRF(int cmd)
        {
            int address = ExtractAdress(cmd);
            Globals.bank0[address] &= Globals.w;
            Globals.z = 1;

        }




        public void CLRW()
        {
            Globals.w = 0;
            Globals.z = 1;
        }




        public void COMF(int cmd) //Lehmann fragen was complement heisst / macht
        {
           
        }






        public void DECF(int cmd)
        {
            int address = ExtractAdress(cmd);

            if (ExtractDestination(cmd) == 0)
            {
                Globals.w = Globals.bank0[address] -1;
                System.Console.WriteLine($"DECF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
                Globals.bank0[address] --;
                System.Console.WriteLine($"DECF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error DECF");
            }
            if (Globals.z == 1)
            {
                Globals.z = 0;
            }
            else
            {
                Globals.z = 1;
            }
        }





        public void DECFSZ()
        {

        }






        public void INCF(int cmd)
        {
            {
                int address = ExtractAdress(cmd);

                if (ExtractDestination(cmd) == 0)
                {
                    Globals.w = Globals.bank0[address] + 1;
                    System.Console.WriteLine($"INCF-> address: {address} w: {Globals.w} Programcounter:");
                }
                else if (ExtractDestination(cmd) == 1)
                {
                    Globals.bank0[address]++;
                    System.Console.WriteLine($"INCF-> address: {address} bank: {Globals.bank0[address]}");
                }
                else
                {
                    System.Console.WriteLine($"Error INCF");
                }
                if (Globals.z == 1)
                {
                    Globals.z = 0;
                }
                else
                {
                    Globals.z = 1;
                }
            }
        }





        public void INCFSZ()
        {

        }






        public void IORWF(int cmd)
        {
            int address = ExtractAdress(cmd);

            if (ExtractDestination(cmd) == 0)
            {
                Globals.w |= Globals.bank0[address];
                System.Console.WriteLine($"IORWF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
                Globals.bank0[address] |= Globals.w;
                System.Console.WriteLine($"IORWF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error IORWF");
            }
            
                Globals.z = 0;
        }





        public void MOVF(int cmd)
        {
            int adress = ExtractAdress(cmd);
            if(ExtractDestination(cmd) == 0)
            {
                Globals.w = Globals.bank0[adress];
            }
            else
            {
                Globals.bank0[adress] = Globals.bank0[adress];
            }
            Globals.z = 1;
        }





        public void MOVWF(int cmd)
        {
            int address = ExtractAdress(cmd);
            Globals.bank0[address] = Globals.w;
            System.Console.WriteLine($"MOVWF adress: {address} bank: {Globals.bank0[address]} Programcounter: {Globals.programcounter}");
        }





        public void NOP()
        {
            System.Console.WriteLine($"Nop von Programcounter: {Globals.programcounter}");
        }





        public void RLF()
        {

        }




        public void RRF()
        {

        }




        public void SUBWF(int cmd)
        {
            int address = ExtractAdress(cmd);

            if (ExtractDestination(cmd) == 0)
            {
                Globals.w = Globals.bank0[address] - Globals.w;
                System.Console.WriteLine($"SUBWF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
                Globals.bank0[address] -= Globals.w;
                System.Console.WriteLine($"SUBWF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error SUBWF");
            }

            if (Globals.bank0[address] > 0)
            {
                Globals.z = 0;
                Globals.c = 1;
            }
            else if (Globals.bank0[address] == 0)
            {
                Globals.z = 1;
                Globals.c = 1;
            }
            else
            {
                Globals.z = 0;
                Globals.c = 0;
            }
        }




        public void SWAPF(int cmd) //wie tauscht man die halbbytes bzw. was macht swapf?
        {
            int address = ExtractAdress(cmd);

            if (ExtractDestination(cmd) == 0)
            {
               
                System.Console.WriteLine($"SWAPF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
               
                System.Console.WriteLine($"SWAPF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error SWAPF");
            }
        }



        public void XORWF(int cmd)
        {
            int address = ExtractAdress(cmd);

            if (ExtractDestination(cmd) == 0)
            {
                Globals.w ^= Globals.bank0[address];
                System.Console.WriteLine($"XORWF-> address: {address} w: {Globals.w} Programcounter:");
            }
            else if (ExtractDestination(cmd) == 1)
            {
                Globals.bank0[address] ^= Globals.w;
                System.Console.WriteLine($"XORWF-> address: {address} bank: {Globals.bank0[address]}");
            }
            else
            {
                System.Console.WriteLine($"Error XORWF");
            }

            Globals.z = 0;
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
            Globals.w += literal;
            Globals.z = 0;
            System.Console.WriteLine($"ADDLW W: {Globals.w} literal {literal} Programcounter: {Globals.programcounter}"); //$ + geschwungene klammern formatieren den String
        }



        public void ANDLW(int cmd)
        {
            int literal = ExtractLiteral(cmd);
            Globals.w &= literal;
            Globals.z = 0;
            System.Console.WriteLine($"ANDLW W: {Globals.w} literal {literal} Programcounter: {Globals.programcounter}"); //$ + geschwungene klammern formatieren den String
        }



        public void CALL(int cmd)
        {
            int address = ExtractCall(cmd);
            Globals.stack.Push(Globals.programcounter);
            Globals.programcounter = address;
            System.Console.WriteLine($"Programcounter: {Globals.programcounter} adress {address} "); //$ + geschwungene klammern formatieren den String

        }



        public void CLRWDT()
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
            System.Console.WriteLine($"Programcounter: {Globals.programcounter} "); //$ + geschwungene klammern formatieren den String

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
            else
            {
                Globals.z = 1;
            }
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

