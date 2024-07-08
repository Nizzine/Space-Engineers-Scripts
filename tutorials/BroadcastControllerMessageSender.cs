/* {Nz}®️ Broadcast Controller Message Sender v.0.2
================================================================
Nizzine Technologies.
How to use:
Press "Run" in Programmable Block and it will send a new message each time.

*/
// Declare dependencies and variables
IMyBroadcastController broad; // Broadcast controller instance
IMyChatBroadcastControllerComponent broadEC; // Chat broadcast component instance
List<string> messages = new List<string>(); // List of messages to display
int index = 0; // Index of the current message

public Program()
{
    // Get the broadcast controller instance and check if it's not null
    broad = GridTerminalSystem.GetBlockWithName("Broadcast Controller") as IMyBroadcastController;
    if (broad != null)
    {
        // Try to get the chat broadcast component from the broadcast controller
        broad.Components.TryGet<IMyChatBroadcastControllerComponent>(out broadEC);
    }
    Init(); // Initialize the program
}

void Init()
{
    // Add messages to the list
    messages.AddRange(new string[]
    {
        "One elephunk",
        "Two birbs",
        "TRHEEEEEEEE",
        "Fourth",
        "Be on doubt",
        "SixXx",
        "Sven",
        "I have a pen",
        "nine... presumably",
        "Ten",
        "Now they stole my pen"
    });
}

public void Main()
{
    // Check if the chat broadcast component is null
    if (broadEC == null)
    {
        Echo("Warn: Broadcast Controller or component not found"); // Display a warning message
        return; // Exit the method
    }

    // Set the initial message and send it to be displayed
    broadEC.SetMessage(0, messages[index]);
    broadEC.SendMessage(0);

    // Increment the index and wrap around if necessary
    index = (index + 1) % messages.Count;
}
