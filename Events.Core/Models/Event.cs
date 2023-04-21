using System.ComponentModel.DataAnnotations;

namespace Events.Core.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public string? Place { get; set; }
        public DateTime? Time { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
