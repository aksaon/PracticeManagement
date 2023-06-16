using PracticeManagement.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
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
        private List<Client> clients;
        private ClientService() 
        {
            clients = new List<Client>();
        }
        public Client? Get(int id) 
        {
            return clients.FirstOrDefault(c => c.Id == id);
        }
        public int Get_Next_Id()
        {
            if (clients.Count == 0)
                return 1;
            return clients.Last().Id + 1;
        }
        // Full List of Clients
        public List<Client> Clients 
        {
            get { return clients; }
        }
        // Note: Only Called By ProjectDetailsViewModel to get a list of active Clients
        //       (Prevents adding a project to a closed client)
        public List<Client> ClientList
        {
            
            get 
            {
                List<Client> tempList = new List<Client>();
                foreach(var client in clients)
                {
                    if(client.IsActive == true)
                    {
                        tempList.Add(client);
                    }
                }
                return tempList; }
        }
        public List<Client> Search(string query)
        {
            return Clients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
        public void Add(Client client) 
        {
            clients.Add(client);
        }
        public void Delete(int id) 
        {
            var clientToRemove = Get(id);
            if(clientToRemove != null) 
            { 
                clients.Remove(clientToRemove); 
            }
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
