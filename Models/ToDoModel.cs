using System.ComponentModel.DataAnnotations;

namespace ServersideProjektH5.Models
{
    public class ToDoModel
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
