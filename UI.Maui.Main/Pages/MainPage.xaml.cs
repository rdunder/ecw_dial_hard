using UI.Maui.Main.Models;
using UI.Maui.Main.PageModels;

namespace UI.Maui.Main.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}