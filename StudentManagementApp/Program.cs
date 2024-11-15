using Microsoft.Extensions.DependencyInjection;
using StudentManagementApp.Application.Commands;
using StudentManagementApp.Application.Factories;
using StudentManagementApp.Application.Interfaces;
using StudentManagementApp.Application.Services;
using StudentManagementApp.Infrastructure.Persistence;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IStudentRepository>(sp => new StudentRepository("students")) 
    .AddSingleton<StudentService>()
    .AddSingleton<ICommandFactory, CommandFactory>()
    .AddSingleton<AddStudentCommand>()
    .BuildServiceProvider();

try
{
    // Get command-line arguments
    var commandArgs = Environment.GetCommandLineArgs().Skip(1).ToArray();
    if (commandArgs.Length == 0 || !commandArgs[0].StartsWith("--action="))
    {
        Console.WriteLine("No command provided. Use --action=<action>.");
        return;
    }

    var action = commandArgs[0].Substring("--action=".Length); 
    var parameters = commandArgs.Skip(1).ToArray(); 

    var commandFactory = serviceProvider.GetRequiredService<ICommandFactory>();
    var command = commandFactory.CreateCommand(action, parameters);
    await command.ExecuteAsync(parameters);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}