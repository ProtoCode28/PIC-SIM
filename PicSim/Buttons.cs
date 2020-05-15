
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


