using Lib.Main.Core.Interfaces;
using Lib.Main.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services
{
    internal class CommandDelete : IMenuCommand
    {
        private readonly IUserService _userService;
        public string Description => "Delete";

        public CommandDelete(IUserService userService)
        {
            _userService = userService;
        }

        public void Execute()
        {
            Console.WriteLine("delete command");
        }
    }
}
