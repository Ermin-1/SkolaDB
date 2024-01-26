using SkolaDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDB.Models
{
    internal class Course
    {
        [Key] 
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}

