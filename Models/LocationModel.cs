using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class LocationModel
    {
        public string ConnectionString { get; set; }
        public LocationModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public void AddLocation(Location location)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into locations (location) values (@name)", conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = location.LocationName;
                var num = cmd.ExecuteNonQuery();

            }
        }
        public List<Location> GetLocations()

        {
            List<Location> list = new List<Location>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from locations", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Location() { Id = Convert.ToInt32(reader["id"]), LocationName = Convert.ToString(reader["location"]) });
                    }
                }
            }
            return list;
        }

        public void RemoveLocation(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from locations where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                var num = cmd.ExecuteNonQuery();


            }

        }
    }
}
