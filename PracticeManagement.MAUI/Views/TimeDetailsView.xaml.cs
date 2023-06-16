using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(TimeId), "timeId")]

public partial class TimeDetailsView : ContentPage
{
    public TimeDetailsView()
    {
        InitializeComponent();
    }
    public int TimeId { get; set; }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as TimeDetailsViewModel).AddProject();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Times");
    }


    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeDetailsViewModel(TimeId);
    }
}