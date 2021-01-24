using Godot;

// Base class for each of the Player's states.
// Opted for class instead of interface due to flexilbity of polymorphism
public class State
{
    protected string stateID;

    // The text message that is associated with this state
    protected string stateMessage;

    public State()
    {
        stateID = "";
        stateMessage = "";
    }

    protected void ResetScale(Player player)
    {
        player.Scale = new Vector2(1, 1);
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

    public string GetStateID()
    {
        return stateID;
    }

    public string GetStateMessage()
    {
        return stateMessage;
    }
}
