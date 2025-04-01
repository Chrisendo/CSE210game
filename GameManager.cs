using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;

    private List<GameObject> _gameObjects = new List<GameObject>();

    Random _random = new Random();

    // Player score, starts at zero
    private int _score;

    // Player health, starts at 5
    private int _health;

    private bool _gameOver;

    private double _gameOverTimer;

    public GameManager()
    {
        _title = "CSE 210 Game";
        _score = 0;
        _health = 1;
        _gameOver = false;
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
            if (!_gameOver)
            {
                HandleInput();
                ProcessActions();

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                DrawElements();
                DrawHealthAndScore();

                Raylib.EndDrawing();
                SpawnFallingObjects();
            }
            else
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                DrawGameOver();
                Raylib.EndDrawing();
            }

            if(_gameOver && Raylib.GetTime() - _gameOverTimer > 10)
            {
                break;
            }

            if(_health == 0 && !_gameOver)
            {
                _gameOver = true;
                _gameOverTimer = Raylib.GetTime();
            }
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
        Console.WriteLine("Player created!");

        // Gems g1 = new Gems(50, 50);
        // Gems g2 = new Gems(100,50);
        // _gameObjects.Add(g1);
        // _gameObjects.Add(g2);
    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {
        if (!_gameOver)
        {
            Player p = GetPlayer();
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                p.MoveLeft();
            }

            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                p.MoveRight();
            }
        }
    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {
        if (!_gameOver)
        {
            Player p = GetPlayer();
            if (p != null)
            {
                List<GameObject> objectsToRemove = new List<GameObject>();

                foreach (GameObject obj in _gameObjects)
                {
                    obj.Move(5, SCREEN_HEIGHT);

                    if (obj is Gems gem && IsCollision(p, gem))
                    {
                        _score = _score + 1;
                        objectsToRemove.Add(gem);
                    }
                    else if (obj is Bombs bomb && IsCollision(p, bomb))
                    {
                        _health = _health - 1;
                        objectsToRemove.Add(bomb);
                    }
                    else if (obj.GetY() > SCREEN_HEIGHT)
                    {
                        objectsToRemove.Add(obj);
                    }
                }

                foreach (GameObject objToRemove in objectsToRemove)
                {
                    _gameObjects.Remove(objToRemove);
                }
            }
        }
    }


    private Player GetPlayer()
    {
        foreach (GameObject obj in _gameObjects)
        {
            if (obj is Player)
            {
                return (Player)obj;
            }
        }
        return null;
    }


    private bool IsCollision(GameObject first, GameObject second)
    {
        return first.GetRight() >= second.GetLeft()
            && first.GetLeft() <= second.GetRight()
            && first.GetBottom() >= second.GetTop()
            && first.GetTop() <= second.GetBottom();
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


    private void SpawnFallingObjects()
    {
        if (_random.Next(100) < 2)
        {
            _gameObjects.Add(new Gems(_random.Next(SCREEN_WIDTH - 25), 0));
        }
        if (_random.Next(100) < 1)
        {
            _gameObjects.Add(new Bombs(_random.Next(SCREEN_WIDTH - 25), 0));
        }
    }


    private void DrawHealthAndScore()
    {
        Raylib.DrawText("Score: " + _score, 10, 10, 20, Color.Black);
        Raylib.DrawText("Health: " + _health, 10, 40, 20, Color.Black);
    }


    private void DrawGameOver()
    {
        Raylib.DrawText("Game Over!", SCREEN_WIDTH / 2 - 100, SCREEN_HEIGHT / 2 - 20, 40, Color.Red);
        Raylib.DrawText($"Final Score: {_score}", SCREEN_WIDTH / 2 - 100, SCREEN_HEIGHT / 2 + 30, 20, Color.White);
    }
}