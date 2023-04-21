using Events.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.Core.Data.Context.Abstract
{
    public interface IEventsDbContext
    {
        public DbSet<Event>? Events { get; set; }
    }
}
