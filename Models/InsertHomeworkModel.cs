using System;
using System.ComponentModel.DataAnnotations;

namespace Kyzmav2.Models
{
    public class InsertHomeworkModel
    {
        [Required]
        public DateTime DeadlineDate { get; set; }

        [Required]
        [StringLength(300)]
        public string HomeworkDescription { get; set; }

        [Required]
        public int PlanId { get; set; }

        [StringLength(400)]
        public string WayHomework { get; set; }

        [StringLength(20)]
        public string StatusHomework { get; set; }
    }
}