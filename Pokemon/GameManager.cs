using PokemonGame.Models.Enums;
using PokemonGame.Models.Exceptions;
using PokemonGame.Models.Models;

namespace PokemonGame
{
    internal static class GameManager
    {
        private static Player player = new Player();

        public static void StartGame()
        {
            AskPlayerName();
            InitializePlayerBag();
            ChoicePokemonStart();
            ChoiceMenuOption();
        }

        // Initialisation de l'inventaire du joueurs avec qualques objets de base
        private static void InitializePlayerBag()
        {
            Items money = new Items(ItemsNames.Money.ToString(), 100, 9999);
            Items pokeballs = new Items(ItemsNames.PokeBalls.ToString(), 80, 99);
            Items potions = new Items(ItemsNames.Potions.ToString(), 6, 99);
            player.Bag.Items.Add(money);
            player.Bag.Items.Add(pokeballs);
            player.Bag.Items.Add(potions);
        }

        // Initialisation du joueur avec son nom
        private static void AskPlayerName()
        {
            Console.WriteLine("Entrez le nom de votre Personnage");
            player.Name = Console.ReadLine()!;
        }

        // Assignation du pokémon de départ
        private static void ChoicePokemonStart()
        {
            Pokemon bulbizarre = new Pokemon(PokeNames.Bulbizarre.ToString());
            Pokemon carapuce = new Pokemon(PokeNames.Carapuce.ToString());
            Pokemon salameche = new Pokemon(PokeNames.Salameche.ToString());

            int pokeChoice = Menu.SelectStartPokemon();
            Console.ForegroundColor = ConsoleColor.Green;
            switch (pokeChoice)
            {
                case 1:
                    Console.WriteLine($"{bulbizarre.Name} sélectionné!");
                    player.Pokemons.Add(bulbizarre);
                    break;
                case 2:
                    Console.WriteLine($"{carapuce.Name} sélectionné!");
                    player.Pokemons.Add(carapuce);
                    break;
                case 3:
                    Console.WriteLine($"{salameche.Name} sélectionné!");
                    player.Pokemons.Add(salameche);
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }

        // Gestion du menu principal
        private static void ChoiceMenuOption()
        {
            int menuChoice = Menu.MainMenu(player);
            int pokeChoice;
            switch (menuChoice)
            {
                case 1: // Voir Pokemons
                    player.ListPokemons();
                    break;
                case 2: // Mettre en réserve un Pokémon
                    pokeChoice = GetPlayerPokemonChoice("Quel Pokémon voulez-vous mettre en réserve? (0 = Annuler)");
                    if (pokeChoice > 0)
                        player.StockPokemon(player.Pokemons.ElementAt(pokeChoice - 1));
                    break;
                case 3: // Récupèrer un Pokémon de la réserve
                    pokeChoice = GetPlayerPokemonChoice("Quel Pokémon voulez-vous récupérer? (0 = Annuler)", true);
                    if (pokeChoice > 0)
                        player.GetPokemonFromReserve(player.PokemonsReserve.ElementAt(pokeChoice - 1));
                    break;
                case 4: // Soigner tous les Pokémons
                    player.HealPokemons();
                    break;
                case 5: // Soigner un Pokémon spécifique
                    pokeChoice = GetPlayerPokemonChoice("Quel Pokémon voulez-vous soigner? (0 = Annuler)");
                    if (pokeChoice != -1)
                        player.HealPokemon(player.Pokemons.ElementAt(pokeChoice - 1));
                    break;
                case 6: // Tenter de capturer un Pokémon
                    player.TryToCapture(Pokemon.GeneratePokemon());
                    break;
                case 7: // TODO: Combattre un dresseur
                    break;
                case 8: // Aller à la boutique
                    Shop.OpenShop(player);
                    break;
                case 0: // Quitter le jeu
                    Console.WriteLine("Partie Terminée!");
                    break;
                default:
                    break;
            }

            if (menuChoice != 0)
                ChoiceMenuOption();
        }

        // Récupérer le pokemon choisi par le joueur => renvoie -1 si aucun Pokémon dans la liste
        private static int GetPlayerPokemonChoice(string message, bool fromReserve = false)
        {
            if (!player.ListPokemons(fromReserve))
                return -1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();

            int pokeChoice;

            while (!int.TryParse(Console.ReadLine(), out pokeChoice) || (pokeChoice < 0 || pokeChoice > (fromReserve ? player.PokemonsReserve.Count + 1 : player.Pokemons.Count + 1)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrez un nombre valide!");
                Console.ResetColor();
            }

            return pokeChoice;
        }
    }
}
