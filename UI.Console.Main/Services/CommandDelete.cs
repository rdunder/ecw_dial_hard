using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services;

internal class CommandDelete(IUserService userService) : IMenuCommand
{
    private readonly IUserService _userService = userService;
    public string Description => "Delete";

    public void Execute()
    {
        while (true)
        {
            var _users = _userService.Get().ToArray();
            Console.Clear();

            if (_users.Count() > 0)
            {
                Console.WriteLine("\nHere is the users curently in database\n");
                for (int i = 0; i < _users.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {_users[i].FirstName} {_users[i].LastName}");
                }
            }
            else
            {
                Console.WriteLine("There are currently no users registered");
            }


            Console.WriteLine("\nWhat contact do you want to delete? ('Escape' to go back)");
            var input = Console.ReadKey(true);

            if (Int32.TryParse( input.KeyChar.ToString(), out int x) && x > 0)
            {
                Console.WriteLine($"Do you really want to delete - {_users[x - 1].FirstName} {_users[x - 1].LastName} ? (Y/n");

                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    UserModel userToDelete = _users[x - 1];
                    _userService.DeleteUser(userToDelete);
                }
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Use the numbers to the left of the name to choos a contact to delete.");
                Console.ReadKey();
            }
        }
    }
}
