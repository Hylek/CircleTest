using Godot;

public enum StateID
{
    Default = 0,
    Volume1 = 1,
    Volume2 = 2,
    Volume3 = 3
}

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
