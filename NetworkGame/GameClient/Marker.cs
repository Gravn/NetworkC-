using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Marker:GameObject
    {
        public string c;
        public char s = ' ';

        public Marker(int posX,int posY,string Color):base(posX,posY)
        {
            this.c = Color;
            Draw();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public void Move(int direction)
        {
            if(direction == 0 && posX < 40)
            {
                Clear();
                posX += 4;
            }

            if (direction == 1 && posY < 40)
            {
                Clear();
                posY += 4;
            }

            if (direction == 2 && posX > 4)
            {
                Clear();
                posX -= 4;
            }

            if (direction == 3 && posY > 4)
            {
                Clear();
                posY -= 4;
            }
        }

        public void Clear()
        {
            GameManager.drawer.DrawPicture(posX, posY, new string[]
            {
                "bb bb",
                "bBBBb",
                " BBB ",
                "bBBBb",
                "bb bb"
            });
        }

        public override void Draw()
        {
            GameManager.drawer.DrawPicture(posX, posY, new string[]
            {
                ""+c+c+s+c+c,
                ""+c+s+s+s+c,
                ""+s+s+s+s+s,
                ""+c+s+s+s+c,
                ""+c+c+s+c+c
            });
        }

    }
}
