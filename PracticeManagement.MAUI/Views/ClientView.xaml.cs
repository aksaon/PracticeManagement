using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel();
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
        (BindingContext as ClientViewModel).Search();
    }
   
    // Add/Edit/Delete Buttons
    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Add(Shell.Current);
    }
    private void Edit_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Edit(Shell.Current);
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Delete();

    }
    // Refresh Page When Navigated to
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewModel).UpdateProjects();
        (BindingContext as ClientViewModel).RefreshView();
    }
}