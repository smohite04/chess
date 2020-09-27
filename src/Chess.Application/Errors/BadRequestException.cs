namespace Chess.Application
{
    /// <summary>
    /// This defines the invalid request exception
    /// </summary>
    public class BadRequestException : BaseApplicationException
    {        
        public BadRequestException(string message) : base(message)
        {

        }     
    }
}
