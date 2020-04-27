using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class TypeModel
    {
        public string ConnectionString { get; set; }
        public TypeModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public void AddType(CustomType type)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into types (type) values (@type)", conn);
                cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = type.type;
                var num = cmd.ExecuteNonQuery();
            }
        }
        public List<CustomType> GetTypes()

        {
            List<CustomType> list = new List<CustomType>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from types", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CustomType() { Id = Convert.ToInt32(reader["id"]), type = Convert.ToString(reader["type"]) });
                    }
                }
            }
            return list;
        }

        public void RemoveType(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from types where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                var num = cmd.ExecuteNonQuery();
            }
        }
        public void UpdateType(int id, CustomType newType)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update types set type=@type where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = newType.type;
                var num = cmd.ExecuteNonQuery();
            }
        }
    }
}
