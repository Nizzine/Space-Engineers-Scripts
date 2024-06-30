// Nizzine Technologies - Attach IT! v.0.1
/*==============================================================

Script Does:
- Attach things together like they've meant to be.
- Attach rotorhead to wheel suspension.
- Attach rotorhead to hinge.
- Attach wheel to motor stator.
- Attach wheel to hinge.
- Attach hinge part to wheel suspension.
- Attach hinge part to motor stator.
- Attach X to Y.

This Script Does Not:
- Attach piston or it's head to things 
(because apparently that isn't a thing you can attach anywhere)

------------------------------------------------------------------

How to use:
- Place attachable block as close as possible to the block you're trying to attach it to.
- press Run. Things should attach.

-----------------------------------------------------------------

Troubleshoot:
Things did not attach:
- Try placing object closer.
- Try running with argument "At2" without quotation marks.
(CAUTION: This detaches and reattaches things)

My grid blew up!
- Very sad, yes. Anyway
- Clang redeemed his sacrifice; be more giving to lord Clang in the future.
- NizTech takes no responsibility of any damage to property, feelings or 
any holy or unholy creations of yours or any other subject within this universe.





Thank you for using NizTech!
Attach safely!







------------------------------------------------------------------------------------------
YOUR WARRANTY IS VOID BELOW THIS LINE! DO NOT FIDDLE!
------------------------------------------------------------------------------------------
*/

List<IMyMechanicalConnectionBlock> attachables = new List<IMyMechanicalConnectionBlock>();

public Program()
{
	GridTerminalSystem.GetBlocksOfType<IMyMechanicalConnectionBlock>(attachables, cx => cx.IsSameConstructAs(Me));
}

void Main(string args)
{
		foreach (IMyMechanicalConnectionBlock attch in attachables)
		{
			attch.Attach();
			if (args == "At2")
			attch.Detach();
			attch.Attach();
		}
}	
