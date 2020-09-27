namespace Chess.Application
{
    /// <summary>
    /// This defines the general system exception.
    /// </summary>
    public class SystemException : BaseApplicationException
    {
        public SystemException(string message) : base(message)
        {
        }
    }
}
