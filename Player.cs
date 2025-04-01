using Raylib_cs;

public class Player : GameObject
{

    // Other member variables
    private int _speedOfPlayer;
    private int _width;
    private int _height;
    
    public Player(int x, int y) : base(x, y)
    {
        _width = 50;
        _height = 10;
        _speedOfPlayer = 10;
    }


    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, Color.Blue);
    }


    // Other methods

    public void MoveLeft()
    {
        // Updates the X position
        if (_x - 5 >= 0)
        {
            _x = _x - _speedOfPlayer;
        }
    }

    public void MoveRight()
    {
        // Updates the X position
        if (_x + 5 <= GameManager.SCREEN_WIDTH - _width)
        {
            _x = _x + _speedOfPlayer;
        }
    }


    public override void Move(int speed, int screenLimit)
    {
    
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