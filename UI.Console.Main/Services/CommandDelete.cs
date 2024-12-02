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
        public string Description => "Delete";

        public CommandDelete(UserService userService)
        {
            
        }

        public void Execute()
        {
            Console.WriteLine("delete command");
        }
    }
}
