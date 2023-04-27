using Events.UI.Helpers;

namespace Events.UI.Models
{
    public struct EventTableFilters
    {
        public EventTableColumn order_by_column { get; set; } = Constants.OrderByColumn;
        public int page { get; set; } = Constants.DefaultPage;
        public FakeBoolEnum order_by_desc { get; set; } = Constants.IsOrderedByDesc;
        public EventTableFilters() {
            if (page < Constants.DefaultPage)
            {
                page = Constants.DefaultPage;
            }
        }
    }
}
