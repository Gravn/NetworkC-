using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class BattleShipMap
    {
        public BattleShipMap()
        {
            DrawMap();
        }

        public static void DrawMap()
        {
            Draw a = new Draw();

            //Setting up battle map:
            for (int i = 0; i < Console.BufferWidth - 1; i++)
            {
                for (int j = 0; j <= Console.BufferHeight - 3; j++)
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

                        if ((j == 2 || j == 46) && i % 4 == 2)
                        {
                            if (i < 44)
                            {
                                Console.SetCursorPosition(i, j);
                                Console.Write(i / 4 - 1);
                            }
                            else
                            {
                                Console.SetCursorPosition(i, j);
                                Console.Write((i - 44) / 4 - 1);
                            }
                        }

                        if ((i == 2 || i == 46) && j % 4 == 2)
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
        }
    }
}
