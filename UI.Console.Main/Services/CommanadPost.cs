using Lib.Main.Core.Interfaces;
using Lib.Main.Services.Services;
using UI.Cli.Main.Interfaces;



namespace UI.Cli.Main.Services;

internal class CommandPost : IMenuCommand
{
    private readonly IUserService _userService;
    public string Description => "Add new";

    public CommandPost(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        var formModel = _userService.GetUserFormModel();

        Console.WriteLine("Time to add a user, here we go...");
        
        Console.Write("(Required!) First Name: ");
        formModel.FirstName = Console.ReadLine()!;

        Console.Write("(Required!) Last Name: ");
        formModel.LastName = Console.ReadLine()!;

        Console.Write("(Required!) Email: ");
        formModel.Email = Console.ReadLine()!;

        Console.Write("(Required!) Phone: ");
        formModel.PhoneNumber = Console.ReadLine()!;

        Console.Write("Adress: ");
        formModel.Adress = Console.ReadLine() ?? "";

        Console.Write("Postal Code: ");
        formModel.PostalCode = Console.ReadLine() ?? "";

        Console.Write("County: ");
        formModel.County = Console.ReadLine() ?? "";



        var validations = _userService.AddUser(formModel);
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
    }
}
