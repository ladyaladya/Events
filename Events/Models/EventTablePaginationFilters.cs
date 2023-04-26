namespace Events.UI.Models
{
    public class EventTablePaginationFilters
    {
        public EventTableFilters PreviousPageFilter { get; set; }
        public EventTableFilters NextPageFilter { get; set; }
        public List<EventTableFilters> PageNumbersFilterArray { get; set; } = new List<EventTableFilters>();
    }
}
