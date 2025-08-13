namespace PokemonGame.Tools
{
    public static class Tools
    {
        public static int GetRandomNumber(int min, int max) { 
            Random random = new Random();
            return random.Next(min, max + 1);
        }
    }
}
