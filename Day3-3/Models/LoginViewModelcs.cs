using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day3_3.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [MyValidations.PasswordValidation(ErrorMessage = "Password not valid againest to custome validation")]
        public string Password { get; set; }
    }
}