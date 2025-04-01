//using System.Drawing;

using Raylib_cs;

public class Gems : GameObject
{
    private int _width;
    private int _height;


    public Gems(int x, int y) : base(x, y)
    {
        _width = 25;
        _height = 25;
    }


    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, Color.Green);
    }


    public override void Move(int speed, int screenLimit)
    {
        _y += speed;
    }


    public override int GetLeft()
    {
        return _x;
    }


    public override int GetRight()
    {
        return _x + _width;
    }


    public override int GetTop()
    {
        return _y;
    }


    public override int GetBottom()
    {
        return _y + _height;
    }
}