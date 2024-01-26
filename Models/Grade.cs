using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDB.Models
{
    internal class Grade
    {
        [Key]
        public int GradeID { get; set; }

        [Required]
        public string StudentGrade { get; set; }

        [Required]
        public DateTime GradeDate { get; set; }

        [Required]
        public int TeacherID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int CourseID { get; set; }   



        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
