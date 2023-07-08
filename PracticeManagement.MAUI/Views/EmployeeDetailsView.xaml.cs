using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]

public partial class EmployeeDetailsView : ContentPage
{
	public EmployeeDetailsView()
	{
		InitializeComponent();
	}
    public int EmployeeId { get; set; }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as EmployeeDetailsViewModel).AddProject();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employees");
    }


    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeDetailsViewModel(EmployeeId);
    }

}