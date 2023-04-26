using Events.Core.Data.Context.Concrete;
using Events.Core.Models;
using Events.Providers.Abstract;

namespace Events.UI.Providers.Concrete
{
    public class EventProvider : IEventProvider
    {
        private readonly EventsDbContext _context;
        public EventProvider(EventsDbContext context)
        {
            _context = context;
        }

        public bool Create(Event @event)
        {
            _context.Events?.Add(@event);
            _context.SaveChanges();

            return IsEventExist(@event);
        }

        public bool Delete(int id)
        {
            var @event = _context.Events?.Find(id);

            if (@event == null)
            {
                return false;
            }

            _context.Events?.Remove(@event);
            _context.SaveChanges();

            return !IsEventExist(@event);
        }

        public Event? GetEventById(int id)
        {
            return _context.Events?.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Event> GetEvents()
        {
            var events = _context.Events;
            if (events == null) { return Enumerable.Empty<Event>(); }
            else return events;
        }

        public bool Update(Event @event)
        {
            _context.Events?.Update(@event);
            _context.SaveChanges();

            return IsEventExist(@event);
        }

        private bool IsEventExist(Event @event)
        {
            if (_context.Events != null && _context.Events.Contains(@event))
            {
                return true;
            }

            return false;
        }
    }
}
