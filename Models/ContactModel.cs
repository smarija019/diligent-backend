using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class ContactModel
    {
        public string ConnectionString { get; set; }
        public MySqlConnection conn { get; set; }
        public ContactModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
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
                        list.Add(new Contact() { Id = Convert.ToInt32(reader["id"]), name = Convert.ToString(reader["name"]), tel1 = Convert.ToString(reader["tel1"]), tel2 = Convert.ToString(reader["tel2"]), address = Convert.ToString(reader["address"]), email = Convert.ToString(reader["email"]), flag = Convert.ToInt32(reader["flag"]), profession = Convert.ToString(reader["profession"]), company = Convert.ToInt32(reader["company"]) });
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
        public void UpdateContact(int id, Contact newContact)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update contacts set name=@name, tel1=@tel1, tel2=@tel2, address=@address, email=@email, flag=@flag, profession=@profession, company=@company where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = newContact.name;
                cmd.Parameters.Add("@tel1", MySqlDbType.VarChar).Value = newContact.tel1;
                cmd.Parameters.Add("@tel2", MySqlDbType.Int32).Value = newContact.tel2;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = newContact.address;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = newContact.email;
                cmd.Parameters.Add("@flag", MySqlDbType.VarChar).Value = newContact.flag;
                cmd.Parameters.Add("@profession", MySqlDbType.Int32).Value = newContact.profession;
                cmd.Parameters.Add("@company", MySqlDbType.VarChar).Value = newContact.company;
                var num = cmd.ExecuteNonQuery();
            }
        }


    }
}
