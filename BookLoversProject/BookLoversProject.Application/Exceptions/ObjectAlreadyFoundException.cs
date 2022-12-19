namespace BookLoversProject.Application.Exceptions
{
    public class ObjectAlreadyFoundException: Exception
    {
        public ObjectAlreadyFoundException() { }

        public ObjectAlreadyFoundException(string? message) : base(message) { }
    }
}
