using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class notes
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        [StringLength(150)]
        public string NoteText { get; set; }

        [Required]
        public DateTime NoteDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public userss userss { get; set; }

        [ForeignKey("NoteType")]
        public int NotesTypeId { get; set; }
        public notetype notetypes { get; set; }
    }
}
