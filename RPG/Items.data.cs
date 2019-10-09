using System;
using System.Collections.Generic;

namespace RPG
{
    class ItemsData
    {
        static List<Item> items = new List<Item>();
        
        public ItemsData()
        {
        }

        public static List<Item> addItemsToShop(int level)
        {
            if (level == 1)
            {
                items.Add(new Item(0, 1, 5, 1, "Petite potion de soin", "Une potion pour soigner vos blessures", 10));
                items.Add(new Item(1, 3, 5, 1, "�p�e longue", "Une simple �p�e d'entrainement basique", 15));
                items.Add(new Item(2, 2, 8, 1, "Armure d'�toffe", "Une armure en m�tal pour encaisser les d�gats", 30));

                if (level == 2)
                {
                    items.Add(new Item(3, 1, 10, 2, "Elixir de soin", "Une potion pour soigner vos blessures", 15));
                    items.Add(new Item(4, 3, 8, 2, "Sabre vici�", "Un sabre pour trancher vos ennemis", 25));
                    items.Add(new Item(5, 2, 15, 2, "Cotte de mailles", "Une armure lourde pour parer un nombre cons�quents de d�gats", 50));
                }
            }

            return items;
        }


        
    }
   
}