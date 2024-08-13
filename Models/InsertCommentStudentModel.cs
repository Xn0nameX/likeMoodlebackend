using System.ComponentModel.DataAnnotations;

namespace Kyzmav2.Models
{
    public class InsertCommentStudentModel
    {
        [StringLength(300)]
        public string StudentComment { get; set; }

        [Required]
        public int HomeworkId { get; set; }
    }
}
