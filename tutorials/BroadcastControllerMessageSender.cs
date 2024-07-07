/* {Nz}®️ Broadcast Controller Message Sender v.0.1
================================================================
Nizzine Technologies.
How to use:
Press "Run" in Programmable Block and it will send a new message each time.
*/
IMyBroadcastController broad;
IMyChatBroadcastControllerComponent broadEC;
int mesegg = 0;
int set = 0;

public Program()
{
    broad = GridTerminalSystem.GetBlockWithName("Broadcast Controller") as IMyBroadcastController;
    if (broad != null)
    {
        broad.Components.TryGet<IMyChatBroadcastControllerComponent>(out broadEC);
    }
}

public void Main()
{    
    if (broadEC == null)
    {
        Echo("Warn: Broadcast Controller or component not found");
        return;
    }
    int currentMaxMessageCount = broadEC.MaxMessageCount;
    string[] currentMessages = new string[currentMaxMessageCount];

    for (int i = 0; i < currentMaxMessageCount; i++)
    {
        currentMessages[i] = broadEC.GetMessage(i);
    }

    if (set == 0)
    {
        broadEC.SetMessage(0, "One");
        broadEC.SetMessage(1, "Two");
        broadEC.SetMessage(2, "Three");
        broadEC.SetMessage(3, "Nizzine Technologies is supreme");
        broadEC.SetMessage(4, "Five");
        broadEC.SetMessage(5, "Six");
        broadEC.SetMessage(6, "Seven");
        broadEC.SetMessage(7, "Nizzine is clever");
        broadEC.SendMessage(mesegg);
        mesegg++;
        

    }
    else if (set == 1)
    {
        broadEC.SetMessage(0, "Eight");
        broadEC.SetMessage(1, "Nine");
        broadEC.SetMessage(2, "Ten");
        broadEC.SetMessage(3, "Flash your tetten");
        broadEC.SetMessage(4, "Elev... no tetten? Meh..");
        broadEC.SetMessage(5, "Bye then.");
        broadEC.SetMessage(6, "-ended transmission-");
        broadEC.SetMessage(7, "");
        broadEC.SendMessage(mesegg);
        mesegg++;
    }
    else if (set >= 2)
    {
        set = 0;
        mesegg = 0;
    }
    
    if (mesegg >= 8)
    {
        set++;
        mesegg = 0;
    }

    Echo(mesegg.ToString());
    Echo(set.ToString());

}

