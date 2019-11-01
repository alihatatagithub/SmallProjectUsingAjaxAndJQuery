using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Day3_3.MyValidations;
using System.Web.Mvc;

namespace Day3_3.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(25,MinimumLength =5,ErrorMessage =" length between 5 and 25 character")]
        [Display(Name ="Full Name")]
        public string Name { get; set; }
        [Range(20,30,ErrorMessage ="age must be between 20 and 30")]
        public int Age { get; set; }


        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+@[A-Za-z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [StringLength(15,MinimumLength =3)]
        [PasswordValidation(ErrorMessage ="Password not valid againest to custome validation")]
        public string Password { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string CPassword { get; set; }


        [Required]
        [Remote("CheckUserName","student",AdditionalFields ="Id")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }



        [ForeignKey("Department")]
        public int? DeptNo { get; set; }





        public virtual Department Department { get; set; }
    }
}