using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Draw
    {

        public Draw()
        {

        }

        public void DrawPicture(int posX, int posY,string[]color)
        {
            ConsoleColor fg = ConsoleColor.Black;
            ConsoleColor bg = ConsoleColor.Magenta;
            //int j = 0;
            for (int i = 0; i < color.Length; i++)
            {
                for (int j=0; j < color[i].Length; j++)
                {
                    switch (color[i][j])
                    {
                        case 'G':
                            bg = ConsoleColor.Green;
                            DrawColor(posX+j, posY + i, bg);
                            break;
                        case 'B':
                            bg = ConsoleColor.Blue;
                            DrawColor(posX + j, posY + i, bg);
                            break;
                        case 'b':
                            bg = ConsoleColor.DarkBlue;
                            DrawColor(posX + j, posY + i, bg);
                            break;

                        case 'R':
                            bg = ConsoleColor.Red;
                            DrawColor(posX + j, posY + i, bg);
                            break;
                        case 'g':
                            bg = ConsoleColor.Gray;
                            DrawColor(posX + j, posY + i, bg);
                            break;

                        case ' ':
                            break;

                        default:
                            bg = ConsoleColor.White;
                            DrawColor(posX + i, posY + j, bg);
                            break;
                    }

                }
            }
        }

        public void DrawColor(int x, int y, ConsoleColor bg)
        {
            if (x >= 0 && x < Console.BufferWidth && y >= 0 && y < Console.BufferHeight && !(x==Console.BufferWidth-1 && y==Console.BufferHeight-1))
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = bg;
                Console.Write(" ");
            }
        }

        
    }
}
