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

namespace DatabaseLayer.Repositories
{
    public class Sessions
    {
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;
        public bool DbValidation(string logID, string password)
        {
            try
            {
                SessionDetails session = null;
                command = new SqlCommand()
                {
                    CommandText = "Session",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection

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
                return false;
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
                return false;
            }

        }
    }
}
