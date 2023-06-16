using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class TimeView : ContentPage
{
    public TimeView()
    {
        InitializeComponent();
        BindingContext = new TimeViewModel();
    }
    // Navigation Bar
    private void ToHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ToClients_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }
    private void ToProjects_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Projects");
    }
    private void ToEmployees_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employees");
    }
    // Search Bar
    private void Search_Clicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).Search();
    }

    // Add/Edit/Delete Buttons
    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).Add(Shell.Current);
    }
    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).Edit(Shell.Current);
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).Delete();

    }
    // Refresh Page When Navigated to
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TimeViewModel).RefreshView();
    }
}