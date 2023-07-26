using PracticeManagement.CLI.Models;
using PracticeManagement.Library.DTO;
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
        
        private ClientDTO client { get; set; }

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
            if (id == 0) 
            {
                Id = 0;  // Set flag for AddClient
                return; 
            }
            client = ClientService.Current.Get(id) as ClientDTO;
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
            if(Id == 0)  // if flag is hit, its a new client
            {
                client = new ClientDTO(new Client { Id = ClientService.Current.Get_Next_Id(), Name = name, Notes = notes, OpenDate = DateTime.Now, IsActive = true });
                ClientService.Current.AddOrUpdate(client);
            }
            else
            {
                client.Id = Id;
                client.Name = name;
                client.Notes = notes;
                ClientService.Current.AddOrUpdate(client);
            }   
            /*if (Id <= 0) // Add new Client
            {
                ClientService.Current.Add(new Client { Id = ClientService.Current.Get_Next_Id(),Name = name, Notes = notes, OpenDate = DateTime.Now, IsActive = true });
            }
            else // Edit Client
            {
                var refToUpdate = ClientService.Current.Get(Id) as Client;
                refToUpdate.Name = name;
                refToUpdate.Notes = notes;
            }*/
            Shell.Current.GoToAsync("//Clients");
        }
        
    }
}
