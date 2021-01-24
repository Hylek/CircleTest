using Godot;

// The player's state when they enter Volume 3.
public class ShortState : State
{
    public ShortState()
    {
        stateID = StateID.Volume3;
        debugStateName = "ShrunkCircleState";
        stateMessage = "I'm in Volume 3, it's nice here!";
    }

    public override void ExecuteState(Player player)
    {
        GD.Print("I'm in Volume 3, it's nice here!");

        ResetTexture(player);
        ResetColour(player);
        player.shape.Scale = new Vector2(player.shape.Scale.x, player.shape.Scale.y / 2);
    }
}
