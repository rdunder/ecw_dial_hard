

using Lib.Main.Core.Interfaces;
using Lib.Main.Services.Services;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services;

internal class CommandPut : IMenuCommand
{
    private readonly IUserService _userService;
    public string Description => "Update";

    public CommandPut(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.WriteLine("put command");
    }
}
