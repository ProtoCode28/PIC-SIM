using System;
namespace PicSim
{


    public class Buttons
    {
		Commands cmd = new Commands();
		/*public void GoButton()
		{
			
			for (int i = 0; i <= TransferPCLength();i++)
			{
				//cmd.Switchcase(i);
			}
		}
		*/
        public void StepButton()
        {
			cmd.Switchcase(Globals.programcounter);
        }
		
    }
}

//sichtbarkeit der variabeln in c# -> programcounter
//klassen ineinander einbinden -> methoden anderer klassen aufrufen
