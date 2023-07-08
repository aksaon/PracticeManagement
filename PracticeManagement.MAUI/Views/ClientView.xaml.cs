using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
        BindingContext = new ClientViewViewModel();
    }
    // Navigation Bar
    private void ToHome_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ToProjects_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Projects");
    }
    private void ToEmployees_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employees");
    }
    private void ToTimes_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Times");
    }
    // Search Bar
    private void Search_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Search();
    }
   
    // Add/Edit/Delete Buttons
    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Add(Shell.Current);
    }
    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();

    }
    private void Close_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();
    }
    private void ShowBill_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();
    }
    private void Return_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    // Refresh Page When Navigated to
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).UpdateProjects();
        (BindingContext as ClientViewViewModel).RefreshView();
    }
}