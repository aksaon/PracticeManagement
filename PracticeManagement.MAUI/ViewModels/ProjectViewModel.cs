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

namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Project> Projects
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Project>(ProjectService.Current.Projects);
                }
                return new ObservableCollection<Project>(ProjectService.Current.Search(Query));
            }
        }
        public string Query { get; set; }
        public void Search()
        {
            NotifyPropertyChanged("Projects");
        }
        public void Delete()
        {
            if (SelectedProject == null)
            {
                return;
            }
            ProjectService.Current.Delete(SelectedProject.Id);
            NotifyPropertyChanged("Projects");
            SelectedProject = null;
        }
        public void Add(Shell s)
        {
            s.GoToAsync($"//ProjectDetails?projectId=0");
        }
        public void Edit(Shell s)
        {
            if (SelectedProject == null)
            {
                return;
            }
            var idParam = SelectedProject.Id;
            s.GoToAsync($"//ProjectDetails?projectId={idParam}");
        }
        public void Close()
        {
            if (SelectedProject == null || SelectedProject.IsActive == false) { return; }
            ProjectService.Current.Close(SelectedProject.Id);
            NotifyPropertyChanged("Projects");
        }
        public Project SelectedProject { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}
