using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class groups
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [StringLength(30)]
        public string NameGroup { get; set; }

        public ICollection<userss> userss { get; set; }
    }
}
