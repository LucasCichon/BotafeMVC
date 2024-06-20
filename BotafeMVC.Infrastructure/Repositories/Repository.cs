using BotafeMVC.Common;
using BotafeMVC.Domain.Interfaces;
using BotafeMVC.Infrastructure.Errors;

namespace BotafeMVC.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        public Either<IError, TResult> Invoke<TResult>(Func<TResult> func)
        {
            try
            {
                return Either<IError, TResult>.Success(func.Invoke());

            }
            catch (Exception ex)
            {
                return Either<IError, TResult>.Error(new RepositoryError(ex.Message));

            }
        }
    }
}
