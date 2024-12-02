

namespace UI.Cli.Main.Interfaces;

internal interface IMenuCommand
{
    string Description { get; }
    void Execute();
}
