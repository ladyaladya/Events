﻿using Events.Core.Models;

namespace Events.Providers.Abstract
{
    public interface IEventProvider
    {
        IEnumerable<Event> GetEvents();
        Event? GetEventById(int id);
        bool Update(Event @event);
        bool Create(Event @event);
        bool Delete(int id);
    }
}
