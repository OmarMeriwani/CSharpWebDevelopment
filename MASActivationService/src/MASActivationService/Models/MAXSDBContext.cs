using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.DataProtection;
using MySql.Data.MySqlClient;

namespace MASActivationService.Models
{
    public class MAXSDBContext 
    {
        IDataProtector _protector;
        public string ConnectionString { get; set; }
        public MAXSDBContext( IDataProtectionProvider provider, string connectionString)
        {
            this.ConnectionString = connectionString;
            _protector = provider.CreateProtector("MAXSDBProtection");
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public bool CheckLicense(string key, int ApplicationID, string PCNO, string email, string phoneNumber, string activationuser, string IP)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                using (conn)
                {
                    conn.Open();
                    MySqlCommand comnd = new MySqlCommand("sp_checklicense", conn);
                    comnd.CommandType = CommandType.StoredProcedure;
                    comnd.Parameters.AddWithValue("p_ActivationKey", key);
                    comnd.Parameters.AddWithValue("p_SoftwareID", ApplicationID);
                    comnd.Parameters.AddWithValue("p_PCNO", PCNO);
                    comnd.Parameters.AddWithValue("p_email", email);
                    comnd.Parameters.AddWithValue("p_phonenumber", phoneNumber);
                    comnd.Parameters.AddWithValue("p_activationuser", activationuser);
                    comnd.Parameters.AddWithValue("p_IP", IP);
                    comnd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool Register(string key, int ApplicationID, string PCNO, string email, string phoneNumber, string activationuser, string IP)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                using (conn)
                {
                    conn.Open();
                    MySqlCommand comnd = new MySqlCommand("sp_register", conn);
                    comnd.CommandType = CommandType.StoredProcedure;
                    comnd.Parameters.AddWithValue("p_ActivationKey", key);
                    comnd.Parameters.AddWithValue("p_SoftwareID", ApplicationID);
                    comnd.Parameters.AddWithValue("p_PCNO", PCNO);
                    comnd.Parameters.AddWithValue("p_email", email);
                    comnd.Parameters.AddWithValue("p_phonenumber", phoneNumber);
                    comnd.Parameters.AddWithValue("p_activationuser", activationuser);
                    comnd.Parameters.AddWithValue("p_IP", IP);
                    comnd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ResetKey(string key, int ApplicationID)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                using (conn)
                {
                    conn.Open();
                    MySqlCommand comnd = new MySqlCommand("sp_reset_key", conn);
                    comnd.CommandType = CommandType.StoredProcedure;
                    comnd.Parameters.AddWithValue("p_ActivationKey", key);
                    comnd.Parameters.AddWithValue("p_SoftwareID", ApplicationID);
                    comnd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
