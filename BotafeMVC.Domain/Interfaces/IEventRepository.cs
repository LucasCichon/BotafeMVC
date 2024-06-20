using BotafeMVC.Common;
using BotafeMVC.Domain.Model;
using System;

namespace BotafeMVC.Domain.Interfaces
{
    public interface IEventRepository
    {
        void DeleteEvent(int itemId);

        int AddEvent(Event botafeEvent);

        IQueryable<Event> GetAllActiveEvents();
        IQueryable<EventEnrollment> GetAllEnrollments();
        IQueryable<EventEnrollment> GetAllEnrollments(int EventId);

        Event GetEvent(int id);
        void UpdateEvent(Event toUpdate);
        Either<IError, int> AddEnrollment(EventEnrollment enrollment);
    }
}
