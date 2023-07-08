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
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }

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
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            CloseCommand = new Command(
                (c) => ExecuteClose((c as ClientViewModel).Model.Id));
            ShowBillCommand = new Command(
                (c) => ExecuteShow((c as ClientViewModel).Model.Id));
        }
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetails?clientId={id}");
        }
        public void ExecuteClose(int id)
        {
            ClientService.Current.Close(id);
        }
        public void ExecuteShow(int id)
        {
            Shell.Current.GoToAsync($"//ShowBill?clientId={id}");
        }
        public ClientViewModel(Client client)
        {
            Model = client;
            SetCommands();
        }
        public ClientViewModel(int id)
        {
            if (id > 0)
                Model = ClientService.Current.Get(id);
            else
                Model = new Client();
            SetCommands();
        }
        public ClientViewModel()
        {
            Model = new Client();
            SetCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
