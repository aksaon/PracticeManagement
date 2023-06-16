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
using System.Xml.Linq;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientDetailsViewModel : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string notes { get; set; }
        public int Id { get; set; }
        

        public ClientDetailsViewModel(int id = 0)
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
            var client = ClientService.Current.Get(id) as Client;
            if (client != null)
            {
                name = client.Name;
                Id = client.Id;
                notes = client.Notes;
                
            }

            NotifyPropertyChanged(nameof(name));
            NotifyPropertyChanged(nameof(notes));

        }
        public void AddClient()
        {

            if (Id <= 0) // Add new Client
            {
                ClientService.Current.Add(new Client { Id = ClientService.Current.Get_Next_Id(),Name = name, Notes = notes, OpenDate = DateTime.Now });
            }
            else // Edit Client
            {
                var refToUpdate = ClientService.Current.Get(Id) as Client;
                refToUpdate.Name = name;
                refToUpdate.Notes = notes;
                
            }
            Shell.Current.GoToAsync("//Clients");
        }
        
    }
}
