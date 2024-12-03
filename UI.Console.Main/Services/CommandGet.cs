using Lib.Main.Core.Models;
using Lib.Main.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services
{
    internal class CommandGet : IMenuCommand
    {
        public string Description => "Show Contacts";
        IEnumerable<UserModel> _users;
        UserService _userService;

        public CommandGet(UserService userService)
        {
            _userService = userService;
        }

        public void Execute()
        {
            Console.WriteLine("get command");
            _users = _userService.Get();

            Console.WriteLine("\nHere is the users curently in database\n");

            foreach (UserModel user in _users)
            {
                Console.WriteLine($"{user.FirstName, -10}{user.LastName, -10}{user.Email, -25}{user.PhoneNumber, 12}");
            }
        }
    }
}
