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
        public string Description => "Get All";

        public CommandGet(UserService userService)
        {
            
        }

        public void Execute()
        {
            Console.WriteLine("get command");
        }
    }
}
