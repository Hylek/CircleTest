using Godot;

public class PlayerLabel : Label
{
    public override void _Ready()
    {
        Player.onStateUpdate += UpdateMessage;
    }

    private void UpdateMessage(State newState)
    {
        Text = newState.GetStateMessage();
    }
}
