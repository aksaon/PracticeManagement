using Newtonsoft.Json;
using PracticeManagement.API.EC;
using PracticeManagement.Library.Models;
using PracticeManagement.CLI.Models;
using System.Net;

namespace PracticeManagement.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _clientRoot;
        private static Filebase? _instance;
        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            // change with proper directory or create this directory
            // ex: C:\temp\Clients
            _root = @"C:\temp";
            _clientRoot = $"{_root}\\Clients";
            //TODO: add support for projects, employees, times, bills
        }
        private int LastClientId => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
        public Client AddOrUpdate(Client c)
        {
            //set up a new Id if one doesn't already exist
            if (c.Id <= 0)
            {
                c.Id = LastClientId + 1;
            }

            var path = $"{_clientRoot}\\{c.Id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(c));

            //return the item, which now has an id
            return c;
        }

        public List<Client> Clients
        {
            get
            {
                var root = new DirectoryInfo(_clientRoot);
                var _clients = new List<Client>();
                foreach (var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.
                        DeserializeObject<Client>
                        (File.ReadAllText(todoFile.FullName));
                    if (todo != null)
                    {
                        _clients.Add(todo);
                    }
                }
                return _clients;
            }
        }
        public Client Get(int id)
        {
            var path = $"{_clientRoot}\\{id}.json";

            //if the file exists
            if (File.Exists(path))
            {
                // return it as a client
                var returnVal = JsonConvert.DeserializeObject<Client>(File.ReadAllText(path));
                if (returnVal != null)
                    return returnVal;
            }
            return new Client();
        }

        public bool Delete(string id)
        {
            var path = $"{_clientRoot}\\{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
                return true;
            }
            return false;
        }

        public IEnumerable<Client> Search(string query)
        {
            return Clients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).Take(1000);
        }
    }

}
