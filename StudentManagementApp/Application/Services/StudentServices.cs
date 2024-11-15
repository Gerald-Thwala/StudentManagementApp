// Application/Services/StudentService.cs
using StudentManagementApp.Application.Interfaces;
using StudentManagementApp.Core.Models;
using System.Linq;

namespace StudentManagementApp.Application.Services;

public class StudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task AddStudentAsync(Student student)
    {
        var existingStudent = await _repository.GetStudentByIdAsync(student.Id);
        if (existingStudent != null)
            throw new InvalidOperationException("Student with the same ID already exists.");

        await _repository.AddStudentAsync(student);
    }

    public async Task EditStudentAsync(int id, Student updatedStudent)
    {
        var existingStudent = await _repository.GetStudentByIdAsync(id);
        if (existingStudent == null)
            throw new InvalidOperationException("Student not found.");

        updatedStudent.Id = id; // Ensure ID is not changed
        await _repository.AddStudentAsync(updatedStudent);
    }

    public async Task DeleteStudentAsync(int id)
    {
        await _repository.DeleteStudent(id); 
    }

    public IEnumerable<Student> SearchStudents(Func<Student, bool> predicate)
    {
        return _repository.GetAllStudents().Where(predicate);
    }
}

