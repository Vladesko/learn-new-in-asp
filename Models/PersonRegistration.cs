using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWork.Models
{
    public class PersonRegistration
    {
        [Required]
        [MaxLength(40), MinLength(2)]
        public string LogIn { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(40), MinLength(2)]
        public string PersonFullName { get; set; }
        [Required]
        [MaxLength(25), MinLength(4)]
        public string UserName { get; set; }
    }
}
