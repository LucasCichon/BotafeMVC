using BotafeMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Domain.Interfaces
{
    public interface IRepository
    {
        Either<IError, TResult> Invoke<TResult>(Func<TResult> func);
    }
}
