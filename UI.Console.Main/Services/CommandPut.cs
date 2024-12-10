

using Lib.Main.Core.Interfaces;
using Lib.Main.Core.Models;
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


            Console.WriteLine("\nWhat contact do you want to change? ('Escape' to go back)");
            var input = Console.ReadKey(true);

            if (Int32.TryParse(input.KeyChar.ToString(), out int x) && x > 0)
            {
                var currentUser = _users[x - 1];
                var newUser = _userService.GetUserFormModel();

                Console.Clear();
                Console.WriteLine($"{currentUser.FirstName} {currentUser.LastName}");
                Console.WriteLine($"Email: {currentUser.Email}");
                Console.WriteLine($"Phone: {currentUser.PhoneNumber}");
                Console.WriteLine($"Adress: {currentUser.Adress}, {currentUser.PostalCode}, {currentUser.County}");

                Console.WriteLine("\nEnter new information\n");

                Console.Write("(Required!) First Name: ");
                newUser.FirstName = Console.ReadLine()!;

                Console.Write("(Required!) Last Name: ");
                newUser.LastName = Console.ReadLine()!;

                Console.Write("(Required!) Email: ");
                newUser.Email = Console.ReadLine()!;

                Console.Write("(Required!) Phone: ");
                newUser.PhoneNumber = Console.ReadLine()!;

                Console.Write("Adress: ");
                newUser.Adress = Console.ReadLine() ?? "";

                Console.Write("Postal Code: ");
                newUser.PostalCode = Console.ReadLine() ?? "";

                Console.Write("County: ");
                newUser.County = Console.ReadLine() ?? "";

                var validations = _userService.UpdateUser(currentUser, newUser);
                if (validations != null)
                {
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var validation in validations)
                    {
                        Console.WriteLine(validation);
                    }
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThanks for the entry!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Use the numbers to the left of the name to choose a contact to change.");
                Console.ReadKey();
            }
        }
    }
}
