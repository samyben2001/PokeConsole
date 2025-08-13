using PokemonGame.Models.Enums;
using static PokemonGame.Tools.Tools;

namespace PokemonGame.Models.Models
{
    public class Pokemon
    {
        private int _health;
        private string _name;
        private int _attack;
        private int _defense;
        private int _speed;
        private int? _captureRate;

        public int Health { get => _health; set => _health = value; }
        public string Name { get => _name; set => _name = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public int? CaptureRate { get => _captureRate; set => _captureRate = value; }

        public Pokemon(string name)
        {
            Name = name;
            Health = 100;
            Attack = GetRandomNumber(10, 100);
            Defense = GetRandomNumber(10, 100);
            Speed = GetRandomNumber(10, 100);
        }

        public Pokemon(string name, int captureRate)
        {
            Name = name;
            CaptureRate = captureRate;
            Health = 100;
            Attack = GetRandomNumber(10, 100);
            Defense = GetRandomNumber(10, 100);
            Speed = GetRandomNumber(10, 100);
        }

        public override string ToString()
        {
            return $"{Name}: HP:{Health}/100 - ATT:{Attack} - DEF:{Defense} - VIT:{Speed}";
        }

        public static Pokemon GeneratePokemon()
        {
            return new Pokemon(Enum.GetName((PokeNames)GetRandomNumber(0, Enum.GetValues<PokeNames>().Length)), GetRandomNumber(10, 90));
        }
    }
}
