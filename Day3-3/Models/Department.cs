using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace Day3_3.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptNo { get; set; }

        public string DeptName { get; set; }

        public int MaxCapacity { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}