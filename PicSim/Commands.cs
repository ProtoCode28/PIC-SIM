
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PicSim
{
    class Commands
    {
        private static int lastPortA = -1;
        public Commands()
        {
            Globals.stack = new Stack<int>();
        }
        public void Switchcase(int pc) //pc ist programcounter
        {
            Globals.programcounter++;
            if ((Globals.bank1[1] & 0b0010_0000) == 0)
            {
                CalcTMR0();
            }
            else // hier muss geprüft werden, ob die richtige flanke an RA4 anliegt (vergleich alterzustand/neuerzustand)
            {
                int bit4 = lastPortA & 0b0001_0000;
                if (lastPortA != -1 && (bit4 != (Globals.bank0[5] & 0b0001_0000)) && bit4 == 1)
                {
                    CalcTMR0();
                }
                lastPortA = Globals.bank0[5];
            }
            switch (Globals.programmemory[pc])
            {
                case int n when (n >= 0b00_0111_0000_0000 && n < 0b00_0111_1111_1111): ADDWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0101_0000_0000 && n < 0b00_0101_1111_1111): ANDWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0001_1000_0000 && n < 0b00_0001_1111_1111): CLRF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0001_0000_0000 && n < 0b00_0001_0111_1111): CLRW(); break; //DONE
                case int n when (n >= 0b00_1001_0000_0000 && n < 0b00_1001_1111_1111): COMF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0011_0000_0000 && n < 0b00_0011_1111_1111): DECF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1011_0000_0000 && n < 0b00_1011_1111_1111): DECFSZ(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1010_0000_0000 && n < 0b00_1010_1111_1111): INCF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1111_0000_0000 && n < 0b00_1111_1111_1111): INCFSZ(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0100_0000_0000 && n < 0b00_0100_1111_1111): IORWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1000_0000_0000 && n < 0b00_1000_1111_1111): MOVF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0000_1000_0000 && n < 0b00_0000_1111_1111): MOVWF(Globals.programmemory[pc]); break; //DONE
                case int n when ((n == 0b00_0000_0000_0000) || (n == 0b00_0000_0010_0000) || (n == 0b00_0000_0100_0000) || (n == 0b00_0000_0110_0000)): NOP(); break; //DONE 0 oder 32 oder 64 oder 96
                case int n when (n >= 0b00_1101_0000_0000 && n < 0b00_1101_1111_1111): RLF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1100_0000_0000 && n < 0b00_1100_1111_1111): RRF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0010_0000_0000 && n < 0b00_0010_1111_1111): SUBWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_1110_0000_0000 && n < 0b00_1110_1111_1111): SWAPF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b00_0110_0000_0000 && n < 0b00_0110_1111_1111): XORWF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b01_0000_0000_0000 && n < 0b01_0011_1111_1111): BCF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b01_0100_0000_0000 && n < 0b01_0111_1111_1111): BSF(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b01_1000_0000_0000 && n < 0b01_1011_1111_1111): BTFSC(Globals.programmemory[pc]); break; //DONE
                case int n when (n >= 0b01_1100_0000_0000 && n < 0b01_1111_1111_1111): BTFSS(Globals.programmemory[pc]); break; //DONE
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

        public int ExtractT0IF()
        {
            return Globals.bank0[11] & 0b0000_0100;
        }

        public int ExtractPrescaler()
        {
            return Globals.bank1[1] & 0b0000_0111;
        }

        public void CalcPrescaler()
        {
            int ps = ExtractPrescaler();
            if ((Globals.bank1[1] & 0b0000_1000) == 0)
            {
                int scaler = 2 ^ (ps + 1);
                Globals.prescaler = scaler;
            }
            else
            {
                Globals.prescaler = 2 ^ ps;
            }
        }
        
        public void CalcTMR0()
        {
            //immer wenn optionregister beschrieben wird calcprescalertimer ---> abfrage ob optionregister das ziel ist -> falls ja
            if ((Globals.bank1[1] & 0b0000_1000) == 0)
            {
                Globals.prescaler--;
                if (Globals.prescaler == 0)
                {
                    Globals.bank0[1]++;
                    CalcPrescaler();
                    if (Globals.bank0[1] > 255)
                    {
                        Globals.bank0[11] |= 0b0000_0100;
                        Globals.bank1[11] |= 0b0000_0100;
                        Globals.bank0[1] = 0;
                    }
                }
            }
            else
            {
                Globals.bank0[1]++; 
                if(Globals.bank0[1] > 255)
                {
                    Globals.bank0[11] |= 0b0000_0100;
                    Globals.bank1[11] |= 0b0000_0100;
                    Globals.bank0[1] = 0;
                }
            }
        }

        public void CalcWdt()
        {
            //laufzeitberechnung in label ausgeben und berechnen in calcwdt  
            //für jeden befehl müssen wir die zyklen berechnen und in befehlsdauer eintragen checkboxfürWDT = 1 und quartzfrequenz einstellen
            if (Globals.bank0[1] == 1)//da steht aktuell stuss drin // wenn optionregister beschrieben wird (movwf 1) dann calcprescaler
            {
                Globals.WDT += Globals.Befehlsdauer;
                if (Globals.WDT == 18000)
                {
                    if ((Globals.bank1[1] & 0b0000_1000) != 0)      //bei maskierung auf richtigen wert prüfen = bzw != 0
                    {
                        Globals.prescaler--;
                        Globals.WDT = 0;
                        if(Globals.prescaler == 0)
                        {
                            Register.Reset();
                        }
                    }
                    else
                    {
                        Register.Reset();
                    }
                }
            }
        }


        public int ExtractBitB(int cmd)
        {
            return (cmd & 0b11_1000_0000) >> 7 ;
        }
        
        public int SetBitB(int cmd, int offset)
        {
            int result = cmd;
            result |= (1 << offset);
            return result;
        }
        public int ClearBitB(int cmd, int offset)
        {
            int result = cmd;
            result &= ~(1 << offset);
            return result;
        }
        public int GetBitB(int cmd, int offset)
        {
            int result = (cmd >> offset) & 0b0000_0001;
            return result;
        }

        public int GetData(int cmd)
        {
            int address = ExtractAdress(cmd);
            int result;
            if (address == 0)
            {
                address = GetData(4);
                if ((address & 0x80) == 0)
                {
                    result = Globals.bank0[address & 0x7f];
                }
                else
                {
                    result = Globals.bank1[address & 0x7f];
                }
            }
            else
            {
                if (ExtractRP0() == 32)
                {
                    result = Globals.bank1[address];
                }
                else
                {
                    result = Globals.bank0[address];
                }
            }
            return result;
        }

        public void SetData(int cmd, int result)
        {
            int address = ExtractAdress(cmd);

            if (address == 0)
            {
                address = GetData(4);
                if ((address & 0x80) == 0)
                {
                    Globals.bank0[address & 0x7f] = result;
                    System.Console.WriteLine($"SetData result: {Globals.bank0[address & 0x7f]}");
                }
                else
                {
                    Globals.bank1[address & 0x7f] = result;
                    System.Console.WriteLine($"SetData result: {Globals.bank1[address & 0x7f]}");
                }
            }
            else
            {
                if (ExtractRP0() == 32)
                {
                    Globals.bank1[address] = result;
                    System.Console.WriteLine($"SetData result: {Globals.bank1[address]}");
                }
                else
                {
                    Globals.bank0[address] = result;
                    System.Console.WriteLine($"SetData result: {Globals.bank0[address]}");
                }
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
            if(result > 255)
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
            System.Console.WriteLine($"ADDWF-> result: {result} w: {Globals.w}");
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
            System.Console.WriteLine($"CLRF: Success");
        }

        public void CLRW()
        {
            int result = 0;
            Globals.w = result;
            ChangeZ(result);
            System.Console.WriteLine($"CLRW-> w: {Globals.w}");
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
            int data = GetData(cmd);
            int result = data - 1;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"DECF-> result: {result} w: {Globals.w}");
        }

        public void DECFSZ(int cmd)
        {
            int result = GetData(cmd) - 1;
            WoF(cmd, result);
            if (result == 0)
            {
                NOP();
                Globals.programcounter++; // muss manuell gemacht werden, alternative wäre switch methode aufzurufen und den hex wert von NOP zu übergeben
                CalcTMR0();
                CalcWdt();
                System.Console.WriteLine($"NOP von DECFSZ");
            }
            else
            {
                System.Console.WriteLine($"DECFSZ-> result: {result}");
            }
        }

        public void INCF(int cmd)
        {
            int result = GetData(cmd) + 1;
            WoF(cmd, result);
            ChangeZ(result);
            System.Console.WriteLine($"INCF-> result: {result}");
        }

        public void INCFSZ(int cmd)
        {
            int result = GetData(cmd) + 1;
            WoF(cmd, result);
            if ((result&0b1111_1111) == 0) //muss maskiert werden weil 256 = 100h und somit != 0 --> incfsz würde sonst nie enden
            {
                NOP();
                Globals.programcounter++; // muss manuell gemacht werden, alternative wäre switch methode aufzurufen und den hex wert von NOP zu übergeben
                CalcTMR0();
                CalcWdt();
                System.Console.WriteLine($"NOP von INCFSZ");
            }
            else
            {
                System.Console.WriteLine($"INCFSZ-> result: {result}");
            }
        }

        public void IORWF(int cmd)
        {
            int result = Globals.w | GetData(cmd);
            WoF(cmd, result);
            System.Console.WriteLine($"IORWF-> w: {Globals.w}");
            ChangeZ(result);
        }   //Z-Flag invertiert? siehe neues datasheet

        public void MOVF(int cmd)
        {
            int result = GetData(cmd);
            WoF(cmd, result);
            ChangeZ(result);
        }

        public void MOVWF(int cmd)
        {
            int result = Globals.w;
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
            result += ExtractCFlag();
            ChangeC(result);
            result &= 0b1111_1111;
            WoF(cmd, result);
            System.Console.WriteLine($"RLF-> result: {result} w: {Globals.w}");
        }

        public void RRF(int cmd)
        {
            int result = GetData(cmd);
            result += ExtractCFlag() << 9; // damit changeC funktioniert muss unser Carrybit an die 9 Stelle, also an die overflow stelle
            result += ((result & 0b1) << 10);
            result >>= 1;
            ChangeC(result);
            result &= 0b1111_1111;
            WoF(cmd, result);
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
            System.Console.WriteLine($"XORWF-> w: {result}");
        }

        public void BCF(int cmd) 
        {
            int result = GetData(cmd);
            int a = ExtractBitB(cmd);   // zb 7 also bit an 7. stelle muss auf 0 gesetzt werden
            int b = ClearBitB(result, a);
            SetData(cmd, b);
            System.Console.WriteLine($"BCF: Success, index: {a}");
        }

        public void BSF(int cmd) 
        {
            int result = GetData(cmd);
            int a = ExtractBitB(cmd);   // zb 7 also bit an 7. stelle muss auf 1 gesetzt werden 
            int b = SetBitB(result, a);
            SetData(cmd, b);
            System.Console.WriteLine($"BSF: Success, index: {a}");
        }

        public void BTFSC(int cmd)
        {
            int result = GetData(cmd);
            int a = ExtractBitB(cmd);
            int b = GetBitB(result, a);

            if (b == 0) // wenn b = 0, dann ist address an der stelle a 0 
            {
                NOP();
                Globals.programcounter++; // muss manuell gemacht werden, alternative wäre switch methode aufzurufen und den hex wert von NOP zu übergeben
                CalcTMR0();
                CalcWdt();
                System.Console.WriteLine($"NOP von BTFSC");
            }
            else
            {
                System.Console.WriteLine($"BTFSC-> result: {result}");
            }

        }

        public void BTFSS(int cmd)
        {
            int result = GetData(cmd);
            int a = ExtractBitB(cmd);
            int b = GetBitB(result, a);

            if (b == 1) // wenn b = 1, dann ist address an der stelle a 0 
            {
                NOP();
                Globals.programcounter++; // muss manuell gemacht werden, alternative wäre switch methode aufzurufen und den hex wert von NOP zu übergeben
                CalcTMR0();
                CalcWdt();
                System.Console.WriteLine($"NOP von BTFSS");
            }
            else
            {
                System.Console.WriteLine($"BTFSS-> result: {result}");
            }

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

        public void CLRWDT()    //watchdogtimer //TMR0 = Globals.Bank0[1] = 8 bit und T0IF-Bit = Überlauf = Globals.bank0/1[11] = 0000_0100 
        {                       //Prescaler für WDT eigene Variable?

            Globals.WDT = 0x00; //18ms
            Globals.prescaler = 1; //kleinster wert ist eins, sonst teilt man durch 0 und das wird unendlich
            Globals.bank0[3] |= 0b0001_0000; //Set TO to 1
            Globals.bank1[3] |= 0b0001_0000; //Set TO to 1
            Globals.bank0[3] |= 0b0000_1000; //Set PD to 1
            Globals.bank1[3] |= 0b0000_1000; //Set PD to 1
            System.Console.WriteLine($"CLRWDT-> WTD: {Globals.WDT} PS: {Globals.prescaler}");
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

        public void RETFIE()    
        {
            Globals.programcounter = Globals.stack.Pop();
            Globals.bank1[11] |= 0b1000_0000;
            Globals.bank0[11] |= 0b1000_0000;
            System.Console.WriteLine($"RETFIE: Succes");
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

        public void SLEEP() // noch nicht fertig programmiert!
        {
            
            Globals.bank0[3] |= 0b0001_0000; //Set TO to 1
            Globals.bank1[3] |= 0b0001_0000; //Set TO to 1
            Globals.bank0[3] &= 0b1111_0111; //Set PD to 0
            Globals.bank1[3] &= 0b1111_0111; //Set PD to 0
            Globals.WDT = 0x00; //18ms
            Globals.prescaler = 1; //kleinster wert ist eins, sonst teilt man durch 0 und das wird unendlich
            System.Console.WriteLine($"Sleep");
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

