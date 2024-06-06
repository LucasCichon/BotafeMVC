using System.ComponentModel;

namespace BotafeMVC.Web.Models
{
    public class BotafeEvent
    {
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int PlacesAvailable { get; set; }
        public int TotalNumberOfPlaces { get; set; }

        //// jeżeli nie będzie '?', to usuwając Ownera, automatycznie wszyskie jego Eventy zostaną usunięte...
        //public int? EventOwnerId { get; set; }
        //public EventOwner EventOwner { get; set; }
        //public List<Enrollment> Enrollments { get; set; } = new();
    }
}
