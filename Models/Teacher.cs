using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDB.Models
{
    internal class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherLastName { get; set; }
        [Required]
        public string TeacherEmployment { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
