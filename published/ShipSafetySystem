/* 
Nizzine Technologies - Ship Safety System v.0.2
===============================================

This script is designed to handle a small ship's systems to stop 
the ship in case pilot has lost control of the ship. 
Protects from "oopsie!", "oh no!" or disconnection from server. 

You can also trigger it manually by running an argument "manual".
You can also only trigger dampeners with argument "dampeners".
If you want to turn the script on/off just turn on/off the programmable block.

The script does:

- Trigger "SafetySwitch" timer. (Name must be exact and without quotes)
- Interia dampeners on.
- Gyros on, gyro overrides off.
- Thrusters on, thrust overrides off.
- Attempts to lock Landing Gear / Magnetic Plates.

The script turns the safety off automatically when 
the ship is connected to a connector and 
re-enables the safety on disconnection from connector.

The script does NOT:
- Know if you're docked to another ship / missle / whatever mobile grid or the size of the grid.
- Understand the difference between thruster types.
- Work with subgrids / VTOL systems.

Thank you for using NizTech!
Fly safely!









v0.2 updates
- Applies now to only to it's own grid.
- Object references are set to an instance of an object (null detection).
- Performance improvements.
- Can now trigger dampeners with argument "dampeners".
- Works together with "Nizzine Technologies - Fighter Systems Manager" script.

------------------------------------------------------------------------------------------
YOUR WARRANTY IS VOID BELOW THIS LINE! DO NOT FIDDLE!
------------------------------------------------------------------------------------------
*/



List<IMyShipController> shipControllers = new List<IMyShipController>();
List<IMyLargeTurretBase> turrets = new List<IMyLargeTurretBase>();
List<IMyThrust> thrusters = new List<IMyThrust>();
List<IMyGyro> gyroscopes = new List<IMyGyro>();
List<IMyLandingGear> landinggear = new List<IMyLandingGear>();
List<IMyShipConnector> connectors =  new List<IMyShipConnector>();
IMyTimerBlock timerblock;
double elevation;
//

public Program()
{
	GridTerminalSystem.GetBlocksOfType<IMyShipConnector>(connectors, c02 => c02.IsSameConstructAs(Me));
	GridTerminalSystem.GetBlocksOfType<IMyShipController>(shipControllers, c05 => c05.IsSameConstructAs(Me));
	GridTerminalSystem.GetBlocksOfType<IMyThrust>(thrusters, c06 => c06.IsSameConstructAs(Me));
	GridTerminalSystem.GetBlocksOfType<IMyLandingGear>(landinggear, c07 => c07.IsSameConstructAs(Me));
	GridTerminalSystem.GetBlocksOfType<IMyLargeTurretBase>(turrets, c09 => c09.IsSameConstructAs(Me));
	GridTerminalSystem.GetBlocksOfType<IMyGyro>(gyroscopes, c10 => c10.IsSameConstructAs(Me));
	
	Runtime.UpdateFrequency = UpdateFrequency.Update100;

}
public Vector3D normalise(Vector3D v) 
{ 
    return (v.Length() < 0.001) ? v * 0 : v / v.Length(); 
} 

void Main(string argument)
{    
    if (!((ShipIsControlled() || TurretIsControlled())) || argument == "manual")
    {
        EnableInertiaDampeners();
        ThrusterControl();
        TurnOffGyroOverride();
		LockLandingGear();
        TriggerTimer(); 
    }
	if (argument == "dampeners")
	{
		EnableInertiaDampeners();
	}
	//if (ShipIsFalling())
	//{
	//	EnableInertiaDampeners();
	//}
}  

/*bool ElevationCheck()
{
    foreach (IMyShipController shipctrl in shipControllers)
        if (shipctrl.TryGetPlanetElevation(MyPlanetElevation.Surface, out elevation)) 
            return elevation < 100;
    return false;
}

*/bool ShipIsFalling()
{
	foreach (IMyShipController shipctrl in shipControllers)
	Matrix invWorldRot = Matrix.Invert(Matrix.Normalize(this.shipctrl.CubeGrid.WorldMatrix)).GetOrientation();
    Vector3D velocity = this.shipctrl.GetShipVelocities().LinearVelocity;
    Vector3 localSpaceVelocity = Vector3.Transform(velocity, invWorldRot);
		if(yVelocity < 10 || ElevationCheck()) 
			return true;
		
	return false;
} */

bool ShipIsControlled()
{
    
    foreach (IMyShipController shipctrl in shipControllers)
    {
        if (shipctrl.IsUnderControl)
        {
            return true;
        }
    }
    return false;
}

bool TurretIsControlled()
{
    
    foreach (IMyLargeTurretBase turret in turrets)
	{	
		if (turret.IsUnderControl)
		{
			return true;
		}
	}
	return false;
}
  
void EnableInertiaDampeners()
{
    foreach (IMyShipController shipctrl in shipControllers) 
    {
		if (!(LandingGearLocked() || ConnectorConnected()))
		{
		shipctrl.DampenersOverride = true;
		}
    }
}
 
void ThrusterControl()
{
    
    foreach (IMyThrust thrstr in thrusters)
    {   
		if (!(thrstr.Enabled || thrstr.CustomName.Contains("Module") || LandingGearLocked() || ConnectorConnected()))
		{
		thrstr.Enabled = true;
		thrstr.SetValueFloat("Override", 0);
		}
	}
}
 
void TurnOffGyroOverride()
{
    
    foreach (IMyGyro gyro in gyroscopes)
    {
        gyro.ApplyAction("OnOff_On");
        gyro.GyroOverride = false;
        }

  }
 
bool ConnectorConnected()
{
    
    foreach (IMyShipConnector cn in connectors)
    {

		if (cn.Status == MyShipConnectorStatus.Connected) 
		{
            return true;
        }
    }
    return false;
}

bool LandingGearLocked()
{
	foreach (IMyLandingGear lg in landinggear)
	{
		if (lg.IsLocked)
		{
		return true;
		}
    }
    return false;
}		

void LockLandingGear()
{ 
	foreach (IMyLandingGear lg in landinggear)
	{
		lg.Lock();
	}
}

void TriggerTimer() 
{
    timerblock = GridTerminalSystem.GetBlockWithName("SafetySwitch") as IMyTimerBlock;
	if (timerblock == null) 
    {
        return;
    }
	timerblock.Trigger();
}

/*
TODO: Null detection for Listed blocks. Use 
*/
