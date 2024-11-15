using System;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementApp.Application.Services;
using StudentManagementApp.Application.Validators;
using StudentManagementApp.Core.Models;

namespace StudentManagementApp.Application.Commands
{
    public class EditStudentCommand : ICommand
    {
        private readonly StudentService _studentService;

        public EditStudentCommand(StudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task ExecuteAsync(string args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error: --id is required for edit action.");
                return;
            }

            if (!InputValidator.ValidateStudentId(args, out int studentId))
            {
                Console.WriteLine("Error: Invalid Student ID.");
                return;
            }

            var student = await _studentService.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                Console.WriteLine($"Error: No student found with ID {studentId}.");
                return;
            }

            Console.WriteLine("Enter new details (leave blank to keep existing values):");

            Console.Write($"Name [{student.Name}]: ");
            string name = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(name))
                student.Name = name;

            Console.Write($"Surname [{student.Surname}]: ");
            string surname = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(surname))
                student.Surname = surname;

            Console.Write($"Age [{student.Age}]: ");
            string ageInput = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (InputValidator.ValidateAge(ageInput, out int age))
                    student.Age = age;
                else
                    Console.WriteLine("Invalid age input. Keeping existing age.");
            }

            Console.Write($"Curriculum [{student.Curriculum}]: ");
            string curriculum = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(curriculum))
                student.Curriculum = curriculum;

            try
            {
                await _studentService.EditStudentAsync(studentId, student);
                Console.WriteLine("Student details updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
            }
        }
    }
}
