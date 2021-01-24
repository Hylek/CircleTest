using Godot;

// The player's state when they enter Volume 1.
public class BananaState : State
{
    public BananaState()
    {
        stateID = StateID.Volume1;
        stateMessage = "I am a BANANA!";
        debugStateName = "BananaState";
    }

    public override void ExecuteState(Player player)
    {
        GD.Print("I am a BANANA!");

        ResetScale(player);
        ResetTexture(player);
        player.shape.Modulate = new Color(1, 1, 0, 1);
    }
}
