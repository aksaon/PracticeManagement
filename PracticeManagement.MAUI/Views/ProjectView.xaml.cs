using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ProjectView : ContentPage
{
    public ProjectView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewModel();
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
        (BindingContext as ProjectViewModel).Search();
    }

    // Add/Edit/Delete Buttons
    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).Add(Shell.Current);
    }
    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).Edit(Shell.Current);
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).Delete();
    }
    private void Close_Clicked(object sender, EventArgs e)
    {
       (BindingContext as ProjectViewModel).Close();
    }
    // Refresh Page When Navigated to
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ProjectViewModel).RefreshView();
    }
}