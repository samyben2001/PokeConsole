namespace PokemonGame.Models.Exceptions
{
    public class NotEnoughSpaceException : Exception
    {
        public NotEnoughSpaceException()
        {
        }

        public NotEnoughSpaceException(string? message) : base(message)
        {
        }

        public NotEnoughSpaceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
