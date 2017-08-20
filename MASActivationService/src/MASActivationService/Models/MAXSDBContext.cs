using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace MASActivationService.Models
{
    public class MAXSDBContext 
    {
        public string ConnectionString { get; set; }
        public MAXSDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public bool AddNewKey(string key, int ApplicationID)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                using (conn)
                {
                    conn.Open();
                    MySqlCommand comnd = new MySqlCommand("sp_add_new_key", conn);
                    comnd.CommandType = CommandType.StoredProcedure;
                    comnd.Parameters.AddWithValue("p_ActivationKey", key);
                    comnd.Parameters.AddWithValue("p_SoftwareID", ApplicationID);
                    comnd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
