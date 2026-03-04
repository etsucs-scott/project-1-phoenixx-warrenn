using AdventureGame.Core;

var maze = new Maze(12, 12);
maze.GenerateBasicMaze();

var player = new Player();
var engine = new GameEngine();

string message = "Welcome to Adventure Game! Use WASD or Arrow Keys to move.";

while (true)
{
    Console.Clear();

    Console.WriteLine($"HP: {player.Health}");
    Console.WriteLine(message);
    Console.WriteLine();

    DrawMaze(maze);

    if (player.Health <= 0)
    {
        Console.WriteLine("\nYou died. Game Over.");
        break;
    }

    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Q)
        break;

    var (dx, dy) = GetMovement(key);

    if (dx != 0 || dy != 0)
    {
        message = maze.MovePlayer(dx, dy, player, engine);

        if (message.Contains("WIN!"))
        {
            Console.Clear();
            Console.WriteLine("YOU ESCAPED THE MAZE!");
            break;
        }
    }
}

static void DrawMaze(Maze maze)
{
    for (int y = 0; y < maze.Height; y++)
    {
        for (int x = 0; x < maze.Width; x++)
        {
            char symbol = maze.Grid[y, x] switch
            {
                TileType.Wall => '#',
                TileType.Empty => '.',
                TileType.Player => '@',
                TileType.Monster => 'M',
                TileType.Weapon => 'W',
                TileType.Potion => 'P',
                TileType.Exit => 'E',
                _ => '?'
            };

            Console.Write(symbol + " ");
        }
        Console.WriteLine();
    }
}

static (int dx, int dy) GetMovement(ConsoleKey key)
{
    return key switch
    {
        ConsoleKey.W => (0, -1),
        ConsoleKey.S => (0, 1),
        ConsoleKey.A => (-1, 0),
        ConsoleKey.D => (1, 0),
        ConsoleKey.UpArrow => (0, -1),
        ConsoleKey.DownArrow => (0, 1),
        ConsoleKey.LeftArrow => (-1, 0),
        ConsoleKey.RightArrow => (1, 0),
        _ => (0, 0)
    };

}
