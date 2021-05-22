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
                command.Parameters.AddWithValue("@Name", campaigns.Name);
                command.Parameters.AddWithValue("@Venue", campaigns.Venue);
                command.Parameters.AddWithValue("@AssignedTo", campaigns.AssignedTo);
                command.Parameters.AddWithValue("@StartedOn", campaigns.StartedOn);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
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
                command.Parameters.AddWithValue("@CampaignId",cId);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Campaigns> ViewCampaignsByExec()
        {
            try
            {
                List<Campaigns> campaigns = null;
                command = new SqlCommand()
                {
                    CommandText = "ViewCampaignByExec",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };

                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "CampaignsByExec");
                if (dataSet.Tables["CampaignsByExec"].Rows.Count > 0)
                {
                    campaigns = new List<Campaigns>();
                    foreach (DataRow dataRow in dataSet.Tables["CampaignsByExec"].Rows)
                    {
                        campaigns.Add(
                             new Campaigns()
                             {
                                 CampaignID = (int)dataRow["LeadID"],
                                 Name = dataRow["Name"].ToString(),
                                 Venue = dataRow["Venue"].ToString(),
                                 AssignedTo = (int)dataRow["AssignedTo"],
                                 StartedOn = (DateTime)(dataRow["StartedOn"]),
                                 CompletedOn = Convert.ToDateTime(dataRow["CompletedOn"]),
                                 IsOpen = (bool)dataRow["IsOpen"]
                             }
                            );
                    }
                }
                return campaigns;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Campaigns> ViewCampaignsByAssigned()
        {
            try
            {
                List<Campaigns> campaigns = null;
                command = new SqlCommand()
                {
                    CommandText = "ViewCampaignByAssigned",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };

                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "CampaignsByExec");
                if (dataSet.Tables["CampaignsByExec"].Rows.Count > 0)
                {
                    campaigns = new List<Campaigns>();
                    foreach (DataRow dataRow in dataSet.Tables["CampaignsByExec"].Rows)
                    {
                        campaigns.Add(
                             new Campaigns()
                             {
                                 CampaignID = (int)dataRow["LeadID"],
                                 Name = dataRow["Name"].ToString(),
                                 Venue = dataRow["Venue"].ToString(),
                                 AssignedTo = (int)dataRow["AssignedTo"],
                                 StartedOn = (DateTime)(dataRow["StartedOn"]),
                                 CompletedOn = Convert.ToDateTime(dataRow["CompletedOn"]),
                                 IsOpen = (bool)dataRow["IsOpen"]
                             }
                            );
                    }
                }
                return campaigns;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
