using diligent_backend.Helpers;
using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class LawyerModel
    {
        public string ConnectionString { get; set; }
        public LawyerModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public void AddLawyer(Lawyer lawyer)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into lawyers (user_id, lawsuit_id) values (@user_id, @lawsuit_id)", conn);
                cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = lawyer.user_id;
                cmd.Parameters.Add("@lawsuit_id", MySqlDbType.Int32).Value = lawyer.lawsuit_id;
                var num = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        internal IEnumerable<LawyerForGet> GetMyLawyers(int id)
        {
            throw new NotImplementedException();
        }

        public List<LawyerForGet> GetLawyers()

        {
            List<LawyerForGet> list = new List<LawyerForGet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT aspnetusers.Id AS userId, aspnetusers.FirstName, aspnetusers.LastName, lawsuits.procedure_id , lawyers.id FROM lawyers INNER JOIN aspnetusers ON aspnetusers.id=lawyers.user_id INNER JOIN lawsuits ON lawsuits.id=lawyers.lawsuit_id", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LawyerForGet() { Id = Convert.ToInt32(reader["id"]), userId = Convert.ToString(reader["userId"]), firstName = Convert.ToString(reader["FirstName"]), lastName = Convert.ToString(reader["LastName"]), procedure_id = Convert.ToString(reader["procedure_id"]) });     }
                }
                conn.Close();
            }
            return list;
        }

        public List<LawyerForGet> GetMyLawyers(string id)

        {
            List<LawyerForGet> list = new List<LawyerForGet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT aspnetusers.Id AS userId, aspnetusers.FirstName, aspnetusers.LastName, lawsuits.procedure_id , lawyers.id FROM lawyers INNER JOIN aspnetusers ON aspnetusers.id=lawyers.user_id INNER JOIN lawsuits ON lawsuits.id=lawyers.lawsuit_id WHERE aspnetusers.Id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LawyerForGet() { Id = Convert.ToInt32(reader["id"]), userId = Convert.ToString(reader["userId"]), firstName = Convert.ToString(reader["FirstName"]), lastName = Convert.ToString(reader["LastName"]), procedure_id = Convert.ToString(reader["procedure_id"]) });
                    }
                }
                conn.Close();
            }
            return list;
        }
        public void RemoveLawyer(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from lawyers where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                var num = cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        public void UpdateLawyer(int id, Lawyer newLawyer)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update lawyers set user_id=@user_id, lawsuit_id=@lawsuit_id where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@user_id", MySqlDbType.Int32).Value = newLawyer.user_id;
                cmd.Parameters.Add("@lawsuit_id", MySqlDbType.Int32).Value = newLawyer.lawsuit_id;
                var num = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
