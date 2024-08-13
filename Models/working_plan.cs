using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class working_plan
    {
        [Key]
        public int PlanId { get; set; }

        [Required]
        [StringLength(50)]
        public string PlanTitle { get; set; }

        [StringLength(150)]
        public string PlanDescription { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public userss userss { get; set; }

        [StringLength(300)]
        public string WayOfFile { get; set; }

        public ICollection<homework> homeworks { get; set; }
    }
}
