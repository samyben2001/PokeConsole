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
                    Items playerMoney = player.Bag.Items.First(i => i.Name == ItemsNames.Money.ToString());
                    switch (shopChoice)
                    {
                        case 1: // Acheter une pokéball
                            Items pokeball = player.Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString());
                            playerMoney.Quantity -= (int)pokeball.Price!;
                            pokeball.Quantity++;
                            break;
                        case 2: // Acheter une potion
                            Items potion = player.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString());
                            playerMoney.Quantity -= (int)potion.Price!;
                            potion.Quantity++;
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
