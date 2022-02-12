using SimpleWebApi.Models;

namespace SimpleWebApi.Abstraction
{
    public interface IUsers
    {
        public Task<string> Insert(string name);
        public Task<string> Update(int id , string name);

        public Task<string> Delete(int id);

        public Task<List<Users>> ReadAll();

        public Task<Users> ReadUser(int id);
    }
}
