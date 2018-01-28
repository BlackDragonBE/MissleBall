using InControl;

public class PlayerActions : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerOneAxisAction LeftRight;
    public PlayerOneAxisAction UpDown;
    public PlayerAction Shoot;
    public PlayerAction Boost;

    public PlayerActions()
    {
        Left = CreatePlayerAction("Left");
        Right = CreatePlayerAction("Right");
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        LeftRight = CreateOneAxisPlayerAction(Left, Right);
        UpDown = CreateOneAxisPlayerAction(Up, Down);
        Shoot = CreatePlayerAction("Shoot");
        Boost = CreatePlayerAction("Boost");
    }
}