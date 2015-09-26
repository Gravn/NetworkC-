using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    abstract class GameObject
    {
        protected int posX, posY;

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public GameObject(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public void Setup()
        { 
        
        }

        public virtual void Update(float deltaTime)
        { 
            
        }

        public virtual void Draw()
        { 
            
        }

        public void Destroy()
        {
            GameManager.GameObjects.Remove(this);
        }

    }
}
