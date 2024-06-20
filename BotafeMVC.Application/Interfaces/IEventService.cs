using BotafeMVC.Application.ViewModels.Event;
using BotafeMVC.Common;

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
        Either<IError, int> Enroll(int id);
        void Delete(int id);
    }
}
