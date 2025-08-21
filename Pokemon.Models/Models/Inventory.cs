namespace PokemonGame.Models.Models
{
    public class Inventory
    {
        private List<Items> _items;

        //TODO: remove 'quantity' from 'Items' class and replace this  by a dictionnary List<dict<Items, int>>
        public List<Items> Items { get => _items; set => _items = value; }

        public Inventory()
        {
            Items = new List<Items>();
        }
    }
}
