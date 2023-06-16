using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectDetailsViewModel : INotifyPropertyChanged
    {
        public string nameLong { get; set; }
        public string nameShort { get; set; }
        public int Id { get; set; }
        public List<Client> ClientList
        {
            get
            {
                return ClientService.Current.ClientList;
            }
        }
        public Client selectedClient { get; set; }

        public ProjectDetailsViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var project = ProjectService.Current.Get(id) as Project;
            if (project != null)
            {
                nameLong = project.LongName;
                nameShort = project.ShortName;
                Id = project.Id;
                selectedClient = ClientService.Current.Get(project.ClientId);
            }

            NotifyPropertyChanged(nameof(nameShort));
            NotifyPropertyChanged(nameof(nameLong));
            NotifyPropertyChanged(nameof(selectedClient));
        }
        public void AddProject()
        {
            if (selectedClient == null) { return; }
            if (Id <= 0) // Add new Project
            {
                ProjectService.Current.Add(new Project { Id = ProjectService.Current.Get_Next_Id(), LongName = nameLong, 
                                                         ShortName = nameShort, ClientId = selectedClient.Id, OpenDate = DateTime.Now, IsActive = true });
            }
            else // Edit Project
            {
                var refToUpdate = ProjectService.Current.Get(Id) as Project;
                refToUpdate.LongName = nameLong;
                refToUpdate.ShortName = nameShort;
                refToUpdate.ClientId = selectedClient.Id;
            }
            Shell.Current.GoToAsync("//Projects");
        }

    }
}
