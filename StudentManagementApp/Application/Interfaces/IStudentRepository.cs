using StudentManagementApp.Core.Models;

namespace StudentManagementApp.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task DeleteStudent(int id);
        IEnumerable<Student> GetAllStudents();

    }
}
