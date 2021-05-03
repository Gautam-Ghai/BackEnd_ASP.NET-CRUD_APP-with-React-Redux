using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DbStudent
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(20)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Gender { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Program { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Courses { get; set; }


    }
}
