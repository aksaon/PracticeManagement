using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Client_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Clients");
        }

        private void Project_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Projects");
        }

        private void Employee_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employees");
        }
        private void Time_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Times");
        }
    }
}