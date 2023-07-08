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
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return
                    new ObservableCollection<ClientViewModel>
                    (ClientService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new ClientViewModel(c)).ToList());
            }
        }
        public string Query { get; set; }
        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }
        public void Delete()
        {
            if (SelectedClient == null)
            {
                return;
            }
            ClientService.Current.Delete(SelectedClient.Id);
            NotifyPropertyChanged("Clients");
            SelectedClient = null;
        }
        public void Close()
        {
            if (SelectedClient == null) { return; }
            ClientService.Current.Close(SelectedClient.Id);
            NotifyPropertyChanged("Clients");
        }
        public void Add(Shell s)
        {
            s.GoToAsync($"//ClientDetails?clientId=0");
        }
        public void Edit(Shell s)
        {
            if (SelectedClient == null || SelectedClient.IsActive == false)
            {
                return;
            }
            var idParam = SelectedClient.Id;
            s.GoToAsync($"//ClientDetails?clientId={idParam}");
        }
        public Client SelectedClient { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void UpdateProjects()
        {
            ClientService.Current.UpdateProjects();
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Clients));
        }
    }
}
