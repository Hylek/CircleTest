using Godot;

// The player's state when they enter Volume 1.
public class BananaState : State
{
    public BananaState()
    {
        stateMessage = "I am a BANANA!";
        stateID = "BananaState";
    }

    public override void ExecuteState(Player player)
    {
        GD.Print("I am a BANANA!");

        ResetScale(player);
        ResetTexture(player);
        player.shape.Modulate = new Color(1, 1, 0, 1);
    }
}
