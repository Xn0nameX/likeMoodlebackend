using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kyzmav2.Models
{
    public class userss
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }

        [StringLength(30)]
        public string Patronymic { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public role roles { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public groups groups { get; set; }

        public ICollection<notes> notes { get; set; }
        public ICollection<working_plan> working_plans { get; set; }
    }
}
