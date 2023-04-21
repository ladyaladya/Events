using Events.Core.Data.Context.Abstract;
using Events.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.Core.Data.Context.Concrete
{
    public class EventsDbContext : DbContext, IEventsDbContext
    {
        private readonly IConfiguration _configuration;
        public EventsDbContext(DbContextOptions<EventsDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyDbConnection"));
        }

        public DbSet<Event>? Events { get; set; }
    }
}