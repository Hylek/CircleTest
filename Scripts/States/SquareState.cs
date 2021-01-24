using Godot;
using System;

// The player's state when they enter Volume 2.
public class SquareState : State
{
    public SquareState()
    {
        stateID = StateID.Volume2;
        debugStateName = "SquareState";
        stateMessage = "I am not myself today";
    }

    public override void ExecuteState(Player player)
    {
        GD.Print("I am not myself today");

        ResetScale(player);
        player.shape.Modulate = new Color(1, 0, 0, 1);
        player.shape.Texture = player.squareTexture;
    }
}
