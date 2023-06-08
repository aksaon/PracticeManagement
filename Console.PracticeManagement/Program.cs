using Console.PracticeManagement.Models;
using System.Runtime.CompilerServices;
using System.Text;

namespace PracticeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> ClientList = new List<Client>();
            List<Project> ProjectList = new List<Project>();
           

            while (true)
            {
                PrintMenu();
                string option = GetOption();
                option = option.ToLower();
                
                switch (option)
                {
                    case "a":
                        CreateClient(ClientList);
                        break;
                    case "b":
                        ReadClients(ClientList);
                        break;
                    case "c":
                        UpdateClient(ClientList);
                        break;
                    case "d":
                        DeleteClient(ClientList);
                        break; 
                    case "e":
                        CreateProject(ProjectList, ClientList);
                        break; 
                    case "f":
                        ReadProjects(ProjectList);
                        break;
                    case "g":
                        UpdateProject(ProjectList, ClientList);
                        break;
                    case "h":
                        DeleteProject(ProjectList);
                        break;
                    default:
                        break;
                }

            }

        }
        static void CreateProject(List<Project> ProjectList, List<Client> ClientList)
        {
            // If No Clients Registered, return
            if (ClientList.Count == 0) 
            { 
                System.Console.WriteLine("\nNo Registered Clients. Please Add a Client Before Creating a New Project.\n"); 
                return;
            }

            // Get Project Info

            // Get Unique Project ID
            System.Console.WriteLine("Enter the Project ID:");
            int id = Convert.ToInt32(System.Console.ReadLine());
            while (!ValidPID(ProjectList, id))
            {
                System.Console.WriteLine("ID is Already In Use. Please Enter a Unique ID:");
                id = Convert.ToInt32(System.Console.ReadLine());
            }

            // Get Short and Long Project name
            System.Console.WriteLine("Enter the Short Project Name:");
            string shortName = System.Console.ReadLine() ?? string.Empty;

            System.Console.WriteLine("Enter the Long Project Name:");
            string longName = System.Console.ReadLine() ?? string.Empty;

            // Get a Non-Unique Client ID
            System.Console.WriteLine("Enter the Client ID:");
            int cID = Convert.ToInt32(System.Console.ReadLine());
            while (ValidID(ClientList, cID))
            {
                System.Console.WriteLine("ID Does Not Exist. Please Enter a Valid Client ID:");
                cID = Convert.ToInt32(System.Console.ReadLine());
            }

            // Add Project to the List
            ProjectList.Add(new Project() { Id = id, ShortName = shortName, LongName = longName, ClientId = cID });
        }
        static void ReadProjects(List<Project> ProjectList)
        {
            // If List is Empty, return
            if (ProjectList.Count == 0) { System.Console.WriteLine("\nNo Registered Projects\n"); return; }

            // Else, print the list
            System.Console.WriteLine("\nCurrently Registered Projects:\n");
            System.Console.WriteLine($"Project ID\tProject Name\tAssociated Client ID");
            System.Console.WriteLine("------------------------------------------------");

            var queryProjectList = ProjectList.AsQueryable();
            foreach (var project in queryProjectList) { System.Console.WriteLine($"{project.Id}\t{project.LongName}\t{project.ClientId}"); }
        }
        static void UpdateProject(List<Project> ProjectList, List<Client> ClientList)
        {
            // If Empty, return
            if (ProjectList.Count == 0) { System.Console.WriteLine("\nNo Registered Projects\n"); return; }

            // Get Client ID
            System.Console.WriteLine("\nEnter the Project ID to Update: ");
            int id = Convert.ToInt32(System.Console.ReadLine());

            // Update if Exists
            var idToUpdate = ProjectList.FirstOrDefault(x => x.Id == id);
            if (idToUpdate != null)
            {
                // Get New Name
                System.Console.WriteLine("Enter the Updated Short Project Name:");
                string shortName = System.Console.ReadLine() ?? string.Empty;

                System.Console.WriteLine("Enter the Updated Long Project Name:");
                string longName = System.Console.ReadLine() ?? string.Empty;

                // Get a Non-Unique Client ID
                System.Console.WriteLine("Enter the Updated Client ID:");
                int cID = Convert.ToInt32(System.Console.ReadLine());
                while (ValidID(ClientList, cID))
                {
                    System.Console.WriteLine("ID Does Not Exist. Please Enter a Valid Client ID:");
                    cID = Convert.ToInt32(System.Console.ReadLine());
                }
                idToUpdate.ShortName = shortName;
                idToUpdate.LongName = longName;
                idToUpdate.ClientId = cID;
                System.Console.WriteLine("\nSuccesfully Updated Project.\n");
            }
            else
            {
                System.Console.WriteLine("\nInvalid Project ID.\n");
            }
        }
        static void DeleteProject(List<Project> ProjectList)
        {
            // If empty, return
            if (ProjectList.Count == 0) { System.Console.WriteLine("\nNo Registered Projects\n"); return; }

            System.Console.WriteLine("\nEnter the Project ID to remove: ");
            int id = Convert.ToInt32(System.Console.ReadLine());

            // Check ID for a match
            var idToRemove = ProjectList.SingleOrDefault(project => project.Id == id);
            if (idToRemove != null)  // If Exists, Remove
            {
                ProjectList.Remove(idToRemove);
                System.Console.WriteLine("\nSuccesfully Removed Project\n");
            }
            else
            {
                System.Console.WriteLine("\nFailed To Remove Project\n");
            }
        }
        static void CreateClient(List<Client> ClientList)
        {
            // Get Client Info
            System.Console.WriteLine("Enter the Client ID:");
            int id = Convert.ToInt32(System.Console.ReadLine());
            while(!ValidID(ClientList,id))
            {
                System.Console.WriteLine("ID is Already In Use. Please Enter a Unique ID:");
                id = Convert.ToInt32(System.Console.ReadLine());
            }
            System.Console.WriteLine("Enter the Client Name:");
            string name = System.Console.ReadLine() ?? string.Empty;

            // Add Client to the List
            ClientList.Add(new Client() { Id = id, Name = name });
        }
        static void ReadClients(List<Client> ClientList)
        {
            // If List is Empty, return
            if(ClientList.Count == 0 ) { System.Console.WriteLine("\nNo Registered Clients\n"); return; }

            // Else, print the list
            System.Console.WriteLine("\nCurrently Registered Clients:\n");

            var queryClientList = ClientList.AsQueryable();
            foreach (var client in queryClientList) { System.Console.WriteLine($"{client.Id}\t{client.Name}"); }
        }
        static void UpdateClient(List<Client> ClientList)
        {
            // If Empty, return
            if (ClientList.Count == 0) { System.Console.WriteLine("\nNo Registered Clients\n"); return; }

            // Get Client ID
            System.Console.WriteLine("\nEnter the Client ID to Update: ");
            int id = Convert.ToInt32(System.Console.ReadLine());

            // Update if Exists
            var idToUpdate = ClientList.FirstOrDefault(x => x.Id == id);
            if (idToUpdate != null)
            {
                System.Console.WriteLine("Enter New Client Name:");
                string name = System.Console.ReadLine() ?? string.Empty;
                idToUpdate.Name = name;
                System.Console.WriteLine("\nSuccesfully Updated Client Name.\n");
            }
            else
            { 
                System.Console.WriteLine("\nInvalid Client ID.\n");
            }
        }
        static void DeleteClient(List<Client> ClientList)
        {
            // If empty, return
            if (ClientList.Count == 0) { System.Console.WriteLine("\nNo Registered Clients\n"); return; }

            System.Console.WriteLine("\nEnter the Client ID to remove: ");
            int id = Convert.ToInt32(System.Console.ReadLine());

            // Check ID for a match
            var idToRemove = ClientList.SingleOrDefault(client =>  client.Id == id);
            if (idToRemove != null)  // If Exists, Remove
            {
                ClientList.Remove(idToRemove);
                System.Console.WriteLine("\nSuccesfully Removed Client\n");
            }
            else
            {
                System.Console.WriteLine("\nFailed To Remove Client\n");
            }
        }
        static void PrintMenu()
        {
            System.Console.WriteLine("------------------------------------------------");
            System.Console.WriteLine("Enter An Option Below (Press ctrl + c to Exit):");
            System.Console.WriteLine("A) Create New Client");
            System.Console.WriteLine("B) Print List Of Clinets");
            System.Console.WriteLine("C) Update A Client");
            System.Console.WriteLine("D) Delete A Client");
            System.Console.WriteLine("E) Create New Project");
            System.Console.WriteLine("F) Print List of Projects");
            System.Console.WriteLine("G) Update a Project");
            System.Console.WriteLine("H) Delete a Project");
            System.Console.WriteLine("------------------------------------------------");
        }
        static string GetOption()
        {
            string option = "";
            option = System.Console.ReadLine() ?? string.Empty;
            while (!ValidOption(option))
            {
                System.Console.WriteLine("Invalid Option. Please Enter an Option Above.");
                option = System.Console.ReadLine() ?? string.Empty;
            }
            return option;
        }
        // Check For Valid Menu Option
        static bool ValidOption(string option)
        {
            // If no character or more than one, return false
            if (option == null || option.Length > 1)
                return false;

            // Convert char to ascii
            option = option.ToLower();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(option);

            // If outside of this range, it was not an option
            if (asciiBytes[0] < 97 || asciiBytes[0] > 104)
                return false;

            return true;
        }
        // Check for a Unique ID
        static bool ValidID(List<Client> ClientList,int id)
        {
            var idToCheck = ClientList.SingleOrDefault(client => client.Id == id);

            if (idToCheck != null)  // If ID exists, return false
                return false;
            
            return true;
        }
        // Check for a Unique Project ID
        static bool ValidPID(List<Project> ProjectList, int id)
        {
            var idToCheck = ProjectList.SingleOrDefault(project => project.Id == id);

            if (idToCheck != null)  // If ID exists, return false
                return false;

            return true;
        }
    }
}