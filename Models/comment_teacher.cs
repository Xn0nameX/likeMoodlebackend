using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class comment_teacher
    {
        [Key]
        public int CommentTId { get; set; }

        [StringLength(300)]
        public string TeacherComment { get; set; }

        [ForeignKey("Homework")]
        public int HomeworkId { get; set; }
        public homework homeworks { get; set; }
    }
}
