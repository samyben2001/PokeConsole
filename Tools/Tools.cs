namespace PokemonGame.Tools
{
    public class Tools
    {
        public int getRandomNumber(int min, int max) { 
            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }
    }
}
