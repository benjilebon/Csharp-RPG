using System;
using System.Collections.Generic;

namespace RPG
{
    class ItemsData
    {
        static List<Item> items = new List<Item> {
            new Item(0, 1, 25, 1, "Petite potion de soin", "Une potion pour soigner vos blessures", 10),
            new Item(1, 3, 6, 1, "Épée longue", "Une simple épée d'entrainement basique", 15),
            new Item(2, 2, 8, 1, "Armure d'étoffe", "Une armure en métal pour encaisser les dégats", 30),

            new Item(3, 1, 50, 2, "Elixir de soin", "Une potion pour soigner vos blessures", 15),
            new Item(4, 3, 15, 2, "Sabre vicié", "Un sabre pour trancher vos ennemis", 25),
            new Item(5, 2, 15, 2, "Cotte de mailles", "Une armure lourde pour parer un nombre conséquents de dégats", 50),
        };
        
        public ItemsData()
        {
        }

        public static List<Item> getItems(int level)
        {
            List<Item> sortedItems = items.FindAll(x => x.level <= level);

            return sortedItems;
        }


        
    }
   
}