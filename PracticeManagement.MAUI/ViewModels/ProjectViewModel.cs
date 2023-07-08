using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public Project Model { get; set; }
      
        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand CloseCommand { get; private set; } 
        public ICommand ShowBillCommand { get; set; }
        private void SetCommands()
        {
            DeleteCommand = new Command(
                (p) => ExecuteDelete((p as ProjectViewModel).Model.Id));
            EditCommand = new Command(
                (p) => ExecuteEdit((p as ProjectViewModel).Model.Id));
            CloseCommand = new Command(
                (p) => ExecuteClose((p as ProjectViewModel).Model.Id));
            ShowBillCommand = new Command(
                (p) => ExecuteShow((p as ProjectViewModel).Model.Id));
        }
        public void ExecuteDelete(int id)
        {
            ProjectService.Current.Delete(id);
        }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ProjectDetails?projectId={id}");
        }
        public void ExecuteClose(int id)
        {
            ProjectService.Current.Close(id);
        }
        public void ExecuteShow(int id)
        {
            Shell.Current.GoToAsync($"//ShowBill?projectId={id}");
        }
        public ProjectViewModel(Project project)
        {
            Model = project;
            SetCommands();
        }
        public ProjectViewModel(int id)
        {
            if (id > 0)
                Model = ProjectService.Current.Get(id);
            else
                Model = new Project();
            SetCommands();
        }
        public ProjectViewModel()
        {
            Model = new Project();
            SetCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
