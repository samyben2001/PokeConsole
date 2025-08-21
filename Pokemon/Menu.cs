using PokemonGame.Models.Enums;
using PokemonGame.Models.Models;
using System.Numerics;

namespace PokemonGame
{
    internal static class Menu
    {
        // Selection du Pokémon de départ
        internal static int SelectStartPokemon()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nChoississez votre pokémon de départ:");
            Console.ResetColor();
            Console.WriteLine($"1 - {PokeNames.Bulbizarre}");
            Console.WriteLine($"2 - {PokeNames.Carapuce}");
            Console.WriteLine($"3 - {PokeNames.Salameche}\n");

            int pokeChoice;
            while (!int.TryParse(Console.ReadLine(), out pokeChoice) || (pokeChoice < 1 || pokeChoice > 3))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntrez un nombre valide!\n");
                Console.ResetColor();
            }

            return pokeChoice;
        }

        // Affichage du menu principal
        internal static int MainMenu(Player player)
        {
            Items potions = player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString());
            Items pokeballs = player.Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nQue Voulez-vous faire?:");
            Console.ResetColor();
            Console.WriteLine("1 - Voir vos Pokémons");
            Console.WriteLine("2 - Mettre un Pokémon en réserve");
            Console.WriteLine("3 - Récupèrer un Pokémon de la réserve");
            Console.WriteLine($"4 - Soigner vos Pokémons ({potions.Quantity} potions restantes)");
            Console.WriteLine($"5 - Soigner un Pokémon ({potions.Quantity} potions restantes)");
            Console.WriteLine($"6 - Capturer un Pokémon ({pokeballs.Quantity} pokéballs restantes)");
            Console.WriteLine("7 - Affronter un dresseur");
            Console.WriteLine("8 - Boutique");
            Console.WriteLine("0 - Quitter\n");

            int menuChoice;
            while (!int.TryParse(Console.ReadLine(), out menuChoice) || (menuChoice < 0 || menuChoice > 8))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntrez un nombre valide!\n");
                Console.ResetColor();
            }

            return menuChoice;
        }

        // Affichage de la boutique
        internal static int Shop(Player player)
        {
            Items potions = player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString());
            Items pokeballs = player.Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString());
            Items money = player.Bag.Items.First(i => i.Name == ItemsNames.Money.ToString());
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nQue voulez-vous achetez? ({money.Quantity})\n");
            Console.ResetColor();

            Console.WriteLine($"1 - Pokeball ({pokeballs.Price}PO)   [{pokeballs.Quantity}]");
            Console.WriteLine($"2 - Potion   ({potions.Price}PO)   [{potions.Quantity}]");
            Console.WriteLine("0 - Quitter\n");

            int menuChoice;
            while (!int.TryParse(Console.ReadLine(), out menuChoice) || (menuChoice < 0 || menuChoice > 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntrez un nombre valide!\n");
                Console.ResetColor();
            }

            return menuChoice;
        }

        internal static int FightMenu(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQue voulez-vous faire?\n");
            Console.ResetColor();
            Console.WriteLine($"1 - Attaquer");
            Console.WriteLine($"2 - Soigner [{player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity}]");

            int menuChoice;
            while (!int.TryParse(Console.ReadLine(), out menuChoice) || (menuChoice < 1 || menuChoice > 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntrez un nombre valide!\n");
                Console.ResetColor();
            }

            return menuChoice;
        }

        internal static void FightDescritpion(Player player, Player enemy)
        {

        }
    }
}
