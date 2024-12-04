using Lib.Main.Core.Interfaces;
using Lib.Main.Infrastructure.Repositories;
using Lib.Main.Services.Factories;
using Lib.Main.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.Cli.Main.Interfaces;
using UI.Cli.Main.Services;


var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IUserRepository, UserJsonRepository>();
        services.AddTransient<IUserFactory, UserFactory>();
        services.AddSingleton<IUserService, UserService>();

        services.AddSingleton<MenuService>();
    })
    .Build();

var menuService = host.Services.GetService<MenuService>()!;


while (true)
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("********************************************************");
    Console.WriteLine("OBS! this app is saving a file called Database.json in");
    Console.WriteLine($"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DialHard")}");
    Console.WriteLine("********************************************************\n\n");
    Console.ForegroundColor = ConsoleColor.White;


    Console.WriteLine("Welcome to the App of the year!\n");
    Console.WriteLine("___Its___Time___To___Dial___Hard___\n");

    menuService.ShowMenu();

    if (!menuService.ProcessMenuSelection(Console.ReadKey(true))) break;
}

