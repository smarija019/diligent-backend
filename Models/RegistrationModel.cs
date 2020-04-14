using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;


namespace diligent_backend.Models
{


    public class RegistrationModel
    {

        public string ConnectionString { get; set; }

        public RegistrationModel(string connectionString)
            {
                this.ConnectionString = connectionString;
            }
        private MySqlConnection GetConnection()
            {
                return new MySqlConnection(ConnectionString);
            }
        public void AddUser(User user)
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into users (first_name, last_name, role, password, username) values (@first_name, @last_name, @role, @password, @username)", conn);
                    cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = user.fname;
                    cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = user.lname;
                    cmd.Parameters.Add("@role", MySqlDbType.Int32).Value = user.role;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = user.username;

                    var num = cmd.ExecuteNonQuery();

                }
            }
        public List<User> GetTest()

            { 
                List<User> list = new List<User>();
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from users", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new User() { Id = Convert.ToInt32(reader["id"]) });
                        }
                    }
                }
                return list;
            }
    }
}
