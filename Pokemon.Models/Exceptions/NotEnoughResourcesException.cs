namespace PokemonGame.Models.Exceptions
{
    public class NotEnoughResourcesException : Exception
    {
        public NotEnoughResourcesException()
        {
        }

        public NotEnoughResourcesException(string? message) : base(message)
        {
        }

        public NotEnoughResourcesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
