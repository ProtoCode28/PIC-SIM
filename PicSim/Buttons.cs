
namespace PicSim
{


	public class Buttons
	{
		Commands cmd = new Commands();
		public void GoButton()
		{
			StepButton();
			GoButton();
		}
		
		public void StepButton()
		{
			cmd.Switchcase(Globals.programcounter);
		}

	}
}

//sichtbarkeit der variabeln in c# -> programcounter
//klassen ineinander einbinden -> methoden anderer klassen aufrufen
