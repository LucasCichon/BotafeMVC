using AutoMapper;
using AutoMapper.QueryableExtensions;
using BotafeMVC.Application.Interfaces;
using BotafeMVC.Application.ViewModels.Event;
using BotafeMVC.Domain.Interfaces;
using BotafeMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BotafeMVC.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<IdentityUser> _userManager;

        public EventService(IEventRepository eventRepository, IMapper mapper, IHttpContextAccessor httpContext, UserManager<IdentityUser> userManager)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public int AddEvent(NewEventVm eventVm)
        {
            var model = _mapper.Map<Event>(eventVm);
            return _eventRepository.AddEvent(model);
        }

        public void Delete(int id)
        {
            _eventRepository.DeleteEvent(id);
        }

        public ListEventForListVm GetAllEventsForList(int pageSize, int pageNo, string searchString, string userIsEnroled = null)
        {
            pageSize = pageSize > 0 ? pageSize : 10;
            pageNo = pageNo > 0 ? pageNo : 1;
            searchString = searchString ?? string.Empty;

            var events = _eventRepository.GetAllActiveEvents().Where(p =>
                    p.Name.Contains(searchString)
                    && p.EndDate >= DateOnly.FromDateTime(DateTime.Now)
                    && p.StatusId != 0)                
                   .OrderBy(p => p.StartDate)
                   .ProjectTo<EventForListVm>(_mapper.ConfigurationProvider);


            //necessary for pagination
            var eventsToShow = events.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            var count = events.Count();

            UpdateEventUserIsEnrolled(eventsToShow, userIsEnroled);

            var ceil = Math.Ceiling(count / (double)pageSize);

            return new ListEventForListVm()
            {
                Events = eventsToShow,
                Count = events.Count(),
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString
            };
        }

        public ListEventForListVm GetUserEventsForList(int pageSize, int pageNo, string searchString, string userName)
        {
            pageSize = pageSize > 0 ? pageSize : 10;
            pageNo = pageNo > 0 ? pageNo : 1;
            searchString = searchString ?? string.Empty;

            var events = (from e in _eventRepository.GetAllActiveEvents()
                   join ee in _eventRepository.GetAllEnrollments() on e.Id equals ee.EventId
                   where
                   ee.IdentityUser.UserName == userName
                   && e.Name.Contains(searchString)
                   && e.EndDate >= DateOnly.FromDateTime(DateTime.Now)
                   && e.StatusId != 0
                   select e)
                   .OrderBy(p => p.StartDate)
                   .ProjectTo<EventForListVm>(_mapper.ConfigurationProvider).Select(c => c.AsEnroled());


            //necessary for pagination
            var eventsToShow = events.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            var count = events.Count();

            var ceil = Math.Ceiling(count / (double)pageSize);

            return new ListEventForListVm()
            {
                Events = eventsToShow,
                Count = events.Count(),
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString
            };
        }

        private void UpdateEventUserIsEnrolled(List<EventForListVm> eventsToShow, string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                foreach(var e in eventsToShow)
                {
                    var enrollments = _eventRepository.GetAllEnrollments(e.Id);

                    e.CurrentUserIsEnrolled = enrollments.Any(enr => enr.IdentityUser.UserName == userName);
                }
            }
        }

        public EventDetailsVm GetEventDetails(int id)
        {
            var botafeEvent = _eventRepository.GetEvent(id);
            var result = _mapper.Map<EventDetailsVm>(botafeEvent);
            return result;
        }

        public EventEditVm GetEventForEdit(int id)
        {
            var botafeEvent = _eventRepository.GetEvent(id);
            var result = _mapper.Map<EventEditVm>(botafeEvent);
            return result;
        }

        public void UpdateEvent(EventEditVm model)
        {
            var toUpdate = _mapper.Map<Event>(model);
            _eventRepository.UpdateEvent(toUpdate);
        }

        public int Enroll(int eventId)
        {
            var userId =  _userManager.GetUserId(_httpContext.HttpContext.User);
            var enrollment = new EventEnrollment() { EventId = eventId, IdentityUserId = userId };
            return _eventRepository.AddEnrollment(enrollment);
        }
    }
}
