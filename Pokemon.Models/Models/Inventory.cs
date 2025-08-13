namespace PokemonGame.Models.Models
{
    public class Inventory
    {
        private List<Items> _items;

        public List<Items> Items { get => _items; set => _items = value; }

        public Inventory()
        {
            Items = new List<Items>();
        }
    }
}
