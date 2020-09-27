using System;

namespace Chess.Host
{
    public class ExitHandler : IOptionhandler
    {
        public void ExecuteOption()
        {
            Environment.Exit(0);
        }
    }
}
