using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Services;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
[QueryProperty(nameof(ClientId), "clientId")]
public partial class ShowBill : ContentPage
{
	public int ProjectId { get; set; }
    public int ClientId { get; set; }
	public ShowBill()
	{
		InitializeComponent();
	}
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (ClientId > 0) // If arriving from client view
        {
            BindingContext = new ShowBillViewModel(ClientService.Current.Get_Projects(ClientId));
        }
        else                    // If arriving from project view
        {
            BindingContext = new ShowBillViewModel(ProjectId);
        }
    }
    private void Return_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage"); // replace with return to original page
    }
}