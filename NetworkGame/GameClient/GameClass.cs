using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class GameClass
    {
        bool quit = false;

        public GameClass()
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
            Draw a = new Draw();
            

            //Setting up battle map:
            for (int i = 0; i < Console.BufferWidth-1; i++)
            {
                for (int j = 0; j <= Console.BufferHeight-3; j++)
                {
                    ConsoleColor bg = ConsoleColor.Blue;
                    a.DrawColor(i, j, bg);

                    if ((i < 4 || (i > 44 && i < 48)) || (j < 4 || (j > 44 && j < 48)))
                    {
                        bg = ConsoleColor.DarkGray;


                        if (i % 4 == 0 || j % 4 == 0)
                        {
                            bg = ConsoleColor.Black;
                        }
                        a.DrawColor(i, j, bg);

                        if ((j == 2||j==46) && i%4==2)
                        {
                            if (i < 44)
                            {
                                Console.SetCursorPosition(i, j);
                                Console.Write(i / 4 - 1);
                            }
                            else
                            {
                                Console.SetCursorPosition(i, j);
                                Console.Write((i-44) / 4 - 1);
                            }
                        }

                        if((i==2||i==46) && j%4 == 2)
                        {
                            Console.SetCursorPosition(i, j);
                            char c = 'X';
                            switch (j / 4 - 1)
                            {
                                case 0:
                                    c = 'A';
                                    break;
                                case 1:
                                    c = 'B';
                                    break;
                                case 2:
                                    c = 'C';
                                    break;
                                case 3:
                                    c = 'D';
                                    break;
                                case 4:
                                    c = 'E';
                                    break;
                                case 5:
                                    c = 'F';
                                    break;
                                case 6:
                                    c = 'G';
                                    break;
                                case 7:
                                    c = 'H';
                                    break;
                                case 8:
                                    c = 'I';
                                    break;
                                case 9:
                                    c = 'J';
                                    break;
                            }
                            Console.Write(c);
                        }
                    }
                    else
                    {
                        if (i % 4 == 0 || j % 4 == 0)
                        {
                            bg = ConsoleColor.DarkBlue;
                        }
                        a.DrawColor(i, j, bg);
                    }
                }
            }
            
            //Drawing ships, automate this?
            a.DrawPicture(3*3,3*3, new string[]
            {
                "   B   B  B",
                "   B   B   ",
                "   B   B  B"
                
            });

            a.DrawPicture(3*8+1, 3*4+1, new string[]
            {
                "   ",
                "   ",
                "   ",
                "BBB",
                "   ",
                "   ",
                "   ",
                "BBB",
                "RgRB B ",
                "gRgBB B",
                "RgRB B ",
                "BBB",
                "   ",
                "   ",
                "B B"
            });

            Console.ReadKey();
        }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        //UP
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        //Down
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        //Left
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        //right
                        break;


                }
            }
        }
    }
}
