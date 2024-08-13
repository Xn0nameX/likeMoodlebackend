using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class notetype
    {
        [Key]
        public int NotesTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string NoteTypeName { get; set; }

        public ICollection<notes> notes { get; set; }
    }
}
