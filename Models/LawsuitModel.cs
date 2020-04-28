using diligent_backend.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class LawsuitModel
    {
        public string ConnectionString { get; set; }
        public LawsuitModel(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public void AddLawsuit(Lawsuit lawsuit)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into lawsuits (date, location, judge, inst_type, procedure_id, courtroom, plaintiff, defendant, note, procedure_type) values (@date, @location, @judge, @inst_type, @procedure_id, @courtroom, @plaintiff, @defendant, @note, @procedure_type)", conn);
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = lawsuit.date;
                cmd.Parameters.Add("@location", MySqlDbType.Int32).Value = lawsuit.location ;
                cmd.Parameters.Add("@judge", MySqlDbType.Int32).Value = lawsuit.judge;
                cmd.Parameters.Add("@inst_type", MySqlDbType.VarChar).Value = lawsuit.inst_type;
                cmd.Parameters.Add("@procedure_id", MySqlDbType.VarChar).Value = lawsuit.procedure_id;
                cmd.Parameters.Add("@courtroom", MySqlDbType.Int32).Value = lawsuit.courtroom;
                cmd.Parameters.Add("@plaintiff", MySqlDbType.Int32).Value = lawsuit.plaintiff;
                cmd.Parameters.Add("@defendant", MySqlDbType.Int32).Value = lawsuit.defendant;
                cmd.Parameters.Add("@note", MySqlDbType.VarChar).Value = lawsuit.note;
                cmd.Parameters.Add("@procedure_type", MySqlDbType.VarChar).Value = lawsuit.procedure_type;
                var num = cmd.ExecuteNonQuery();
            }
        }
        public List<LawsuitForGet> GetLawsuits()

        {
            List<LawsuitForGet> list = new List<LawsuitForGet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT *, locations.location AS lawsuit_location, types.type AS lawsuit_type, judges.name AS law_judge, plaintiffs.name AS law_plaintiff, defendants.name AS law_defendant FROM `lawsuits` INNER JOIN types ON types.id=lawsuits.procedure_type INNER JOIN locations ON locations.id=lawsuits.location INNER JOIN contacts judges ON judges.id=lawsuits.judge INNER JOIN contacts plaintiffs ON plaintiffs.id=lawsuits.plaintiff INNER JOIN contacts defendants ON defendants.id=lawsuits.defendant", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LawsuitForGet() { Id = Convert.ToInt32(reader["id"]), date = Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd"), time = Convert.ToDateTime(reader["date"]).ToString("HH:mm:ss"), location = Convert.ToString(reader["lawsuit_location"]), judge = Convert.ToString(reader["law_judge"]),  inst_type= Convert.ToString(reader["inst_type"]), procedure_id = Convert.ToString(reader["procedure_id"]), courtroom = Convert.ToInt32(reader["courtroom"]), plaintiff = Convert.ToString(reader["law_plaintiff"]), defendant = Convert.ToString(reader["law_defendant"]), note = Convert.ToString(reader["note"]), procedure_type = Convert.ToString(reader["lawsuit_type"]) });
                    }
                }
            }
            return list;
        }

        public void RemoveLawsuit(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from lawsuits where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                var num = cmd.ExecuteNonQuery();
            }

        }
        public void UpdateLawsuit(int id, Lawsuit newLawsuit)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update lawsuits set date=@date, location=@location, judge=@judge, inst_type=@inst_type, procedure_id=@procedure_id, courtroom=@courtroom, plaintiff=@plaintiff, defendant=@defendant, note=@note, procedure_type=@procedure_type where id=@id", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = newLawsuit.date;
                cmd.Parameters.Add("@location", MySqlDbType.Int32).Value = newLawsuit.location;
                cmd.Parameters.Add("@judge", MySqlDbType.Int32).Value = newLawsuit.judge;
                cmd.Parameters.Add("@inst_type", MySqlDbType.VarChar).Value = newLawsuit.inst_type;
                cmd.Parameters.Add("@procedure_id", MySqlDbType.VarChar).Value = newLawsuit.procedure_id;
                cmd.Parameters.Add("@courtroom", MySqlDbType.Int32).Value = newLawsuit.courtroom;
                cmd.Parameters.Add("@plaintiff", MySqlDbType.Int32).Value = newLawsuit.plaintiff;
                cmd.Parameters.Add("@defendant", MySqlDbType.Int32).Value = newLawsuit.defendant;
                cmd.Parameters.Add("@note", MySqlDbType.VarChar).Value = newLawsuit.note;
                cmd.Parameters.Add("@procedure_type", MySqlDbType.VarChar).Value = newLawsuit.procedure_type;
                var num = cmd.ExecuteNonQuery();
            }
        }
    }
}
