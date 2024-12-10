using Lib.Main.Core.Models;
using Lib.Main.Services.Services;
using Lib.Main.Core.Interfaces;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services
{
    internal class CommandGet(IUserService userService) : IMenuCommand
    {
        public string Description => "Show Contacts";
        private readonly IUserService _userService = userService;
        IEnumerable<UserModel> _users = null!;

        public void Execute()
        {
            _users = _userService.Get();

            if (_users.Count() > 0)
            {
                Console.WriteLine("\nHere is the users curently in database\n");


                foreach (UserModel user in _users)
                {
                    Console.WriteLine($"{user.FirstName,-10}{user.LastName,-15}{user.Email,-25}{user.PhoneNumber,12}");
                }
            }
            else
            {
                Console.WriteLine("There are currently no users registered");
            }
            
        }
    }
}
