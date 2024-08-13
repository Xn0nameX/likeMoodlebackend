using System.ComponentModel.DataAnnotations;

namespace Kyzmav2.Models
{
    public class InsertCommentTeacherModel
    {
        [StringLength(300)]
        public string TeacherComment { get; set; }

        [Required]
        public int HomeworkId { get; set; }
    }
}
