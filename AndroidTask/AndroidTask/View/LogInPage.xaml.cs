using AndroidTask.Model;
using AndroidTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidTask.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    { 
        public LogInPage()
        {
            InitializeComponent();
            this.BindingContext = new LogInPageViewModel(this);
        }

        
    }
}