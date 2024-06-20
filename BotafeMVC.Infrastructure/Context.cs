using BotafeMVC.Domain.Common;
using BotafeMVC.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContext;

        public DbSet<Event> Events { get; set; }
        public DbSet<EventEnrollment> EventEnrollments { get; set; }
        public Context(DbContextOptions options, IHttpContextAccessor _httpContext) : base(options)
        {
            this._httpContext = _httpContext;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _httpContext.HttpContext?.User?.Identity?.Name ?? string.Empty;
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _httpContext.HttpContext?.User?.Identity?.Name ?? string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = _httpContext.HttpContext?.User?.Identity?.Name ?? string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;
                        entry.Entity.InactivatedBy = _httpContext.HttpContext?.User?.Identity?.Name ?? string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
