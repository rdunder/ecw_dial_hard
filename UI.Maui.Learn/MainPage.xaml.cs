using Lib.Main.Core.Models;
using Lib.Main.Services.Services;

namespace UI.Maui.Learn
{
    public partial class MainPage : ContentPage
    {
        UserService _userService;
        IEnumerable<UserModel> _users;

        int count = 0;

        public MainPage(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            _users = _userService.Get();
            foreach (UserModel user in _users)
            {
                LabelName.Text += $"  {user.FirstName}\n";
            }

        }
    }

}
