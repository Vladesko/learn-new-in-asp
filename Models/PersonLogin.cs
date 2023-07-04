using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteWork.Models
{
    public class PersonLogin
    {
        [Required]
        [MaxLength(50), MinLength(2)]
        public string LogIn { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
