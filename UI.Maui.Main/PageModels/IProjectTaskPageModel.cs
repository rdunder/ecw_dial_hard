using CommunityToolkit.Mvvm.Input;
using UI.Maui.Main.Models;

namespace UI.Maui.Main.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}