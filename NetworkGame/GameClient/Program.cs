using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Program
    {
        private static bool run = true;
        private static GameManager game = new GameManager();

        static void Main(string[] args)
        {
            game.Setup();
            while (run)
            {
               Tick();
            }
        }

        public static void Tick()
        {           
            game.Update();
        }

    }
}
