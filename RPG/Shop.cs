using System;

namespace RPG
{
    class Shop
    {
        Player player;

        public Shop(Player player, Item boughtItem = null, int error = 0, int p = 0)
        {
            this.player = player;
            int page = (p != 0 ? p : player.level);  
            Console.Clear();
            Console.WriteLine("Boutique: " + player.name + "\n");
            Program.WriteFormattedLine("Vous avez {0} HP", Program.colors[10], player.getHp());
            Program.WriteFormattedLine("Vous avez {0} Armure", Program.colors[10], player.getArmor());
            Program.WriteFormattedLine("Vous avez {0} Dégats d'attaque", Program.colors[10], player.getDp());
            Program.WriteFormattedLine("Vous avez {0} golds", Program.colors[14], player.getGolds());
            Console.WriteLine("");

            Console.WriteLine("\n ============================================= \n");

            if (boughtItem is Item)
            {
                Console.WriteLine("Vous avez acheté : " + boughtItem.name);
            } else
            {
                foreach (Item item in ItemsData.getItemsPage(page, ItemsData.getItems(player.level)))
                {
                    item.showItem();
                }
            }
            Console.WriteLine("\n ===================Page "+page+"====================");
            Console.WriteLine(" ============================================= \n");

            if (boughtItem is Item)
            {
                Program.WriteFormattedLine("Appuyez sur N'importe quelle touche pour retourner à la boutique", Program.colors[4], "");
            }

            if (error == 1)
            {
                Program.WriteFormattedLine("{0}", Program.colors[4], "Vous n'avez pas assez de golds");
            }

            if (error == 2)
            {
                Program.WriteFormattedLine("{0}", Program.colors[4], "Vous avez déjà tous vos points de vie");
            }
            Program.WriteFormattedLine("Appuyez sur {0} pour acheter un item", Program.colors[4], "Enter");
            Program.WriteFormattedLine("Appuyez sur {0} pour retourner à l'accueil", Program.colors[4], "b");
            if (boughtItem is Item)
            {

            }
            ConsoleKey shopInput = Console.ReadKey().Key;
            string itemInput = "";
            switch(shopInput)
            {
                case ConsoleKey.Enter:
                    Program.WriteFormattedLine("Entrez l'{0} de l'objet que vous souhaitez acheter", Program.colors[4], "ID");
                    itemInput = Console.ReadLine();
                    break;
                case ConsoleKey.B:         new Home(player); break;
                case ConsoleKey.LeftArrow:
                    page--;
                    new Shop(player, null, 0, page);
                    break;
                case ConsoleKey.RightArrow:
                    page++;
                    new Shop(player, null, 0, page);
                    break;
                default:                   new Shop(player); break;
            }

            if (Int32.TryParse(itemInput, out int res))
            {
                Item item = ItemsData.getItems(player.level).Find(x => x.id == res);

                if (item == null || boughtItem is Item)
                {
                    new Shop(player);
                }
                else
                {
                    buyItem(item);
                }


            }
            else if (itemInput == "b")
            {
                new Home(player);
            }
            else
            {
                new Shop(player);
            }
        }

        private void buyItem(Item item)
        {
            if (player.golds < item.golds)
            {
                new Shop(player, null, 1);
            }

            switch (item.itemType)
            {
                case 1:
                    if (player.hp == player.totalHp) new Shop(player, null, 2);
                    player.golds -= item.golds; 
                    if (player.hp + item.value > player.totalHp) player.hp = player.totalHp;
                    else player.hp += item.value;
                    break;
                case 2: player.golds -= item.golds; player.armor += item.value; break;
                case 3: player.golds -= item.golds; player.dp += item.value; break;
                case 4: player.golds -= item.golds; player.totalHp += item.value; break;
            }

            new Shop(player, item, 0);
        }
    }
}