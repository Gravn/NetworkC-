using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class GameManager
    {
        bool quit = false;

        public static Draw drawer = new Draw();

        public static int[,] grid = new int[10,10];
        public static int[] ships = new int[] { 2, 2, 1, 1, 1 };


        //Ship placement
        public static bool moreToPlace = true;
        public static bool placerRemoved = false;
        public static ShipPlacementMarker shipPlacer = new ShipPlacementMarker(16, 16);


        //All GameObjects
        private static List<GameObject> gameObjects = new List<GameObject>();

        public static List<GameObject> GameObjects
        {
            get { return gameObjects; }
            set { gameObjects = value; }
        }

        public static string[][] shipparts = new string[][]
        {
            new string[]
            {
                "WWW",
                "WWW",
                "WWW"
            },

            new string[]
            {
                "WW ",
                "WWW",
                "WW "
            },

            new string[]
            {
                "   ",
                "   ",
                "   "
            }
        };

        public static ConsoleKey currentKey;
        public DateTime end;
        public float deltaTime;

        public GameManager()
        {

        }

        public void Setup()
        {
            Console.SetWindowSize(90, 50);
            Console.SetBufferSize(90, 50);

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            //start game
            BattleShipMap map = new BattleShipMap();

            gameObjects.Add(shipPlacer);
            //gameObjects.Add(new FireMarker(8,8,"G"));
            //gameObjects.Add(new Marker(76,16,"R"));
            

        }

        public void Update()
        {
            TimeSpan deltaTimeSpan = DateTime.Now-end;
            int milliseconds = deltaTimeSpan.Milliseconds > 0 ? deltaTimeSpan.Milliseconds : 1;
            deltaTime = 1f/10/milliseconds;
            end = DateTime.Now;
            if (Console.KeyAvailable)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
                currentKey = Console.ReadKey().Key;
            }

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(deltaTime);
            }

            currentKey = new ConsoleKey();
            Draw();
        }

        public void Draw()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw();
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    drawer.DrawText(50 + i, 20 + j, grid[i, j].ToString(), ConsoleColor.Black);
                }
            }

        }

        public static void EndTurn()
        {
            //Multiplayer:
            //Endturn and send message to other player via NetworkManager(not implemented yet)

            //local:
            //Change player(not implemented yet)
        }

        public static void ChangeGameMode()
        {
            gameObjects.Add(new FireMarker(shipPlacer.PosX + 44, shipPlacer.PosY, "G"));
            gameObjects.Remove(shipPlacer);
        }
    }
}
