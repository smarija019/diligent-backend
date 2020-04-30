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
        public MySqlConnection conn { get; set; }
        public LocationModel(string connectionString)
        {
            this.ConnectionString = connectionString;
            conn = GetConnection();
            conn.Open();
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
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = location.location;
                var num = cmd.ExecuteNonQuery();
                conn.Close();
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
                        list.Add(new Location() { Id = Convert.ToInt32(reader["id"]), location = Convert.ToString(reader["location"]) });
                    }
                }
                conn.Close();
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
                conn.Close();
            }
        }
        public void UpdateLocation(int id, Location newLocation)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update locations set location=@name where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = newLocation.location;
                var num = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
