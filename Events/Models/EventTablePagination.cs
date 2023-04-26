namespace Events.UI.Models
{
    public class EventTablePagination
    {
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public List<int> PageNumbersArray { get; set; } = new List<int>();
    }
}