using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DatabaseLayer.DBException;

namespace DatabaseLayer.Repositories
{
    public class Sessions
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCMConnection"].ConnectionString);
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;
        public bool DbValidation(string logID, string password)
        {
            try
            {
                SessionDetails session = null;
                connection.Open();
                command = new SqlCommand()
                {
                    CommandText = "Session",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection

                };
                command.Parameters.AddWithValue("@LoginID", logID);
                command.Parameters.AddWithValue("@Password", password);
                dataAdapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable("Users");
                dataAdapter.Fill(datatable);
                if (datatable.Rows.Count > 0)
                {
                    DataRow datarow = datatable.Rows[0];
                    session = new SessionDetails()
                    {
                        UserID = Convert.ToInt32(datarow["UserID"]),
                        FullName = datarow["FullName"].ToString(),
                        LoginID = datarow["LoginID"].ToString(),
                        IsAdmin = Convert.ToByte(datarow["IsAdmin"])
                    };
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool DbAdminCheck(SessionDetails session)
        {
            try
            {
                if (session.IsAdmin == 1)
                {
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return false;
            }

        }
    }
}
