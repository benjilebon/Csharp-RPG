using System;
using System.Collections.Generic;

namespace RPG
{
    class ItemsData
    {
        static List<Item> items = new List<Item> {
            new Item(0, 1, 30, 1, "Petite potion de soin", "Une potion pour soigner vos blessures", 10),
            new Item(1, 3, 3, 1, "Épée longue", "Une simple épée d'entrainement basique", 15),
            new Item(2, 2, 10, 1, "Armure d'étoffe", "Une armure en métal pour encaisser les dégats", 20),

            new Item(3, 1, 75, 2, "Elixir de soin", "Une potion pour soigner vos blessures", 15),
            new Item(4, 3, 8, 2, "Sabre vicié", "Un sabre pour trancher vos ennemis", 25),
            new Item(5, 2, 25, 2, "Cotte de mailles", "Une armure lourde pour parer un nombre conséquents de dégats", 40),

            new Item(6, 4, 25, 3, "Bracelet Cristallin", "Un bracelet renforcé en cristal augmentant vos HP", 30),
            new Item(7, 3, 25, 3, "BF Glaive", "Un redoutable Glaive pour trancher vos adversaires", 50),
            new Item(8, 2, 45, 3, "Cotte épineuse", "Puissante armure contre les plus gros adversaires", 60),

            new Item(9, 4, 100, 4, "Warmog", "Une armure vivant offrant une grande vitalité", 100),
            new Item(10, 1, 250, 4, "Rédemption", "Bénédiction divine soignant une grande quantité d'hp", 45),
            new Item(11, 3, 45, 4, "Soif de Sang", "Épée maudite capable de trancher toute matière", 75),
        };
        
        public ItemsData()
        {
        }

        public static List<Item> getItems(int level)
        {
            List<Item> sortedItems = items.FindAll(x => x.level <= level);

            return sortedItems;
        }

        public static List<Item> getItemsPage(int level, List<Item> list)
        {
            List<Item> sortedPage = list.FindAll(x => x.level == level);

            return sortedPage;
        }


        
    }
   
}