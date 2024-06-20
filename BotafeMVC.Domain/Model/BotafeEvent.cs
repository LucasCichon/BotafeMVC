using BotafeMVC.Domain.Common;
using System.ComponentModel;

namespace BotafeMVC.Domain.Model
{
    public class Event : AuditableEntity
    {
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int TotalNumberOfPlaces { get; set; }
        public ICollection<EventEnrollment> Enrollments { get; set; }
    }
}
