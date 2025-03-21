using Raylib_cs;

public class Player : GameObject
{


    public Player(int x, int y) : base(x, y)
    {
        
    }


    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, 50, 10, Color.Blue);
    }
}