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

        private static List<GameObject> gameObjects = new List<GameObject>();

        public static List<GameObject> GameObjects
        {
            get { return gameObjects; }
            set { gameObjects = value; }
        }

        public static string[][] ships = new string[][]
        {
            new string[]
            {
                "WWW",
                "WWW",
                "WWW"
            },

            new string[]
            {
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
            },

            new string[]
            {
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
            },
            
            new string[]
            {
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW"
            },
    
            new string[]
            {
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW",
                "   ",
                "WWW",
                "WWW",
                "WWW"
            }
        };

        public static ConsoleKey currentKey;
        public DateTime end;
        public float deltaTime;

        public Marker green;

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
            gameObjects.Add(new MoveAbleMarker(8,8,"G"));
            gameObjects.Add(new Marker(76,16,"R"));
            

        }

        public void Update()
        {
            TimeSpan deltaTimeSpan = DateTime.Now-end;
            int milliseconds = deltaTimeSpan.Milliseconds > 0 ? deltaTimeSpan.Milliseconds : 1;
            deltaTime = 1f/1000f/(float)milliseconds;
            end = DateTime.Now;
            Console.Title = "Dt " + deltaTime;
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
        }

        public static void PlaceShip(int x,int y)
        {
            gameObjects.Add(new Ship(x+1,y+1,0,0));
        }
    }
}
