

using System;
using UI.Cli.Main.Interfaces;

namespace UI.Cli.Main.Services;

internal class MenuService
{
    private readonly List<IMenuCommand> _commands;

    public MenuService(List<IMenuCommand> commands)
    {
        _commands = commands;
    }

    public void ShowMenu()
    {
        Console.WriteLine("=== Main Menu ===\n");

        for (int i = 0; i < _commands.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_commands[i].Description}");
        }

        Console.WriteLine("\nQ: Quit the program\n");
        Console.WriteLine("=================");
    }

    public bool ProcessMenuSelection(ConsoleKeyInfo key)
    {
        if (key.KeyChar.ToString().ToLower() == "q")
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit?\t(y/n)");
            if (Console.ReadKey().KeyChar == 'y')
            {
                return false;
            }
            return true;
        }

        if (int.TryParse(key.KeyChar.ToString(), out int select)
            && select > 0
            && select <= _commands.Count)
        {
            try
            {
                _commands[select - 1].Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Errror Occured\n{ex}\n_____________________");
            }
        }
        else
        {
            Console.WriteLine("That is not a valid input ...!");
        }

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
        return true;
    }
}
