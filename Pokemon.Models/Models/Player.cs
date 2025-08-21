using PokemonGame.Models.Enums;
using PokemonGame.Models.Exceptions;
using PokemonGame.Models.Interfaces;
using System.Numerics;

namespace PokemonGame.Models.Models
{
    public class Player : IPlayer
    {
        private string? _name;
        private List<Pokemon> _pokemons = new List<Pokemon>();
        private List<Pokemon> _pokemonsReserve = new List<Pokemon>();
        private Inventory _bag = new Inventory();


        public List<Pokemon> Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }
        public string? Name { get => _name; set => _name = value; }
        public Inventory Bag { get => _bag; set => _bag = value; }
        public List<Pokemon> PokemonsReserve { get => _pokemonsReserve; set => _pokemonsReserve = value; }

        public Player()
        { }

        public Player(string name)
        {
            Name = name;
        }

        public bool ListPokemons(bool inReserve = false)
        {
            bool isNotEmpty = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVos Pokemons" + (inReserve ? " en réserve" : "") + ":");
            Console.ResetColor();
            List<Pokemon> pokes = inReserve ? PokemonsReserve : Pokemons;

            Console.WriteLine("________________________________");
            if (pokes.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nVous n'avez aucun Pokémon" + (inReserve ? " en réserve!" : " sur vous!"));
                Console.ResetColor();
                isNotEmpty = false;
            }
            else
            {
                for (int i = 0; i < pokes.Count; i++)
                {
                    Console.ResetColor();
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.WriteLine(i + 1 + " - " + pokes.ElementAt(i));
                    Console.ResetColor();
                }
            }
            Console.WriteLine("________________________________");
            return isNotEmpty;
        }

        public void StockPokemon(Pokemon pokemon)
        {
            Pokemons.Remove(pokemon);
            PokemonsReserve.Add(pokemon);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{pokemon.Name} à bien été mis en réserve");
            Console.ResetColor();
            ListPokemons(true);
        }

        public void GetPokemonFromReserve(Pokemon pokemon)
        {
            if (Pokemons.Count + 1 > 6) // Check si le joueur à la place pour capturer un pokémon
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas la place pour récupérer ce Pokémon! Pensez à en déposer dans votre réserve d'abord!");
                Console.ResetColor();
            }
            else
            {
                PokemonsReserve.Remove(pokemon);
                Pokemons.Add(pokemon);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{pokemon.Name} à bien été récupéré");
                Console.ResetColor();
                ListPokemons();
            }
        }

        public void HealPokemons()
        {
            try
            {
                Pokemons.ForEach(p =>
                {
                    if (p.IsAlive && p.Health < 100) // Check si le pokémon n'est pas mort ou en pleine santé
                    {
                        p.Health = 100;
                    }
                });
                Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity -= Pokemons.FindAll(p => p.IsAlive).Count;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tous vos Pokémons ont bien été soignés");
                Console.ResetColor();
            }
            catch (NotEnoughResourcesException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public void HealPokemon(Pokemon pokemon)
        {
            if (pokemon.IsAlive && pokemon.Health < 100) // Check si le pokémon n'est pas mort ou en pleine santé
            {
                pokemon.Health = 100;
                Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity--;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{pokemon.Name} à bien été soigné");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (!pokemon.IsAlive)
                {
                    Console.WriteLine("Vous ne pouvez pas soigner ce Pokémon. Il est actuellement mort.");
                }
                else
                {
                    Console.WriteLine("Ce Pokémon est déja en pleine santé!");
                }
            }
            Console.ResetColor();
        }

        public void TryToCapture(Pokemon pokemon)
        {
            if (Pokemons.Count + 1 > 6) // Check si le joueur à la place pour capturer un pokémon
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas la place pour capturer un Pokémon! Pensez à en déposer dans votre réserve");
                Console.ResetColor();
            }
            else
            {

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Vous rencontrez un {pokemon.Name} sauvage!");

                    Bag.Items.First(i => i.Name == ItemsNames.PokeBalls.ToString()).Quantity--;

                    // Génère un nombre aléatoire qui doit être supérieur au taux de capture du pokémon à capturer
                    if (Tools.Tools.GetRandomNumber(0, 100) >= pokemon.CaptureRate)
                    {
                        Pokemons.Add(pokemon);
                        pokemon.Health = 50;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Bravo vous l'avez capturé!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Malheureusement il s'enfuit!");
                    }

                }
                catch (NotEnoughResourcesException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                catch (NotEnoughSpaceException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                Console.ResetColor();
            }
        }

        public void GetInfos()
        {
            string str =
                $"╔{string.Concat(Enumerable.Repeat("═", 21))}╗\n" +
                $"║ {Name} {string.Concat(Enumerable.Repeat(" ", 19 - Name.Length))}║\n" +
                $"║ {Bag.Items.First(i => i.Name == ItemsNames.Potions.ToString()).Quantity} potions restantes ║\n" +
                $"║ {Pokemons.Count(p => p.IsAlive)} Pokemons restants ║\n" +
                $"╚{string.Concat(Enumerable.Repeat("═", 21))}╝\n";
            Console.WriteLine(str);
        }
    }
}
