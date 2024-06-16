using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    [Table("task")]
    public class Tasks
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }

    }
}
