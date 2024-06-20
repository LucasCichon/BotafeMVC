using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Domain.Model
{
    public class EventEnrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Microsoft.AspNetCore.Identity.IdentityUser IdentityUser { get; set; }
        public string IdentityUserId { get; set; }
        public Event Event{ get; set; }
        public int EventId { get; set; }
    }
}
