using System;
using System.ComponentModel.DataAnnotations;

namespace Kyzmav2.Models
{
    public class InsertWorkingPlanModel
    {
        [Required]
        [StringLength(50)]
        public string PlanTitle { get; set; }

        [StringLength(150)]
        public string PlanDescription { get; set; }

        [Required]
        public int UserId { get; set; }

        [StringLength(300)]
        public string WayOfFile { get; set; }
    }
}
