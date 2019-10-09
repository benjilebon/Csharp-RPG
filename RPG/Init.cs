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

        //private void Run()
        //{
        //    while (player.hp > 0 && m.hp > 0)
        //    {
        //        Console.WriteLine(player.name + ": " + player.hp + " hp");
        //        Console.WriteLine("Monster: " + m.hp + " hp");
        //        Console.ReadLine();
        //        player.receiveAttack(m);
        //        m.receiveAttack(player);
        //    }
        //    if (m.hp <= 0)
        //        Console.WriteLine("You win!");
        //    else
        //        Console.WriteLine("You lose...");
        //}

        public void goHome()
        {
            new Home(player);
        }
    }
}
