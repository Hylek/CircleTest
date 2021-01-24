using Godot;

// Base class for each of the Player's states.
// Opted for class instead of interface due to flexilbity of polymorphism
public class State
{
    protected StateID stateID;
    protected string debugStateName;

    // The text message that is associated with this state
    protected string stateMessage;

    public State()
    {
        stateID = StateID.Default;
        debugStateName = "";
        stateMessage = "";
    }

    protected void ResetScale(Player player)
    {
        player.shape.Scale = new Vector2(1, 1);
    }

    protected void ResetColour(Player player)
    {
        // Resets player's sprite colour back to white.
        player.shape.Modulate = new Color(1, 1, 1, 1);
    }

    protected void ResetTexture(Player player)
    {
        player.shape.Texture = player.circleTexture;
    }

    public virtual void ExecuteState(Player player)
    {
        ResetColour(player);
        ResetScale(player);
        ResetTexture(player);
    }

    public StateID GetStateID()
    {
        return stateID;
    }

    public string GetStateDebugName()
    {
        return debugStateName;
    }

    public string GetStateMessage()
    {
        return stateMessage;
    }
}
