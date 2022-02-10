using SimpleWebApi.Models;

namespace SimpleWebApi.Abstraction
{
    public interface IUsers
    {
        public Task<string> Insert(string name);
        public string Update(int id , string name);

        public string Delete(int id);

        public Task<List<Users>> ReadAll();
    }
}
