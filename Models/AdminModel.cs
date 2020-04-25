using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class AdminModel
    {
        public string ConnectionString { get; set; }
        public AdminModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        
        #region Methods for entity Location
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
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value =id;
                var num = cmd.ExecuteNonQuery();


            }

        }
        #endregion


       
        #region Methods for entity CustomType

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
        #endregion

        
        #region Methods for entity Contact

        public void AddContact(Contact contact)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into contacts (name, tel1, tel2, address, email, flag, profession, company) values (@name, @tel1, @tel2, @address, @email, @flag, @profession, @company)", conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = contact.name;
                cmd.Parameters.Add("@tel1", MySqlDbType.VarChar).Value = contact.tel1;
                cmd.Parameters.Add("@tel2", MySqlDbType.Int32).Value = contact.tel2;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = contact.address;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = contact.email;
                cmd.Parameters.Add("@flag", MySqlDbType.VarChar).Value = contact.flag;
                cmd.Parameters.Add("@profession", MySqlDbType.Int32).Value = contact.profession;
                cmd.Parameters.Add("@company", MySqlDbType.VarChar).Value = contact.company;
                var num = cmd.ExecuteNonQuery();

            }
        }
        public List<Contact> GetContacts()

        {
            List<Contact> list = new List<Contact>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from contacts", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Contact() { Id = Convert.ToInt32(reader["id"]), name = Convert.ToString(reader["name"]), tel1 = Convert.ToString(reader["tel1"]), tel2 = Convert.ToString(reader["tel2"]), address = Convert.ToString(reader["address"]), email = Convert.ToString(reader["email"]), flag = Convert.ToInt32(reader["flag"]), profession = Convert.ToString(reader["profession"]), company= Convert.ToInt32(reader["company"]) });
                    }
                }
            }
            return list;
        }

        public void RemoveContact(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from contacts where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                var num = cmd.ExecuteNonQuery();


            }

        }
        #endregion

       
        #region Methods for entity Company

        public void AddCompany(Company company)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into companies (name, address) values (@name, @address)", conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = company.name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = company.address;
                var num = cmd.ExecuteNonQuery();

            }
        }
        public List<Company> GetCompanies()

        {
            List<Company> list = new List<Company>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from companies", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Company() { Id = Convert.ToInt32(reader["id"]), name = Convert.ToString(reader["name"]), address = Convert.ToString(reader["address"]) });
                    }
                }
            }
            return list;
        }

        public void RemoveCompany(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from companies where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                var num = cmd.ExecuteNonQuery();


            }

        }
        #endregion 

    }
}
