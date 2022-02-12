using MySql.Data.MySqlClient;
using SimpleWebApi.Models;

namespace SimpleWebApi.Abstraction
{
    public class UsersImplementation : IUsers
    {
        private readonly MySqlConnection mySqlConnection;

        public UsersImplementation()
        {
            mySqlConnection = new MySqlConnection("Server=localhost;Port=3308;Database=users;Uid=root;Pwd=serverpassword;");
         
        }

        public async Task<string> Insert(string name)
        {
            try
            {
                using (mySqlConnection)
                {
                 
                    string sql = "insert into users_data (name) values ('" + name + "')";
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                    var execute_command = await mySqlCommand.ExecuteNonQueryAsync();
                    return execute_command.ToString();

                }
            }
            catch (Exception ex)
            {

               return ex.Message;
            }
        }


        public async Task<string> Delete(int id)
        {
            try
            {
                using (mySqlConnection)
                {
                    string sql = "delete from users_data where id =  " + id + " ";
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                    var deleted_check = await mySqlCommand.ExecuteNonQueryAsync();
                    return deleted_check.ToString();

                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        

        public async Task<List<Users>> ReadAll()
        {
            try
            {
                using (mySqlConnection)
                {
                    string sql = "select * from users_data";
                 
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                    var all_data = await mySqlCommand.ExecuteReaderAsync();
                    List<Users> users = new List<Users>();
                    while (all_data.Read())
                    {
                        users.Add(new Users
                        {
                            id = Convert.ToInt32(all_data["id"]),
                            name =  Convert.ToString(all_data["Name"])
                           
                        });
                    }
                    return users;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> Update(int id , string name)
        {
            try
            {
                using (mySqlConnection)
                {
                    string sql = "update users_data set name  = '" + name + "' where id = " + id + " ";
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                    var update_query = await mySqlCommand.ExecuteNonQueryAsync();
                    return update_query.ToString();

;                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<Users> ReadUser(int id)
        {
            try
            {
                using (mySqlConnection)
                {
                    string sql = "select * from users_data  where id = " + id + " ";
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                    var all_data = await mySqlCommand.ExecuteReaderAsync();
                    Users users = null;
                    while (all_data.Read())
                    {
                        users = new Users
                        {
                            id = Convert.ToInt32(all_data["id"]),
                            name = Convert.ToString(all_data["Name"])

                        };
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
