using StudentManagementApp.Application.Interfaces;
using StudentManagementApp.Application.Commands;

namespace StudentManagementApp.Application.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _commands;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _commands = new()
        {
            { "add", typeof(AddStudentCommand) },
            
        };
        }

        public bool TryGetCommand(string action, out ICommand command)
        {
            command = null!;
            if (_commands.TryGetValue(action, out var type))
            {
                command = (ICommand)_serviceProvider.GetService(type)!;
                return command != null;
            }
            return false;
        }
    }
}
