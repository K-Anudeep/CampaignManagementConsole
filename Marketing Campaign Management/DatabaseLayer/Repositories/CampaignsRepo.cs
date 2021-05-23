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
    public class CampaignsRepo : ICampaignsRepo
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
                command.Parameters.AddWithValue("@CampaignId", cId);
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
                                 CampaignID = (int)dataRow["CampaignID"],
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
                SessionDetails session = new SessionDetails();
                command.Parameters.AddWithValue("@UserID", session.UserID);
                Connection.Open();
                command.ExecuteNonQuery();
                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "CampaignsByAssigned");
                if (dataSet.Tables["CampaignsByAssigned"].Rows.Count > 0)
                {
                    campaigns = new List<Campaigns>();
                    foreach (DataRow dataRow in dataSet.Tables["CampaignsByAssigned"].Rows)
                    {
                        campaigns.Add(
                             new Campaigns()
                             {
                                 CampaignID = Convert.ToInt32(dataRow["CampaignID"]),
                                 Name = dataRow["Name"].ToString(),
                                 Venue = dataRow["Venue"].ToString(),
                                 AssignedTo = (int)dataRow["AssignedTo"],
                                 StartedOn = (DateTime)(dataRow["StartedOn"]),
                                 //CompletedOn = Convert.ToDateTime(dataRow["CompletedOn"]),
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

        public bool CampaignStatusCheck(int cId)
        {
            try
            {
                SessionDetails sessionDetails = new SessionDetails();


                command = new SqlCommand()
                {
                    CommandText = "StatusCheck",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@CampaignID", cId);
                command.Parameters.AddWithValue("@AssignedTo", sessionDetails.UserID);
                IDbDataParameter val = command.CreateParameter();
                val.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(val);
                command.ExecuteNonQuery();
                int validate = Convert.ToInt32(val.Value);
                if (validate == 1)
                {
                    return true;
                }
                else
                    throw new Exception("Error: Campaign is either not assigned to you or it is closed!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
