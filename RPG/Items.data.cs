using System;
using System.Collections.Generic;

namespace RPG
{
    class ItemsData
    {
        static List<Item> items = new List<Item> {
            new Item(0, 1, 30, 1, "Petite potion de soin", "Une potion pour soigner vos blessures", 10),
            new Item(1, 3, 6, 1, "�p�e longue", "Une simple �p�e d'entrainement basique", 15),
            new Item(2, 2, 8, 1, "Armure d'�toffe", "Une armure en m�tal pour encaisser les d�gats", 25),

            new Item(3, 1, 75, 2, "Elixir de soin", "Une potion pour soigner vos blessures", 15),
            new Item(4, 3, 15, 2, "Sabre vici�", "Un sabre pour trancher vos ennemis", 25),
            new Item(5, 2, 15, 2, "Cotte de mailles", "Une armure lourde pour parer un nombre cons�quents de d�gats", 45),

            new Item(6, 4, 25, 3, "Bracelet Cristallin", "Un bracelet renforc� en cristal augmentant vos HP", 30),
            new Item(7, 3, 35, 3, "BF Glaive", "Un redoutable Glaive pour trancher vos adversaires", 50),
            new Item(8, 2, 30, 3, "Cotte �pineuse", "Puissante armure contre les plus gros adversaires", 75),

            new Item(9, 4, 100, 4, "Warmog", "Une armure vivant offrant une grande vitalit�", 100),
            new Item(10, 1, 250, 4, "R�demption", "B�n�diction divine soignant une grande quantit� d'hp", 45),
            new Item(11, 3, 60, 4, "Soif de Sang", "�p�e maudite capable de trancher toute mati�re", 75),
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