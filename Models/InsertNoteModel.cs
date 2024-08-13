using System;
using System.ComponentModel.DataAnnotations;

namespace Kyzmav2.Models
{
    public class InsertNoteModel
    {
        [Required]
        [StringLength(150)]
        public string NoteText { get; set; }

        [Required]
        public DateTime NoteDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int NotesTypeId { get; set; }
    }
}
