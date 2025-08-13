using PokemonGame.Models.Enums;
using PokemonGame.Models.Models;

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nQue Voulez-vous faire?:");
            Console.ResetColor();
            Console.WriteLine("1 - Voir vos Pokémons");
            Console.WriteLine("2 - Mettre un Pokémon en réserve");
            Console.WriteLine("3 - Récupèrer un Pokémon de la réserve");
            Console.WriteLine($"4 - Soigner vos Pokémons ({player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity} potions restantes)");
            Console.WriteLine($"5 - Soigner un Pokémon ({player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity} potions restantes)");
            Console.WriteLine($"6 - Capturer un Pokémon ({player.Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString()).Quantity} pokéballs restantes)");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQue voulez-vous achetez? ({player.Bag.Items.First(i => i.Name == ItemsNames.Money.ToString()).Quantity})\n");
            Console.ResetColor();
            Console.WriteLine($"1 - Pokeball (10PO)   [{player.Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString()).Quantity}]");
            Console.WriteLine($"2 - Potion   (10PO)   [{player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity}]");
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
    }
}
