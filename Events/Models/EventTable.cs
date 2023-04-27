using Events.Core.Models;
using Events.UI.Helpers;
using Events.UI.Models;
using Events.UI.Utilities;

namespace Events.Models
{
    public class EventTable
    {
        public IEnumerable<Event> Events { get; }
        public EventTableFilters TableFilters { get; }
        public EventTablePagination Pagination { get; }
        public EventTablePaginationFilters PaginationTableFilters { get; }
        public IEnumerable<EventTableFilters> ColumnTableFilters { get; }
        public int AllEventsCount { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }
        public int PageIndex { get; }
        public int PageCount { get; }

        public EventTable(IEnumerable<Event> events) : this(events, new EventTableFilters()) { }

        public EventTable(IEnumerable<Event> events, EventTableFilters filters)
        {
            AllEventsCount = events.ToList().Count;
            PageCount = GetPageCount();
            TableFilters = filters;
            PageIndex = GetPageIndex();
            StartIndex = GetStartIndex();
            EndIndex = GetEndIndex();
            Pagination = GetPagination();
            PaginationTableFilters = GetPaginationTableFilters();
            ColumnTableFilters = GetColumnTableFilters();
            Events = GetFilteredEvents(events);
        }

        private int GetPageIndex()
        {
            if (TableFilters.page > PageCount || TableFilters.page < 1)
            {
                return Constants.DefaultPage;
            }
            return TableFilters.page;
        }

        private int GetStartIndex()
        {
            var eventsToSkip = GetEventsToSkip(PageIndex);
            return eventsToSkip + 1;
        }

        private int GetEndIndex()
        {
            var eventsToSkip = GetEventsToSkip(PageIndex);
            var endIndex = eventsToSkip + Constants.EventsPerPage;
            return endIndex > AllEventsCount ? AllEventsCount : endIndex;
        }

        private int GetPageCount()
        {
            var pageCount = AllEventsCount / Constants.EventsPerPage;
            return pageCount % Constants.EventsPerPage == 0 ? pageCount : pageCount + 1;
        }

        private int GetEventsToSkip(int page)
        {
            return (page - 1) * Constants.EventsPerPage;
        }

        private IEnumerable<Event> GetFilteredEvents(IEnumerable<Event> events)
        {
            var sortedEvents = events.SortByColumn(TableFilters.order_by_column, TableFilters.order_by_desc);
            var eventsByPage = sortedEvents.GetEventsFromPage(PageIndex);
            return eventsByPage;
        }

        private EventTablePagination GetPagination()
        {
            var pagination = new EventTablePagination()
            {
                PreviousPage = PageIndex - 1,
                NextPage = PageIndex + 1,
            };

            for (int i = 1; i <= PageCount; i++)
            {
                pagination.PageNumbersArray.Add(i);
            }

            return pagination;
        }

        private EventTablePaginationFilters GetPaginationTableFilters()
        {
            var tableFilters = new EventTablePaginationFilters()
            {
                PreviousPageFilter = new EventTableFilters()
                {
                    page = Pagination.PreviousPage,
                    order_by_column = TableFilters.order_by_column,
                    order_by_desc = TableFilters.order_by_desc,
                },
                NextPageFilter = new EventTableFilters()
                {
                    page = Pagination.NextPage,
                    order_by_column = TableFilters.order_by_column,
                    order_by_desc = TableFilters.order_by_desc,
                },
            };

            foreach (var pageIndex in Pagination.PageNumbersArray)
            {
                tableFilters.PageNumbersFilterArray.Add(new EventTableFilters()
                {
                    page = pageIndex,
                    order_by_column = TableFilters.order_by_column,
                    order_by_desc = TableFilters.order_by_desc,
                });
            }

            return tableFilters;
        }

        private IEnumerable<EventTableFilters> GetColumnTableFilters()
        {
            var tableFilters = new List<EventTableFilters>();

            foreach (var column in Enum.GetValues<EventTableColumn>().Cast<EventTableColumn>())
            {
                tableFilters.Add(new EventTableFilters()
                {
                    order_by_column = column,
                    order_by_desc = TableFilters.order_by_column == column ? TableFilters.order_by_desc.Toggle() : Constants.IsOrderedByDesc,
                    page = Constants.DefaultPage,
                });
            }

            return tableFilters;
        }
    }
}
