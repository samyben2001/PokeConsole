namespace PokemonGame.Tools
{
    public static class Tools
    {
        public static int GetRandomNumber(int min, int max) { 
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        public static double GetRandomFloatNumber(double min, double max)
        {
            Random random = new Random();
            return min + (random.NextDouble() * (max - min));
        }
    }
}
