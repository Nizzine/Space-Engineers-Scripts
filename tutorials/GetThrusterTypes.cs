// {Nz}®️ Nizzine Technolgies - Tutorial: Get Thruster Types v0.1
/*================================================================


Gets Ion, Hydro and Atmos thrusters, counts and groups them.
Not guaranteed to work with mods.

*/


List<IMyThrust> thrusters = new List<IMyThrust>(); // List of all thrusters.
List<IMyThrust> Hydros = new List<IMyThrust>(); // List of hydrogen thrusters.
List<IMyThrust> Atmos = new List<IMyThrust>(); // List of atmospheric thrusters.
List<IMyThrust> Ions = new List<IMyThrust>(); // List of ion thrusters.

public Program() 
{
	GridTerminalSystem.GetBlocksOfType(thrusters, t01 => t01.IsSameConstructAs(Me)); // "IsSameConstructAs(Me)" means that it's part of the same ship, or connected with rotors, pistons or other mechanical things, but not connector. Aka. grid + subgrids.
	Echo(""); // clear the custom data box of programmable block.

	Runtime.UpdateFrequency = UpdateFrequency.Once; // we run the "void Main()" once. To run again, press "Recompile" in the terminal window.

	// Lets empty the lists first:
	Hydros.Clear(); 
	Atmos.Clear();
	Ions.Clear();
	
	foreach(IMyThrust thruster in thrusters) // Go through each thruster in thrusters list one by one
	{
		string thusterSubTypeName = thruster.DefinitionDisplayNameText; // we get the displayed name of the thruster.

		if (thusterSubTypeName.ToLower().Contains("hydro")) // if the name, converted into lowercase letters, contains the word "hydro", 
		{
			Hydros.Add(thruster); // add this thruster to Hydros list.
		}

		else if (thusterSubTypeName.ToLower().Contains("atmo"))
		{
			Atmos.Add(thruster);
		}

		else if (thusterSubTypeName.ToLower().Contains("ion")) 
		{
			Ions.Add(thruster);
		}
	}
}



void Main()
{
	string hydroThrusters = Hydros.Count().ToString(); // Get the amount of thrusters in Hydros list. This is an integer number which we convert into string aka. text.
	string atmoThrusters = Atmos.Count().ToString(); 
	string ionThrusters = Ions.Count().ToString(); 
	Echo("Hydros: " + hydroThrusters + "\n" + "Atmos: " + atmoThrusters + "\n" + "Ions: " + ionThrusters); // we display them in the programmable block custom info box. "\n" means new line.


	// To actually use the grouped trusters:

	foreach(IMyThrust hydro in Hydros) // we give a name to each thruster in Hydros list. the name here is "hydro". It can be anything. "foreach" goes through them one by one.
	{
		hydro.ThrustOverridePercentage = 0f; // this is float value. it's range is 0 to 1, 1 being max thrust. you can use this or the next one below this to control thrust force.
		// thruster.ThrustOverride = 1; 	// this is 1 Newton of force. This is useful if you don't want the thruster to try to stop the ship when interia dampeners are on and you don't want to turn the thruster off either.
		hydro.Enabled = true; // turn the thruster on! set "false" to turn it off.

	}

}
