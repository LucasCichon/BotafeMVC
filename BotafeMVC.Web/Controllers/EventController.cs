using BotafeMVC.Application.Interfaces;
using BotafeMVC.Application.ViewModels.Event;
using BotafeMVC.Common;
using BotafeMVC.Web.Filters;
using BotafeMVC.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotafeMVC.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<EventController> _logger;
        private const int pageSize = 5;
        private const int pageNo = 1;
        private const string searchString = "";

        public EventController(IEventService eventService, ILogger<EventController> logger, IHttpContextAccessor httpContext)
        {
            _eventService = eventService;
            _httpContext = httpContext;
            _logger = logger;
            
        }
        [CheckPermissions(ServiceConstants.Claims.ViewEvents)]
        public IActionResult Index()
        {
            var name = _httpContext.HttpContext?.User.Identity?.Name;
            var model = _eventService.GetAllEventsForList(pageSize, pageNo, searchString, name);
            return View(model);
        }

        public IActionResult My()
        {
            var userName = _httpContext.HttpContext?.User.Identity?.Name;
            var model = _eventService.GetUserEventsForList(pageSize, pageNo, searchString, userName);
            return View("Index", model);
        }

        [HttpPost]
        [CheckPermissions(ServiceConstants.Claims.ViewEvents)]
        public IActionResult Index(int pageSize, int pageNo, string searchString)
        {
            var model = _eventService.GetAllEventsForList(pageSize, pageNo, searchString);
            return View(model);
        }

        [HttpGet]
        [CheckPermissions(ServiceConstants.Claims.AddNewEvent)]
        public IActionResult AddEvent()
        {
            return View(new NewEventVm());
        }

        [HttpPost]
        [CheckPermissions(ServiceConstants.Claims.AddNewEvent)]
        [ValidateAntiForgeryToken] //pozwala sprawdzić czy nikt się nie podszywa pod nasze widoki
        public IActionResult AddEvent(NewEventVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _eventService.AddEvent(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult EventDetails(int Id)
        {
            var model = _eventService.GetEventDetails(Id);
            return View(model);
        }

        [HttpGet]
        [CheckPermissions(ServiceConstants.Claims.EditEvent)]
        public IActionResult Edit(int Id)
        {   
            var model = _eventService.GetEventForEdit(Id);
            return View(model);
        }

        [HttpPost]
        [CheckPermissions(ServiceConstants.Claims.EditEvent)]
        public IActionResult Edit(EventEditVm model)
        {
            if (ModelState.IsValid)
            {
                _eventService.UpdateEvent(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [CheckPermissions(ServiceConstants.Claims.EnrollToEvent)]
        public IActionResult Enroll(int id)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.ToString())
            {
                var model = _eventService.GetEventDetails(id);
                return View(model);
            }
            else
            {
                var enrolled = _eventService.Enroll(id);

                if (enrolled.IsLeft)
                {
                    return View("Error", new ErrorViewModel() {Message = enrolled.Left.Message });
                }

                return RedirectToAction("Index");
            }
        }

        [CheckPermissions(ServiceConstants.Claims.DeleteEvent)]
        public IActionResult Delete(int id)
        {
            if(HttpContext.Request.Method == HttpMethod.Get.ToString())
            {
                var model = _eventService.GetEventDetails(id);
                return View(model);
            }
            else
            {
                _eventService.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
