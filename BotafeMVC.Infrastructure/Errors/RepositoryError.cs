using BotafeMVC.Common;

namespace BotafeMVC.Infrastructure.Errors
{
    public class RepositoryError : IError
    {
        public RepositoryError(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
