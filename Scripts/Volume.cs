using Godot;
using System;

// Handles logic for all Volumes.
// Primarily sending custom signals on collision detection
public class Volume : Node2D
{
    [Export]
    public StateID id = StateID.Default;

    [Signal]
    public delegate void PlayerEnter(StateID id);

    [Signal]
    public delegate void PlayerExit();

    public void onPlayerEnter(CollisionObject2D body)
    {
        EmitSignal(nameof(PlayerEnter), id);
    }

    public void onPlayerExit(CollisionObject2D body)
    {
        EmitSignal(nameof(PlayerExit));
    }
}
