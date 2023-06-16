using PracticeManagement.CLI.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]

public partial class ProjectDetailsView : ContentPage
{
    public ProjectDetailsView()
    {
        InitializeComponent();
    }
    public int ProjectId { get; set; }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as ProjectDetailsViewModel).AddProject();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Projects");
    }


    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectDetailsViewModel(ProjectId);
    }

}