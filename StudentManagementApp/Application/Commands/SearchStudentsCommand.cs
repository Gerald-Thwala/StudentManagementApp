using StudentManagementApp.Application.Services;
using StudentManagementApp.Core.Models;

namespace StudentManagementApp.Application.Commands;

public class SearchStudentsCommand : ICommand
{
    private readonly StudentService _studentService;

    public SearchStudentsCommand(StudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task ExecuteAsync(string[] args)
    {
        Console.Write("Enter search criteria (leave blank to list all students): ");
        string searchCriteria = Console.ReadLine()!;

        IEnumerable<Student> results;

        // Return all students
        if (string.IsNullOrWhiteSpace(searchCriteria))
        {
            results = _studentService.SearchStudents(_ => true); 
        }
        else
        {
            results = _studentService.SearchStudents(student =>
                student.Name.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase) ||
                student.Surname.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase) ||
                student.Curriculum.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
        }

        if (!results.Any())
        {
            Console.WriteLine("No students found matching the criteria.");
            return;
        }

        Console.WriteLine("Search Results:");
        Console.WriteLine("ID       | Name           | Surname        | Age | Curriculum");
        Console.WriteLine("---------|----------------|----------------|-----|-----------");

        foreach (var student in results)
        {
            Console.WriteLine($"{student.Id,-9} | {student.Name,-14} | {student.Surname,-14} | {student.Age,-3} | {student.Curriculum}");
        }
    }
}

