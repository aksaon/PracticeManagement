using PracticeManagement.Library.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(TimeId), "timeId")]
public partial class BillDetailsView : ContentPage
{
    public int TimeId { get; set; }
    public DateTime selectedDate { get; set; }
    public BillDetailsView()
	{
		InitializeComponent();
	}
    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as BillDetailsViewModel).AddBill(selectedDate);
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
        BindingContext = new BillDetailsViewModel(TimeId);
        selectedDate = DateTime.Now;    // initialize selected date
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        var picker = sender as DatePicker;
        DateTime date = picker.Date;
        selectedDate = date;
    }
}