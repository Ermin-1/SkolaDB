using SkolaDB.Models.Data;
using SkolaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDB
{
    internal class Methods
    {
        // Metod för att hämta elever
        public void GetStudents()
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                Console.WriteLine("Vill du se eleverna sorterade på för eller efternamn? Tryck f eller e");
                char choice = Console.ReadKey().KeyChar;

                IOrderedQueryable<Student> students;
                if (choice == 'f')
                {
                    students = context.Students.OrderBy(s => s.FirstName);
                }
                else
                {
                    students = context.Students.OrderBy(s => s.LastName);
                }

                Console.WriteLine("\nVill du ha stigande tryck 1 eller fallande tryck 2 sortering?");
                int sort;
                if (int.TryParse(Console.ReadLine(), out sort) && (sort == 2))
                {
                    students = students.OrderByDescending(s => s.FirstName);
                }

                foreach (Student student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
            }
        }


        // Metod för att hämta elever i en viss klass
        public void GetStudentsInClass(string selectedClass)
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                Console.WriteLine("Vill du se eleverna sorterade på för eller efternamn? f eller e");
                char choice = Console.ReadKey().KeyChar;

                IOrderedQueryable<Student> students;
                if (choice == 'f')
                {
                    students = context.Students.Where(s => s.Class == selectedClass).OrderBy(s => s.FirstName);
                }
                else
                {
                    students = context.Students.Where(s => s.Class == selectedClass).OrderBy(s => s.LastName);
                }

                Console.WriteLine("\nVill du ha stigande tryck 1 eller fallande tryck 2 sortering?");
                int sortOrder;
                if (int.TryParse(Console.ReadLine(), out sortOrder))
                {
                    if (sortOrder == 1)
                    {
                        students = students.OrderBy(s => s.FirstName);
                    }
                    else
                    {
                        students = students.OrderBy(s => s.LastName);
                    }
                }

                foreach (Student student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
            }
        }

        public void GetStaff()
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                IQueryable<Teacher> teachersQuery = context.Teachers.OrderBy(t => t.TeacherLastName);
                List<Teacher> teachers = teachersQuery.ToList();

                foreach (Teacher teacher in teachers)
                {
                    Console.WriteLine($"{teacher.TeacherId} {teacher.TeacherName} {teacher.TeacherLastName} {teacher.TeacherEmployment}");
                }
            }
        }
    


        // Metod för att lägga till ny lärare
        public void AddNewTeacher(string teacherName, string teacherLastName, string teacherEmployment)
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                Teacher newTeacher = new Teacher
                {
                    TeacherName = teacherName,
                    TeacherLastName = teacherLastName,
                    TeacherEmployment = teacherEmployment
                };

                context.Teachers.Add(newTeacher);
                context.SaveChanges();

                Console.WriteLine("Ny personal har lagts till i databasen.");
            }
        }

        public void GetTotalTeachersCount()
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                int totalTeachersCount = context.Teachers.Count(t => t.TeacherEmployment == "Teacher");
                Console.WriteLine($"Totalt antal lärare på skolan: {totalTeachersCount}");
            }
        }

        public void GetTotalAdministratorsCount()
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                int totalAdministratorsCount = context.Teachers.Count(t => t.TeacherEmployment == "Administrator");
                Console.WriteLine($"Totalt antal administratörer på skolan: {totalAdministratorsCount}");
            }
        }

        public void GetAllStudentInformation()
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                var students = context.Students.ToList();

                Console.WriteLine("Information om alla elever:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.StudentId}, Förnamn: {student.FirstName}, Efternamn: {student.LastName}, Klass: {student.Class}");
                }
            }
        }

        public void GetAllCoursesInformation()
        {
            using (SkolaDbContext context = new SkolaDbContext())
            {
                var courses = context.Courses.ToList();

                Console.WriteLine("Information om alla kurser:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"ID: {course.CourseId}, Kursnamn: {course.CourseName}");
                }
            }
        }
    }
}

