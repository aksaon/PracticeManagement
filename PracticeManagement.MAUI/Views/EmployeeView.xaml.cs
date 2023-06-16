using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
        InitializeComponent();
        BindingContext = new EmployeeViewModel();
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
    private void ToTimes_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Times");
    }
    // Search Bar
    private void Search_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Search();
    }

    // Add/Edit/Delete Buttons
    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Add(Shell.Current);
    }
    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Edit(Shell.Current);
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Delete();

    }
    // Refresh Page When Navigated to
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewModel).RefreshView();
    }
}