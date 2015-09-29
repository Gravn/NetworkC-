using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class FireMarker:Marker
    {

        public FireMarker(int posX,int posY,string color):base(posX,posY,color)
        {

        }

        public override void Update(float deltaTime)
        {
            switch (GameManager.currentKey)
            {
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Move(0);
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Move(1);
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Move(2);
                    break;

                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Move(3);
                    break;
            
                case ConsoleKey.Spacebar:
                    
                    //Fire!

                    break;
            }

            base.Update(deltaTime);
        }
    }
}
