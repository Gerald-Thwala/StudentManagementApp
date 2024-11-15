using StudentManagementApp.Application.Services;
using StudentManagementApp.Application.Validators;

namespace StudentManagementApp.Application.Commands;

public class DeleteStudentCommand : ICommand
{
    private readonly StudentService _studentService;

    public DeleteStudentCommand(StudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task ExecuteAsync(string args)
    {


        if (args.Length == 0)
        {
            Console.WriteLine("Please specify--id for edit action.");
            return;
        }
        
        if (!InputValidator.ValidateStudentId(args, out int id))
        {
            Console.WriteLine("Invalid Student ID.");
            return;
        }

        var existingStudent = await _studentService.GetStudentByIdAsync(id);
        if (existingStudent == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write($"Are you sure you want to delete {existingStudent.Name} {existingStudent.Surname}? (yes/no): ");
        string confirmation = Console.ReadLine()!;
        if (confirmation.ToLower() != "yes")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        await _studentService.DeleteStudentAsync(id);

        Console.WriteLine("Student deleted successfully.");
    }
}
