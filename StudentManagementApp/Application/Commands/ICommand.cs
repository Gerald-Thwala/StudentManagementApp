namespace StudentManagementApp.Application.Commands;
public interface ICommand
{
    Task ExecuteAsync(string[] args);
}