using System.Net.Sockets;

namespace AdventureGame.Core
{
    


    public class Maze
    {
        //actual maze dimensions
        public int Width { get; }
        public int Height { get; }

        public TileType[,] Grid { get; }
        
        //player spot
        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }

        private Random rng = new();

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new TileType[height, width];
        }
    //game ready maze
    private void PlaceExit()
        {
            Grid[Height - 2, Width - 2] = TileType.Exit;
        }

    private void PlaceRandomMonsters(int count)
        {
            PlaceRandomTiles(TileType.Monster, count);
        }

    private void PlaceRandomPotions(int count)
        {
            PlaceRandomTiles(TileType.Potion, count);
        }

    private void  PlaceRandomWeapons(int count)
        {
            PlaceRandomTiles(TileType.Weapon, count);
        }

    private void PlaceRandomTiles(TileType type, int count)
        {
            int placed = 0;

            while (placed < count)
            {
                int x = rng.Next(1, Width - 1);
                int y = rng.Next(1, Height - 1);

                if (Grid[y, x] == TileType.Empty)
                {
                    Grid[y, x] = type;
                    placed++;
                }
            }
        }
// Maze Generation

    public void GenerateBasicMaze()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                        Grid[y, x] = TileType.Wall;
                    else
                        Grid[y, x] = TileType.Empty;
                }
            }

            PlaceExit();
            PlaceRandomMonsters(5);
            PlaceRandomPotions(3);
            PlaceRandomWeapons(3);

            PlacePlayer();
        }

    private void PlacePlayer()
        {
            PlayerX = 1;
            PlayerY = 1;

            Grid[PlayerY, PlayerX] = TileType.Player;
        }

        public string MovePlayer(int dx, int dy, Player player, GameEngine engine)
        {
            int newX = PlayerX + dx;
            int newY = PlayerY + dy;

            //boundaries
            if (newX < 0 || newX >= Width || newY < 0 || newY >= Height)
                return "You can't go that way.";

            TileType targetTile = Grid[newY, newX];

            //walls
            if (targetTile == TileType.Wall)
                return "You hit the wall.";

            //clearing old positions
            Grid[PlayerY, PlayerX] = TileType.Empty;
            PlayerX = newX;
            PlayerY = newY;

            string message = "";

            //tile interaction
            switch (targetTile)
            {
                case TileType.Monster:
                    var monster = new Monster();
                    message = engine.StartBattle(player, monster);
                    break;

                case TileType.Potion:
                    player.Heal(20);
                    message = "You drank a potion. (+20 HP!)";
                    break;

                case TileType.Weapon:
                    var weapon = new Weapon("Sword", 5);
                    player.Inventory.Add(weapon);
                    message = "You picked up a weapon!!";
                    break;

                case TileType.Exit:
                    message = "YOU MADE IT!!!";
                    break;
            }

            //new position
            Grid[PlayerY, PlayerX] = TileType.Player;

            return message;
        }
    }




}