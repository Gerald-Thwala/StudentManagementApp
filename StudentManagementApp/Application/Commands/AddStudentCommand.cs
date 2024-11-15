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

    public async Task ExecuteAsync(string[] args)
    {
        Console.Write("Enter Student ID (7 digits): ");
        if (!InputValidator.ValidateStudentId(Console.ReadLine()!, out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter Surname: ");
        string surname = Console.ReadLine()!;

        Console.Write("Enter Age: ");
        if (!InputValidator.ValidateAge(Console.ReadLine()!, out int age))
        {
            Console.WriteLine("Invalid Age.");
            return;
        }

        Console.Write("Enter Curriculum: ");
        string curriculum = Console.ReadLine()!;

        var student = new Student { Id = id, Name = name, Surname = surname, Age = age, Curriculum = curriculum };
        await _studentService.AddStudentAsync(student);

        Console.WriteLine("Student added successfully.");
    }
}

