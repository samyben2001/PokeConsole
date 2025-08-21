using PokemonGame.Models.Enums;
using PokemonGame.Models.Models;

namespace PokemonGame
{
    internal static class BattleManager
    {
        internal static Player GenerateEnemy()
        {
            Player enemy = new Player("Ennemi");
            for (int i = 0; i < Tools.Tools.GetRandomNumber(1, 6); i++)
            {
                enemy.Pokemons.Add(Pokemon.GeneratePokemon());
            }

            Items potions = new Items(ItemsNames.Potions.ToString(), Tools.Tools.GetRandomNumber(0, 6), 99);
            enemy.Bag.Items.Add(potions);
            return enemy;
        }

        internal static void StartFight(Player player, Player enemy)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (player.Pokemons.FirstOrDefault(p => p.IsAlive, null) is null)
            {
                Console.WriteLine("Vous ne pouvez pas combattre pour le moment! Vous n'avez aucun Pokémons en vie!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Vous avez rencontrer un adversaire. Préparez-vous pour le combat!");
            Console.ResetColor();
            Pokemon? pokeEnemy;
            Pokemon? pokePlayer;
            bool playerAdvantage = SetPlayerAdvantage(); ;
            bool fightIsOver = false;

            do
            {
                // Récupère le premier Pokémon en vie de chanque dresseur
                pokeEnemy = enemy.Pokemons.FirstOrDefault(p => p.IsAlive, null);
                pokePlayer = player.Pokemons.FirstOrDefault(p => p.IsAlive, null);

                if (pokeEnemy == null || pokePlayer == null)
                {
                    fightIsOver = true; // Fin de combat si l'un des 2 dresseurs ne possède plus de Pokémon en vie
                }
                else
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(pokePlayer);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" VS ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(pokeEnemy);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        if (playerAdvantage)
                        {
                            // Tour du joueur
                            int menuChoice = Menu.FightMenu(player);
                            SelectFightOption(menuChoice, player, pokePlayer, pokeEnemy);
                        }
                        else
                        {
                            // Tour de l'adversaire
                            int menuChoice = (enemy.Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity > 0) && (pokeEnemy.Health < pokeEnemy.MaxHealth * 0.75) ? Tools.Tools.GetRandomNumber(1, 2) : 1;
                            SelectFightOption(menuChoice, enemy, pokeEnemy, pokePlayer);
                        }
                        playerAdvantage = !playerAdvantage;
                    } while (pokePlayer.IsAlive && pokeEnemy.IsAlive); // Combat à mort entre 2 Pokémons
                }
            } while (!fightIsOver);

            DisplayFightWinner(player);
        }

        private static void DisplayFightWinner(Player player)
        {
            if (player.Pokemons.FirstOrDefault(p => p.IsAlive, null) is not null)
            {
                Console.WriteLine("Vous avez remporter le combat!");
            }
            else
            {
                Console.WriteLine("Vous avez perdu le combat!");
            }
        }

        private static bool SetPlayerAdvantage()
        {

            // Aléatoire pour déterminer qui commence
            bool playerAdvantage;
            if (Tools.Tools.GetRandomNumber(0, 1) == 1)
            {
                playerAdvantage = true;
                Console.WriteLine("Vous avez pris l'avantage!");
            }
            else
            {
                playerAdvantage = false;
                Console.WriteLine("Votre adversaire à pris l'avantage!");
            }

            return playerAdvantage;
        }

        private static void SelectFightOption(int menuChoice, Player player, Pokemon fighter, Pokemon target)
        {
            switch (menuChoice)
            {
                case 1: // Attaque
                    fighter.Attacks(target);
                    break;
                case 2: // Soin
                    player.HealPokemon(fighter);
                    break;
                default:
                    break;
            }
        }
    }
}
