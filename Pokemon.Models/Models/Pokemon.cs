using PokemonGame.Models.Enums;
using static PokemonGame.Tools.Tools;

namespace PokemonGame.Models.Models
{
    public class Pokemon
    {
        private int _health;
        private int _maxHealth;
        private bool _isAlive = true;
        private string _name;
        private int _attack;
        private int _defense;
        private int _speed;
        private int? _captureRate;

        public int Health { 
            get => _health; 
            set {
                if (value < 0)
                {
                    value = 0;
                    IsAlive = false;
                }

                if (value > MaxHealth) {
                    value = MaxHealth;
                }

                _health = value;
            } 
        }
        public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public string Name { get => _name; set => _name = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public int? CaptureRate { get => _captureRate; set => _captureRate = value; }

        public Pokemon(string name)
        {
            Name = name;
            MaxHealth = 100;
            Health = 100;
            Attack = GetRandomNumber(10, 100);
            Defense = GetRandomNumber(10, 100);
            Speed = GetRandomNumber(10, 100);
        }

        public Pokemon(string name, int captureRate)
        {
            Name = name;
            CaptureRate = captureRate;
            MaxHealth = 100;
            Health = 100;
            Attack = GetRandomNumber(10, 100);
            Defense = GetRandomNumber(10, 100);
            Speed = GetRandomNumber(10, 100);
        }

        public void Attacks(Pokemon target)
        {
            int damage = (int)((Attack * GetRandomFloatNumber(1, 1.5)) - (target.Defense * GetRandomFloatNumber(1, 1.5)));
            damage = damage < 0 ? 0 : damage;
            Console.WriteLine($"{Name} à attaqué et ingligé {damage} dégats à {target.Name}!");
            target.Health -= damage;

            if (!target.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} à mis KO {target.Name}!");
                Console.ResetColor();
            }
        }

        public static Pokemon GeneratePokemon()
        {
            return new Pokemon(Enum.GetName((PokeNames)GetRandomNumber(0, Enum.GetValues<PokeNames>().Length)), GetRandomNumber(10, 90));
        }

        public override string ToString()
        {
            return $"{Name}: HP:{Health}/100 - ATT:{Attack} - DEF:{Defense} - VIT:{Speed}";
        }
    }
}
