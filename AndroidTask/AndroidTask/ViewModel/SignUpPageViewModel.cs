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
    public class SignUpPageViewModel
    {
        public RegisterUser RegisterUser { get; set; } = new RegisterUser();
        public ICommand SignUpCommand { get; }
        private Page _page;

        public SignUpPageViewModel(Page page)
        {
            _page = page;
            SignUpCommand = new Command(async () => await SignUpAysnc());
        }

        private async Task SignUpAysnc()
        {
            if (!ValidationHelper.IsFormValid(RegisterUser, _page))
            {
                return;
            }
            else
            {
                var registerUser = new RegisterUser
                {
                    Username = RegisterUser.Username,
                    Email = RegisterUser.Email,
                    EncryptedPassword = PasswordEncryption.HashPassword(RegisterUser.Password.ToString()),
                    PhoneNumber = RegisterUser.PhoneNumber,
                    ClientID = RegisterUser.ClientID,
                    Company = RegisterUser.Company,
                    UserID = Guid.NewGuid().ToString()
                };

                await App.Database.SignupUser(registerUser);

                await _page.Navigation.PopAsync();

            }
        }


    }
}
