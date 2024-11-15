using System.Text.Json;
using StudentManagementApp.Core.Models;
using StudentManagementApp.Application.Interfaces;

namespace StudentManagementApp.Infrastructure.Persistence;

public class StudentRepository : IStudentRepository
{
    private readonly string _basePath;

    public StudentRepository(string basePath)
    {
        _basePath = basePath;
        Directory.CreateDirectory(_basePath);
    }

    public async Task AddStudentAsync(Student student)
    {
        string directory = Path.Combine(_basePath, student.Id.ToString().Substring(0, 2));
        Directory.CreateDirectory(directory);
        string filePath = Path.Combine(directory, $"{student.Id}.json");

        string json = JsonSerializer.Serialize(student, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
    }
    #nullable enable
    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        string directory = Path.Combine(_basePath, id.ToString()[..2]);
        string filePath = Path.Combine(directory, $"{id}.json");

        if (!File.Exists(filePath)) return null;

        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<Student>(json);
    }

    public Task DeleteStudent(int id)
    {
        string directory = Path.Combine(_basePath, id.ToString()[..2]);
        string filePath = Path.Combine(directory, $"{id}.json");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return Task.CompletedTask;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        if (!Directory.Exists(_basePath)) return Enumerable.Empty<Student>();

        var files = Directory.GetFiles(_basePath, "*.json", SearchOption.AllDirectories);

        return files.Select(file =>
        {
            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<Student>(json)!;
        });
    }
}
