using Events.Core.Models;

namespace Events.Models
{
    public class EventsTable
    {
        public EventsTable(IEnumerable<Event> events)
        {
            Events = events;
        }
        public IEnumerable<Event> Events { get; set; }
    }
}
