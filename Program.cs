using SkolaDB.Models.Data;
using SkolaDB.Models;
using System;
using System.Linq;
using SkolaDB;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Methods databaseManager = new Methods();

        while (true)
        {
            menu.ShowMenu();
            string choice = menu.GetUserChoice();

            switch (choice)
            {
                case "1":
                    databaseManager.GetStudents();
                    break;

                case "2":
                    Console.WriteLine("Välj en klass:");
                    string selectedClass = Console.ReadLine();
                    databaseManager.GetStudentsInClass(selectedClass);
                    break;

                case "3":
                    Console.WriteLine("Ange uppgifter för den nya personalen:");
                    Console.Write("Förnamn: ");
                    string teacherName = Console.ReadLine();

                    Console.Write("Efternamn: ");
                    string teacherLastName = Console.ReadLine();

                    Console.Write("Anställningstyp: ");
                    string teacherEmployment = Console.ReadLine();

                    databaseManager.AddNewTeacher(teacherName, teacherLastName, teacherEmployment);
                    break;



                case "4":
                    databaseManager.GetTotalTeachersCount();
                    break;
                case "5":
                    databaseManager.GetTotalAdministratorsCount();
                    break;
                case "6":
                    databaseManager.GetAllStudentInformation();
                    break;
                case "7":
                    databaseManager.GetAllCoursesInformation();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
