using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class CompanyModel
    {
        public string ConnectionString { get; set; }
        public CompanyModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public void AddCompany(Company company)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into companies (name, address) values (@name, @address)", conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = company.name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = company.address;
                var num = cmd.ExecuteNonQuery();
                conn.Close();

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
                conn.Close();
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
                conn.Close();

            }

        }

        public void UpdateCompany(int id, Company newCompany)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update companies set name=@name, address=@address where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = newCompany.name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = newCompany.address;
                var num = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
