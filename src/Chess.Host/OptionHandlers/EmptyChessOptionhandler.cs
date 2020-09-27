using Chess.Application;
using CommonServiceLocator;
using System;

namespace Chess.Host
{
    public class EmptyChessOptionhandler : IOptionhandler
    {
        private readonly IServiceLocator _serviceLocator;

        public EmptyChessOptionhandler(IServiceLocator serviceLocator)
        {
            this._serviceLocator = serviceLocator;
        }
        public void ExecuteOption()
        {
            Console.WriteLine("Welcome to the empty chess board piece movement calculation flow.");
            var emptyMovementUseCase = _serviceLocator.GetInstance<IUseCase<string, string>>(Keystore.EmptyChessMovement);
            var key = "Y";
            while (key.Equals("N", StringComparison.OrdinalIgnoreCase) == false)
            {
                try
                {
                    Console.WriteLine("Please Enter the piece name and its initial location in the form \"pieceName location\" for example, \"King A1\"");
                    var input = Console.ReadLine().Trim();
                    var response = emptyMovementUseCase.Execute(input);
                    Console.WriteLine($"The output: {response.Trim()}");                    
                }
                catch (BaseApplicationException ex)
                {
                    Console.WriteLine($"Some error occured. {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Some error occured.");
                }
                finally
                {
                    Console.WriteLine("Do you want to continue? Please select Y/N");
                    key = Console.ReadLine().Trim().ToUpper();
                }

            }

        }
    }
}
