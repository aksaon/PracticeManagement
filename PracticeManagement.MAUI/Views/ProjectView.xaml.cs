using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ProjectView : ContentPage
{
    public ProjectView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewViewModel();
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
        (BindingContext as ProjectViewViewModel).Search();
    }

    // Add/Edit/Delete Buttons
    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Add(Shell.Current);
    }
    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshView();
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshView();
    }
    private void Close_Clicked(object sender, EventArgs e)
    {
       (BindingContext as ProjectViewViewModel).RefreshView();
    }
    private void ShowBill_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshView();
    }
    private void Return_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    // Refresh Page When Navigated to
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshView();
    }
}