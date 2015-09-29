using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Ship:GameObject
    {
        public int type, rotation,length;

        public Ship(int posX,int posY,int type,int rotation):base(posX,posY)
        {
            this.type = type;
            this.rotation = rotation;
            Setup();
        }

        public void Setup()
        {
            length = type;
            //GameManager.drawer.DrawPicture(posX, posY, GameManager.ships[type]);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            switch (rotation)
            {
                case 0:
                    for (int i = 1; i <= type - 1; i++)
                    {
                        GameManager.drawer.DrawPicture(posX + i * 4, posY + 1, new string[]
                    {
                        "WWWWW",
                        "WWWWW",
                        "WWWWW",
                    });
                    }

                    GameManager.drawer.DrawPicture(posX + 1, posY + 1, new string[]
                {
                    " WWW",
                    "WWWW",
                    " WWW",
                });

                    GameManager.drawer.DrawPicture(posX + 1 + type * 4, posY + 1, new string[]
                {
                    "W",
                    "WWW",
                    "W",
                });


                    break;
                case 1:
               
                    for (int i = 1; i <= type - 1; i++)
                    {

                        GameManager.drawer.DrawPicture(posX + 1, posY + i * 4, new string[]
                    {
                        "WWW",
                        "WWW",
                        "WWW",
                        "WWW",
                        "WWW"
                    });
                    }

                    GameManager.drawer.DrawPicture(posX + 1, posY + 1, new string[]
                {
                    " W ",
                    "WWW",
                    "WWW",
                    "WWW"
                });

                    GameManager.drawer.DrawPicture(posX + 1, posY + type * 4, new string[]
                {
                    "WWW",
                    "WWW",
                    " W ",
                    " W "
                });

                    break;

                case 2:
                   
                    for (int i = 1; i <= type - 1; i++)
                    {
                        GameManager.drawer.DrawPicture(posX - i * 4, posY + 1, new string[]
                    {
                        "WWWWW",
                        "WWWWW",
                        "WWWWW",
                    });
                    }

                    GameManager.drawer.DrawPicture(posX, posY + 1, new string[]
                {
                    "WWW ",
                    "WWWW",
                    "WWW",
                });

                    GameManager.drawer.DrawPicture(posX + 1 - type * 4, posY + 1, new string[]
                {
                    "  W",
                    "WWW",
                    "  W",
                });

                    break;
                case 3:

                    for (int i = 1; i <= type - 1; i++)
                    {

                        GameManager.drawer.DrawPicture(posX + 1, posY - i * 4, new string[]
                    {
                        "WWW",
                        "WWW",
                        "WWW",
                        "WWW",
                        "WWW"
                    });
                    }

                    GameManager.drawer.DrawPicture(posX + 1, posY, new string[]
                {
                    "WWW",
                    "WWW",
                    "WWW",
                    " W "
                });

                    GameManager.drawer.DrawPicture(posX + 1, posY + 1 - type * 4, new string[]
                {
                    " W ",
                    " W ",
                    "WWW",
                });

                    break;
            }

            //GameManager.drawer.DrawPicture(posX, posY, GameManager.ships[type]);
            base.Draw();
        }
    }
}
