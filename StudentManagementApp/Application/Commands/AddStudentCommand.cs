using StudentManagementApp.Application.Commands;
using StudentManagementApp.Application.Services;
using StudentManagementApp.Core.Models;
using StudentManagementApp.Application.Validators;

public class AddStudentCommand : ICommand
{
    private readonly StudentService _studentService;

    public AddStudentCommand(StudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task ExecuteAsync(string args)
    {
        Console.Write("Enter Student ID (7 digits): ");
        if (!InputValidator.ValidateStudentId(Console.ReadLine()!, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name is required.");
            return;
        }

        Console.Write("Enter Surname: ");
        string surname = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(surname))
        {
            Console.WriteLine("Surname is required.");
            return;
        }

        Console.Write("Enter Age: ");
        if (!InputValidator.ValidateAge(Console.ReadLine()!, out int age))
        {
            Console.WriteLine("Invalid Age.");
            return;
        }

        Console.Write("Enter Curriculum: ");
        string curriculum = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(curriculum))
        {
            Console.WriteLine("Curriculum is required.");
            return;
        }

        var student = new Student { Id = id, Name = name, Surname = surname, Age = age, Curriculum = curriculum };
        await _studentService.AddStudentAsync(student);

        Console.WriteLine("Student added successfully.");
    }
}

