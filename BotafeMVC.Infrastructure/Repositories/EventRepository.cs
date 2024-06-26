﻿using BotafeMVC.Common;
using BotafeMVC.Domain.Interfaces;
using BotafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BotafeMVC.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Context _context;
        private readonly IRepository _repository;

        public EventRepository(Context context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public void DeleteEvent(int itemId)
        {
            var item = _context.Events.Find(itemId);
            if(item != null)
            {
                _context.Events.Remove(item);
                _context.SaveChanges();
            }
        }

        public int AddEvent(Event botafeEvent)
        {
            _context.Events.Add(botafeEvent);
            _context.SaveChanges();
            return botafeEvent.Id;
        }

        public IQueryable<Event> GetAllActiveEvents()
        {
            return _context.Events.Where(e => e.StatusId != 0);
        }

        public Event GetEvent(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEvent(Event toUpdate)
        {
            _context.Attach(toUpdate);
            _context.Entry(toUpdate).Property("Name").IsModified = true;
            _context.Entry(toUpdate).Property("StartDate").IsModified = true;
            _context.Entry(toUpdate).Property("EndDate").IsModified = true;
            _context.Entry(toUpdate).Property("TotalNumberOfPlaces").IsModified = true;

            _context.SaveChanges();
        }

        public IQueryable<EventEnrollment> GetAllEnrollments()
        {
            return _context.EventEnrollments.Include(e => e.IdentityUser).AsQueryable();
        }

        public IQueryable<EventEnrollment> GetAllEnrollments(int EventId)
        {
            return _context.EventEnrollments.Include(e => e.IdentityUser).Where(e => e.EventId == EventId).AsQueryable();
        }

        public Either<IError, int> AddEnrollment(EventEnrollment enrollment)
        {
            return _repository.Invoke(() =>
            {
                _context.EventEnrollments.Add(enrollment);
                _context.SaveChanges();
                return enrollment.Id;
            });
        }

       
    }
}
