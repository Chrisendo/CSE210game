public abstract class GameObject
{
    protected int _x;
    protected int _y;


    public GameObject(int x, int y)
    {
        _x = x;
        _y = y;
    }


    public abstract void Draw();
    public abstract void Move(int speed, int screenLimit);
    public abstract int GetLeft();
    public abstract int GetRight();
    public abstract int GetTop();
    public abstract int GetBottom();
    public int GetY()
    {
        return _y;
    }
}