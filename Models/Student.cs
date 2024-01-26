using SkolaDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDB.Models
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonalNumber { get; set; }
        [Required]
        public string Class { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
