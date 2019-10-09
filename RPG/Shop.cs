using System;

namespace RPG
{
    class Shop
    {
        Player player;

        public Shop(Player player, Item boughtItem = null, int error = 0)
        {
            this.player = player;
            Console.Clear();
            Console.WriteLine("Boutique: " + player.name + "\n");
            Console.WriteLine();
            Program.WriteFormattedLine("Vous avez {0} HP", Program.colors[10], player.getHp());
            Program.WriteFormattedLine("Vous avez {0} Armure", Program.colors[10], player.getArmor());
            Program.WriteFormattedLine("Vous avez {0} Dégats d'attaque", Program.colors[10], player.getDp());
            Program.WriteFormattedLine("Vous avez {0} golds", Program.colors[14], player.getGolds());
            Console.WriteLine("\n \n");

            Console.WriteLine("\n ============================== \n");

            if (boughtItem is Item)
            {
                Console.WriteLine("Vous avez acheté : " + boughtItem.name);
            } else
            {
                foreach (Item item in ItemsData.getItems(player.level))
                {
                    item.showItem();
                }
            }

            Console.WriteLine("\n ============================== \n");

            if (boughtItem is Item)
            {
                Program.WriteFormattedLine("Appuyez sur N'importe quelle touche pour retourner à la boutique", Program.colors[4], "");
            } else
            {
                Program.WriteFormattedLine("Entrez l'{0} de l'objet que vous souhaitez acheter", Program.colors[4], "ID");
            }

            if (error == 1)
            {
                Program.WriteFormattedLine("{0}", Program.colors[4], "Vous n'avez pas assez de golds");
            }

            if (error == 2)
            {
                Program.WriteFormattedLine("{0}", Program.colors[4], "Vous avez déjà tous vos points de vie");
            }
            Program.WriteFormattedLine("Appuyez sur {0} pour retourner à l'accueil", Program.colors[4], "b");
            string shopInput = Console.ReadLine();

            if (Int32.TryParse(shopInput, out int res))
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
            else if (shopInput == "b")
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