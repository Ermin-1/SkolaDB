using SkolaDB.Models.Data;
using SkolaDB.Models;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Välj en uppgift:");
            Console.WriteLine("1. Hämta alla elever");
            Console.WriteLine("2. Hämta alla elever i en viss klass");
            Console.WriteLine("3. Lägga till ny lärare");
            Console.WriteLine("0. Avsluta");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // New line for better formatting

            switch (choice)
            {
                case '1':
                    GetStudents();
                    break;

                case '2':
                    GetStudentsInClass();
                    break;

                case '3':
                    AddNewTeacher();
                    break;

                case '0':
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear(); // Clear console for the next iteration
        }
    }

    static void GetStudents()
    {
        using (SkolaDbContext context = new SkolaDbContext())
        {
            Console.WriteLine("Vill du se eleverna sorterade på för- eller efternamn? (f/e)");
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

            Console.WriteLine("\nVill du ha stigande (1) eller fallande (2) sortering?");
            int sortOrder;
            if (int.TryParse(Console.ReadLine(), out sortOrder) && (sortOrder == 2))
            {
                students = students.OrderByDescending(s => s.FirstName);
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }

    static void GetStudentsInClass()
    {
        using (SkolaDbContext context = new SkolaDbContext())
        {
            Console.WriteLine("Välj en klass:");

            IQueryable<string> classes = context.Students.Select(s => s.Class).Distinct();

            foreach (var className in classes)
            {
                Console.WriteLine(className);
            }

            Console.Write("Ange klassen du vill se eleverna för: ");
            string selectedClass = Console.ReadLine();

            Console.WriteLine("Vill du se eleverna sorterade på för- eller efternamn? (f/e)");
            char choice = Console.ReadKey().KeyChar;

            IOrderedQueryable<Student> students;
            if (choice == 'f')
            {
                students = context.Students
                    .Where(s => s.Class == selectedClass)
                    .OrderBy(s => s.FirstName);
            }
            else
            {
                students = context.Students
                    .Where(s => s.Class == selectedClass)
                    .OrderBy(s => s.LastName);
            }

            Console.WriteLine("\nVill du ha stigande (1) eller fallande (2) sortering?");
            int sortOrder;
            if (int.TryParse(Console.ReadLine(), out sortOrder) && (sortOrder == 2))
            {
                students = students.OrderByDescending(s => s.FirstName);
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }


    static void AddNewTeacher()
    {
        using (SkolaDbContext context = new SkolaDbContext())
        {
            Console.WriteLine("Ange uppgifter för den nya läraren:");
            Console.Write("Förnamn: ");
            string teacherName = Console.ReadLine();

            Console.Write("Efternamn: ");
            string teacherLastName = Console.ReadLine();

            Console.Write("Anställning: ");
            string teacherEmployment = Console.ReadLine();

            Teacher newTeacher = new Teacher
            {
                TeacherName = teacherName,
                TeacherLastName = teacherLastName,
                TeacherEmployment = teacherEmployment
            };

            context.Teachers.Add(newTeacher);
            context.SaveChanges();

            Console.WriteLine("Ny lärare har lagts till i databasen.");
        }
    }
}
