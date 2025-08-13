using PokemonGame.Models.Models;

namespace PokemonGame.Models.Interfaces
{
    internal interface IPlayer
    {
        public string? Name { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public List<Pokemon> PokemonsReserve { get; set; }
        public Inventory Bag { get; set; }
    }
}
