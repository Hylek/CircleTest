using Godot;
using System;

// Main class that handles all logic relating to the player.
public class Player : KinematicBody2D
{
    [Export]
    public int speed = 500;

    public Sprite shape { get; set; }
    public State currentState { get; set; }

    public Texture circleTexture { get; set; }
    public Texture squareTexture { get; set; }

    private Vector2 velocity = new Vector2();

    public override void _Ready()
    {
        shape = GetNode<Sprite>("Sprite");

        // Preload textures rather than constantly loading them at runtime
        // C# version does not allow use of preloader yet :(
        circleTexture = LoadTextureFromResource("res://Images/circle.png");
        squareTexture = LoadTextureFromResource("res://Images/square.png");

        // On start assume the player's state is default.
        currentState = new DefaultState();
        currentState.ExecuteState(this);
    }

    public override void _PhysicsProcess(float delta)
    {
        ProcessInput();

        velocity = MoveAndSlide(velocity);
    }

    // Queries if the following keys (from action in InputMap) have been pressed every update.
    private void ProcessInput()
    {
        velocity = Vector2.Zero;

        if(Input.IsActionPressed("up"))
        {
            velocity.y -= 1;
        }
        if(Input.IsActionPressed("down"))
        {
            velocity.y += 1;
        }
        if(Input.IsActionPressed("left"))
        {
            velocity.x -= 1;
        }
        if(Input.IsActionPressed("right"))
        {
            velocity.x += 1;
        }

        // Prevent diagonal movement from being double the speed.
        velocity = velocity.Normalized() * speed;
    }

    // Loads and returns the texture from the given resource path.
    private Texture LoadTextureFromResource(string resPath)
    {
        return GD.Load<Texture>(resPath);
    }
}
