using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Application.Interfaces
{
    public interface IEventService
    {
        List<int> GetAllEvents();
    }
}
