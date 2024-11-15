using StudentManagementApp.Application.Commands;

namespace StudentManagementApp.Application.Interfaces
{
    /// <summary>
    /// A factory interface for creating commands based on input arguments.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates a command based on the provided action and arguments.
        /// </summary>
        /// <param name="action">The action to perform (e.g., "add", "edit", "delete", etc.).</param>
        /// <param name="args">The arguments associated with the command (e.g., student ID, name, etc.).</param>
        /// <returns>The created command.</returns>
        ICommand CreateCommand(string action, string[] args);
    }
}
