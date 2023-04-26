namespace Events.UI.Models
{
    public struct EventTableFilters
    {
        public EventTableColumn order_by_column { get; set; }
        public int page { get; set; }
        public int order_by_desc
        {
            get
            {
                return _order_by_desc ? 1 : 0;
            }
            set
            {
                _order_by_desc = value > 0 ? true : false;
            }
        }

        private bool _order_by_desc;
    }
}
