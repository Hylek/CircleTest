using Godot;

// The debug UI text that tells the user what state the player is currently in.
public class StateLabel : Label
{
    private const string labelPrefix = "The player's current state is: ";

    public override void _Ready()
    {
        Player.onStateUpdate += UpdateDebugMessage;
    }

    private void UpdateDebugMessage(State state)
    {
        Text = labelPrefix + state.GetStateDebugName();
    }

}
