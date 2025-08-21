using PokemonGame.Models.Enums;
using PokemonGame.Models.Exceptions;

namespace PokemonGame.Models.Models
{
    public class Items
    {
        private string _name;
        private int _quantity;
        private int _maxQuantity;
        private int? _price;

        public string Name { get => _name; set => _name = value; }
        public int Quantity { 
            get => _quantity; 
            set { 
                if (Name == ItemsNames.Money.ToString() && value < 0)
                    throw new NotEnoughResourcesException("Vous n'avez pas assez d'argent pour cet achat!");
                else if (Name == ItemsNames.PokeBalls.ToString() && value < 0)
                    throw new NotEnoughResourcesException("Vous êtes à cours de Pokeball! Pensez à passer à la boutique!");
                else if (Name == ItemsNames.Potions.ToString() && value < 0)
                    throw new NotEnoughResourcesException("Vous êtes à cours de Potions! Pensez à passer à la boutique!");

                if (value > MaxQuantity)
                    throw new NotEnoughSpaceException("Vous n'avez pas assez d'espace pour ceci!");

                _quantity = value; 
            }}
        public int MaxQuantity { get => _maxQuantity; set => _maxQuantity = value; }
        public int? Price { get => _price; set => _price = value; }

        public Items(string name, int quantity, int max_quantity)
        {
            Name = name;
            MaxQuantity = max_quantity;
            Quantity = quantity;
        }

        public Items(string name, int quantity, int max_quantity, int price)
        {
            Name = name;
            MaxQuantity = max_quantity;
            Quantity = quantity;
            Price = price;
        }
    }

}
