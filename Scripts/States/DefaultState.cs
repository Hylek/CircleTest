using Godot;

// The player's default white circle state when not in any volume.
public class DefaultState : State
{
    public DefaultState()
    {
        stateID = "DefaultState";
        stateMessage = "";
    }

    public override void ExecuteState(Player player)
    {
        GD.Print("I am NORMAL");

        base.ExecuteState(player);
    }
}
