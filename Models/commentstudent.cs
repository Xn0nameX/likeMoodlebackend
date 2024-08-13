using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class commentstudent
    {
        [Key]
        public int CommentSId { get; set; }

        [StringLength(300)]
        public string StudentComment { get; set; }

        [ForeignKey("Homework")]
        public int HomeworkId { get; set; }
        public homework homeworks { get; set; }
    }
}
