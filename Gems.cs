//using System.Drawing;

using Raylib_cs;

public class Gems : GameObject
{
    public Gems(int x, int y) : base(x, y)
    {
        // init other things like the gems value, and speed
    }

    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, 25, 25, Color.Green);
    }
}