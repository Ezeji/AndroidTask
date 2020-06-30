using AndroidTask.Model;
using AndroidTask.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidTask.ViewModel
{
    public class LogInPageViewModel
    {
        public LoginUser LoginUser { get; set; } = new LoginUser();
        public SignUpPage SignUpPage { get; set; } = new SignUpPage();
        public MainPage MainPage { get; set; } = new MainPage();
        public ICommand SignUpCommand { get; }
        public ICommand LogInCommand { get; }
        private Page _page;

        public LogInPageViewModel(Page page)
        {
            _page = page;
            SignUpCommand = new Command(async () => await SignUpAsync());
            LogInCommand = new Command(async () => await LogInAsync());
        }

        private async Task SignUpAsync()
        {
            await _page.Navigation.PushAsync(SignUpPage);
        }

        private async Task LogInAsync()
        {
            if (!ValidationHelper.IsFormValid(LoginUser, _page))
            {
                return;
            }
            else
            {
                var loginUser = new LoginUser
                {
                    Email = LoginUser.Email,
                    Password = LoginUser.Password
                };

                var response = await App.Database.LoginUser(loginUser);

                if (response == "There's no such user...")
                {
                   await _page.DisplayAlert("Alert!", "There's no such user...", "OK");
                }
                else
                {
                    _page.Navigation.InsertPageBefore(MainPage, _page);
                    _page.Navigation.RemovePage(_page);
                }   
            }
        }
    }
}
