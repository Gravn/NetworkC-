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
            for (int i = 0; i < color.Length; i++)
            {
                for (int j = 0; j < color[i].Length; j++)
                {
                    switch(color[i][j])
                    {
                        case 'G':
                            bg = ConsoleColor.Green;
                            break;
                        case 'B':
                            bg = ConsoleColor.Blue;
                            break;
                        case 'R':
                            bg = ConsoleColor.Red;
                            break;
                        case 'g':
                            bg = ConsoleColor.Gray;
                            break;

                        default:
                        bg = ConsoleColor.White;
                        break;
                    }

                    DrawColor(posY + j, posX + i, bg);
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
