using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Day3_3.Models
{
    public class ITI38:DbContext    {
        public ITI38():base("xyz")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}