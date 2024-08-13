using System;
using System.ComponentModel.DataAnnotations;

namespace Kyzmav2.Models
{
    public class InsertUserModel
    {
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

        [Required]
        public int RoleId { get; set; }

        public int? GroupId { get; set; }
    }

    public class UserAuthenticationModel
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
