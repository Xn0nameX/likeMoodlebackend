using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public DateTime DeadlineDate { get; set; }

        [Required]
        [StringLength(300)]
        public string HomeworkDescription { get; set; }

        [ForeignKey("WorkingPlan")]
        public int PlanId { get; set; }
        public working_plan working_plans { get; set; }

        [StringLength(400)]
        public string WayHomework { get; set; }

        [StringLength(20)]
        public string StatusHomework { get; set; }

        public ICollection<dates_of_dz> dates_of_dzs { get; set; }
        public ICollection<comment_teacher> comment_teachers { get; set; }
        public ICollection<commentstudent> commentstudents { get; set; }
    }
}
