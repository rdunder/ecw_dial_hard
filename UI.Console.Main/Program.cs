using Lib.Main.Core.Interfaces;
using Lib.Main.Infrastructure.Repositories;
using Lib.Main.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.Cli.Main.Interfaces;
using UI.Cli.Main.Services;


var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IUserRepository, UserJsonRepository>();
        services.AddSingleton<UserService>();
    })
    .Build();

var userService = host.Services.GetService<UserService>();
if (userService != null)
    Console.WriteLine(userService);

MenuService menuService = new MenuService(new List<IMenuCommand>
{
    new CommandGet(userService),
    new CommandPost(userService),
    new CommandPut(userService),
    new CommandDelete(userService)
});


while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the App of the year!\n");
    Console.WriteLine("___Its___Time___To___Dial___Hard___\n");

    menuService.ShowMenu();

    if (!menuService.ProcessMenuSelection(Console.ReadKey(true))) break;
}

