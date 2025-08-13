using PokemonGame.Models.Enums;
using PokemonGame.Models.Exceptions;
using PokemonGame.Models.Models;

namespace PokemonGame
{
    internal static class Shop
    {

        internal static void OpenShop(Player player)
        {
            int shopChoice;
            do
            {
                shopChoice = Menu.Shop(player);
                try
                {
                    switch (shopChoice)
                    {
                        case 1: // Acheter une pokéball
                            player.Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString()).Quantity++;
                            player.Bag.Items.First(i => i.Name == ItemsNames.Money.ToString()).Quantity -= 10;
                            break;
                        case 2: // Acheter une potion
                            player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity++;
                            player.Bag.Items.First(i => i.Name == ItemsNames.Money.ToString()).Quantity -= 10;
                            break;
                        default:
                            break;
                    }
                }
                catch (NotEnoughResourcesException ex)   // Check si argent suffisant
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                catch (NotEnoughSpaceException ex)  // Check si inventaire pas rempli
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

            } while (shopChoice != 0);  // Quitter la boutique
        }
    }
}
