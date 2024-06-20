using BotafeMVC.Application.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Application.Interfaces
{
    public interface IEventService
    {
        int AddEvent(NewEventVm model);
        ListEventForListVm GetAllEventsForList(int pageSize, int pageNo, string searchString, string userIsEnroled = null);
        ListEventForListVm GetUserEventsForList(int pageSize, int pageNo, string searchString, string userName);
        EventDetailsVm GetEventDetails(int id);
        EventEditVm GetEventForEdit(int id);
        void UpdateEvent(EventEditVm model);
        int Enroll(int id);
        void Delete(int id);
    }
}
