using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;

    private List<GameObject> _gameObjects = new List<GameObject>();

    Random _random = new Random();

    // Player score, starts at zero
    private int _score = 0;

    // Player health, starts at 5
    private int _health = 5;

    public GameManager()
    {
        _title = "CSE 210 Game";
    }

    /// <summary>
    /// The overall loop that controls the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();

        InitializeGame();

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawElements();

            Raylib.EndDrawing();
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        // Create a player and add them to the list
        Player p = new Player(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 50);
        _gameObjects.Add(p);

        Gems g1 = new Gems(50, 50);
        Gems g2 = new Gems(100,50);
        _gameObjects.Add(g1);
        _gameObjects.Add(g2);
    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {
        // if (Raylib.IsKeyDown(KeyboardKey.Left))
        // {
        //     p.MoveLeft();
        // }

        // if (Raylib.IsKeyDown(KeyboardKey.Right))
        // {
        //     p.MoveRight();
        // }
    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {

    }

    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        foreach (GameObject item in _gameObjects)
        {
            item.Draw();
        }
    }
}