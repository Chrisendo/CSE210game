using Raylib_cs;

public class Player : GameObject
{

    // Other member variables


    public Player(int x, int y) : base(x, y)
    {
        // Other initialization tasks here
    }


    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, 50, 10, Color.Blue);
    }

    // Other methods
}