

using Lib.Main.Services.Services;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services;

internal class CommandPut : IMenuCommand
{
    public string Description => "Update";

    public CommandPut(UserService userService)
    {
        
    }

    public void Execute()
    {
        Console.WriteLine("put command");
    }
}
