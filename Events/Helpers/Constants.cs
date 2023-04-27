using Events.UI.Models;

namespace Events.UI.Helpers
{
    public static class Constants
    {
        public const int EventsPerPage = 5;
        public const int DefaultPage = 1;
        public const EventTableColumn OrderByColumn = EventTableColumn.id;
        public const FakeBoolEnum IsOrderedByDesc = FakeBoolEnum.n;
    }
}
