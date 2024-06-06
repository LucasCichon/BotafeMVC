using BotafeMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BotafeMVC.Web.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Events()
        {
            ViewData["Test"] = "ViewDataTest";

            List<BotafeEvent> events = new List<BotafeEvent>();
            events.Add(new BotafeEvent() { Id = 1, Name = "Ławka", StartDate = new DateOnly(2024, 7, 13), EndDate = new DateOnly(2024, 7, 17), PlacesAvailable = 15, TotalNumberOfPlaces = 50 });
            events.Add(new BotafeEvent() { Id = 2, Name = "Lectio Divina", StartDate = new DateOnly(2024, 8, 2), EndDate = new DateOnly(2024, 9, 2), PlacesAvailable = 2, TotalNumberOfPlaces = 8 });
            events.Add(new BotafeEvent() { Id = 3, Name = "Akrobatyka Małżeńska", StartDate = new DateOnly(2024, 10, 12), EndDate = new DateOnly(2024, 10, 25), PlacesAvailable = 7, TotalNumberOfPlaces = 30 });

            return View(events);
        }
    }
}
