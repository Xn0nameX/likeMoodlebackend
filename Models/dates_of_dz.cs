using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class dates_of_dz
    {
        [Key]
        public int DatezdId { get; set; }

        [Required]
        public DateTime DzDate { get; set; }

        [ForeignKey("Homework")]
        public int HomeworkId { get; set; }
        public homework homeworks { get; set; }
    }
}
