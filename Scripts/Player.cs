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

    public delegate void UpdateState(State newState);
    public static event UpdateState onStateUpdate;

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

        onStateUpdate(currentState);
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

    // Listens for the custom entry signal and determines the Volume type.
    public void onVolumeEnter(StateID id)
    {
        switch(id)
        {
            case StateID.Volume1:
                currentState = new BananaState();
                break;

            case StateID.Volume2:
                currentState = new SquareState();
                break;

            case StateID.Volume3:
                currentState = new ShortState();
                break;
        }
        currentState.ExecuteState(this);

        onStateUpdate(currentState);
    }

    public void onVolumeExit()
    {
        currentState = new DefaultState();
        currentState.ExecuteState(this);

        onStateUpdate(currentState);
    }
}
