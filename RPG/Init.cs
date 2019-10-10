using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Init
    {
        Player player;


        public Init()
        {
            Console.Write("Votre nom: ");
            string name = Console.ReadLine();
            player = new Player(name);
        }

        public void goHome()
        {
            new Home(player);
        }
    }
}
