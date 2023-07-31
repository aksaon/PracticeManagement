using PracticeManagement.API.Database;
using PracticeManagement.CLI.Models;
using PracticeManagement.Library.DTO;

namespace PracticeManagement.API.EC
{
    public class ClientEC
    {
        public ClientDTO AddOrUpdate(ClientDTO dto)
        {
            Filebase.Current.AddOrUpdate(new Client(dto));
            return dto;
        }

        public ClientDTO? Get(int id)
        {
            return new ClientDTO(Filebase.Current.Get(id));
        }

        public ClientDTO? Delete(int id)
        {
            if(Filebase.Current.Delete(id.ToString()))
            {
                return null;
            }
            return new ClientDTO(Filebase.Current.Get(id));
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
            return Filebase.Current.Search(query).Select(c => new ClientDTO(c));
        }
    }
}