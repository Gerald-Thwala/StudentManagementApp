using StudentManagementApp.Application.Interfaces;
using StudentManagementApp.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace StudentManagementApp.Application.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string action, string[] args)
        {
            return action.ToLower() switch
            {
                "add" => _serviceProvider.GetRequiredService<AddStudentCommand>(),
                _ => throw new ArgumentException($"Unknown command action: {action}")
            };
        }
    }
}
