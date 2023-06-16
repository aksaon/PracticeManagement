using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]

public partial class ClientDetailsView : ContentPage
{
	public ClientDetailsView()
	{
		InitializeComponent();
	}
	public int ClientId { get; set; }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as ClientDetailsViewModel).AddClient();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }


    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientDetailsViewModel(ClientId);
    }
}