namespace StudentManagementApp.Application.Commands;
public interface ICommand
{
    /// <summary>
    /// Executes the command with the given arguments.
    /// </summary>
    /// <param name="args">The arguments passed to the command.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecuteAsync(string[] args);
}