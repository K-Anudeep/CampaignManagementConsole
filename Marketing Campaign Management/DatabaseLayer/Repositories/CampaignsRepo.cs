using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseLayer.Repositories
{
   public class CampaignsRepo :ICampaignsRepo
    {
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;

        public bool AddCampaign(Campaigns campaigns)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "AddCampaign",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@name", campaigns.Name);
                command.Parameters.AddWithValue("@venue", campaigns.Venue);
                command.Parameters.AddWithValue("@assignedto", campaigns.AssignedTo);
                command.Parameters.AddWithValue("@staron", campaigns.StartedOn);
                command.Parameters.AddWithValue("@completedon", campaigns.CompletedOn);
                command.Parameters.AddWithValue("@isopen", campaigns.IsOpen);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool CloseCampaign(int cId)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "CloseCampaign",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@cid",cId);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
        }



    }
}
