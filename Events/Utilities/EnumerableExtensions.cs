using Events.Core.Models;
using Events.UI.Helpers;
using Events.UI.Models;

namespace Events.UI.Utilities
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Event> SortByColumn(this IEnumerable<Event> events, EventTableColumn column, FakeBoolEnum orderByDesc)
        {
            bool isOrderByDesc = orderByDesc == FakeBoolEnum.y;
            switch (column)
            {
                case EventTableColumn.id:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Id) : events.OrderBy(e => e.Id);
                case EventTableColumn.category:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Category) : events.OrderBy(e => e.Category);
                case EventTableColumn.name:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Name) : events.OrderBy(e => e.Name);
                case EventTableColumn.description:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Description) : events.OrderBy(e => e.Description);
                case EventTableColumn.place:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Place) : events.OrderBy(e => e.Place);
                case EventTableColumn.time:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Time) : events.OrderBy(e => e.Time);
                case EventTableColumn.image:
                    return isOrderByDesc ? events.OrderByDescending(e => e.ImagePath) : events.OrderBy(e => e.ImagePath);
                case EventTableColumn.additional_info:
                    return isOrderByDesc ? events.OrderByDescending(e => e.AdditionalInfo) : events.OrderBy(e => e.AdditionalInfo);
                default:
                    return isOrderByDesc ? events.OrderByDescending(e => e.Id) : events.OrderBy(e => e.Id);
            }
        }

        public static IEnumerable<Event> GetEventsFromPage(this IEnumerable<Event> events, int page)
        {
            int eventsToSkip = (page - 1) * Constants.EventsPerPage;
            return events.Skip(eventsToSkip).Take(Constants.EventsPerPage);
        }

        public static EventTableFilters GetEventTableFilters(this IQueryCollection queryCollection)
        {
            var pageStr = queryCollection["page"].SingleOrDefault();
            var orderByColumnStr = queryCollection["order_by_column"].SingleOrDefault();
            var orderByDescStr = queryCollection["order_by_desc"].SingleOrDefault();

            var isPageValidInteger = int.TryParse(pageStr, out int page);
            var isOrderByColumnValidEnum = Enum.TryParse(orderByColumnStr, out EventTableColumn orderByColumn);
            var isOrderByDescValidInteger = Enum.TryParse(orderByDescStr, out FakeBoolEnum orderByDesc);

            var tableFilters = new EventTableFilters()
            {
                page = isPageValidInteger ? page : Constants.DefaultPage,
                order_by_column = isOrderByColumnValidEnum ? orderByColumn : Constants.OrderByColumn,
                order_by_desc = isOrderByDescValidInteger ? orderByDesc : Constants.IsOrderedByDesc,
            };

            return tableFilters;
        }
    }
}

