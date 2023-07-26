using Newtonsoft.Json;
using PracticeManagement.Library.Utilities;
using PracticeManagement.CLI.Models;
using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private List<ClientDTO> clients;
        public List<ClientDTO> Clients
        {
            get
            {
                return clients ?? new List<ClientDTO>();
            }
        }
        private static ClientService? instance;
        private static object instanceLock = new object();
        public static ClientService Current 
        {
            get
            {
                lock(instanceLock)
                {
                    if(instance == null)
                        instance = new ClientService();
                }
                
                return instance;
            }
        }
        private ClientService() 
        {
            var response = new WebRequestHandler().Get("/Client").Result;
            clients = JsonConvert.DeserializeObject<List<ClientDTO>>(response) ?? new List<ClientDTO>();
        }
        public void Delete(int id)
        {
            // Delete from filebase
            var response = new WebRequestHandler().Delete($"/Client/Delete/{id}").Result;

            // Remove from list of clients
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
        }
        public void AddOrUpdate(ClientDTO client)
        {
            var response = new WebRequestHandler().Post("/Client", client).Result;

            var myUpdatedClient = JsonConvert.DeserializeObject<ClientDTO>(response);
            if(myUpdatedClient != null) 
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if (existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }
                else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }
        }
        public ClientDTO? Get(int id) 
        {
            var response = new WebRequestHandler().Get($"/{id}").Result;
            return JsonConvert.DeserializeObject<ClientDTO>(response);
            //return Clients.FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<ClientDTO>? Search(string query)
        {
            var response = new WebRequestHandler().Get($"/Client/Search?query={query}").Result;
            if (response != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ClientDTO>>(response);
            }
            return Clients;          
        }
        public int Get_Next_Id()
        {
            if (clients.Count == 0)
                return 1;
            return clients.Last().Id + 1;
        }
        // Note: Only Called By ProjectDetailsViewModel to get a list of active Clients
        //       (Prevents adding a project to a closed client)
        public List<ClientDTO> ClientList
        {
            
            get 
            {
                List<ClientDTO> tempList = new List<ClientDTO>();
                foreach(var client in Clients)
                {
                    if(client.IsActive == true)
                    {
                        tempList.Add(client);
                    }
                }
                return tempList; }
        }
        // List of Projects
        public List<Project> Get_Projects(int id)
        {
            return Clients.First(c => c.Id == id).Projects;
        }
        public void Add(ClientDTO client) 
        {
            clients.Add(client);
        }
        public void Close(int id) 
        {
            var clientToClose = Get(id);
            if(clientToClose != null)
            {
                foreach (var project in clientToClose.Projects)
                {
                    // if any project is still active, return
                    if(project.IsActive == true) { return; }
                }
                clientToClose.CloseDate = DateTime.Now;
                clientToClose.IsActive = false;

                AddOrUpdate(clientToClose);     // Update Client Side List

                _ = new WebRequestHandler().Post("/Client", clientToClose).Result;  // Update Server Side List
            
              // var myUpdatedClient = JsonConvert.DeserializeObject<ClientDTO>(response);
            } 
        }
        public void UpdateProjects()
        {
            if(ProjectService.Current.Projects.Count == 0) { return; }
            var myProjects = ProjectService.Current.Projects;


            // Note: Should find a better way of updating a Client's
            //       Project List - bad for a large number of clients/projects
            foreach (var client in clients)
            {
                client.Projects.Clear();
                foreach(var project in myProjects)
                {
                    if (client.Id == project.ClientId)
                    {
                        client.Projects.Add(project) ;
                    }
                }
            }
        }
        public void Read() 
        {
            clients.ForEach(Console.WriteLine);
        }
    }
}
