using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Ship:GameObject
    {
        public int type, rotation;

        public Ship(int posX,int posY,int type,int rotation):base(posX,posY)
        {
            this.type = type;
            this.rotation = rotation;
            Setup();
        }

        

        public void Setup()
        {
            GameManager.drawer.DrawPicture(posX, posY, GameManager.ships[type]);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            GameManager.drawer.DrawPicture(posX, posY, GameManager.ships[type]);
            base.Draw();
        }
    }
}
