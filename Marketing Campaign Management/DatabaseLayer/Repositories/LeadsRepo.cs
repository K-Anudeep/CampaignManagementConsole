﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Interfaces;
using System.Data.SqlClient;
using Entities;
using System.Data;

namespace DatabaseLayer.Repositories
{
    public class LeadsRepo : ILeadsRepo
    {
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;


        public bool AddLeads(Leads leads)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "AddLeads",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection

                };
                command.Parameters.AddWithValue("@CampaignID", leads.CampaignID);
                command.Parameters.AddWithValue("@ConsumerName", leads.ConsumerName);
                command.Parameters.AddWithValue("@EMailAddress", leads.EmailAddress);
                command.Parameters.AddWithValue("@PhoneNo", leads.PhoneNo);
                command.Parameters.AddWithValue("@PreferredMoC", leads.PreferredMoC);
                command.Parameters.AddWithValue("@DateApproached", leads.DateApproached);
                command.Parameters.AddWithValue("@ProductID", leads.ProductID);
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

        public Leads GetALead(int LeadID)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "GetLeadByLeadID",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@LeadID", LeadID);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Leads leads = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    leads = new Leads();
                    leads.CampaignID = Convert.ToInt32(reader["CampaignID"]);
                    leads.ConsumerName = reader["ConsumerName"].ToString();
                    leads.EmailAddress = reader["EMailAddress"].ToString();
                    leads.PhoneNo = reader["PhoneNo"].ToString();
                    leads.PreferredMoC = reader["PreferredMoC"].ToString();
                    leads.DateApproached = Convert.ToDateTime(reader["DateApproached"]);
                    leads.ProductID = Convert.ToInt32(reader["ProductID"]);
                    leads.Status = reader["Status"].ToString();
                }
                return leads;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool CheckLead(int LeadID)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "CheckLead",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@CampaignID", LeadID);
                IDbDataParameter val = command.CreateParameter();
                val.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(val);
                Connection.Open();
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
            finally
            {
                Connection.Close();
            }
        }

        public bool FollowLead(int leadID, string newStatus)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "FollowLead",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection

                };
                command.Parameters.AddWithValue("@LeadID", leadID);
                command.Parameters.AddWithValue("@Status", newStatus);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Leads> ViewLeadsToExec()
        {
            try
            {
                Connection.Open();
                List<Leads> leads = null;
                command = new SqlCommand()
                {
                    CommandText = "ViewLeadsToExecutive",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                SessionDetails session = new SessionDetails();
                command.Parameters.AddWithValue("@UserID", session.UserID);
                command.ExecuteNonQuery();
                dataAdapter = new SqlDataAdapter(command);
                DataTable leadTable = new DataTable();
                dataAdapter.Fill(leadTable);
                if (leadTable.Rows.Count > 0)
                {
                    leads = new List<Leads>();
                    foreach (DataRow dataRow in leadTable.Rows)
                    {
                        leads.Add(
                             new Leads()
                             {
                                 LeadID = Convert.ToInt32(dataRow["LeadID"]),
                                 CampaignID = Convert.ToInt32(dataRow["CampaignID"]),
                                 ConsumerName = dataRow["ConsumerName"].ToString(),
                                 EmailAddress = dataRow["EmailAddress"].ToString(),
                                 PhoneNo = dataRow["PhoneNo"].ToString(),
                                 PreferredMoC = dataRow["PreferredMoC"].ToString(),
                                 Status = dataRow["Status"].ToString(),
                                 ProductID = Convert.ToInt32(dataRow["ProductID"]),
                                 DateApproached = Convert.ToDateTime(dataRow["DateApproached"])
                             }
                            );
                    }
                }
                return leads;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Leads> ViewLeadsByCampaign(int cId)
        {
            try
            {
                Connection.Open();
                List<Leads> leads = null;
                command = new SqlCommand()
                {
                    CommandText = "ViewLeadsByCampaign",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                SessionDetails session = new SessionDetails();
                command.Parameters.AddWithValue("@CampaignID", cId);
                command.ExecuteNonQuery();
                dataAdapter = new SqlDataAdapter(command);
                DataTable leadTable = new DataTable();
                dataAdapter.Fill(leadTable);
                if (leadTable.Rows.Count > 0)
                {
                    leads = new List<Leads>();
                    foreach (DataRow dataRow in leadTable.Rows)
                    {
                        leads.Add(
                             new Leads()
                             {
                                 LeadID = Convert.ToInt32(dataRow["LeadID"]),
                                 CampaignID = Convert.ToInt32(dataRow["CampaignID"]),
                                 ConsumerName = dataRow["ConsumerName"].ToString(),
                                 EmailAddress = dataRow["EmailAddress"].ToString(),
                                 PhoneNo = dataRow["PhoneNo"].ToString(),
                                 PreferredMoC = dataRow["PreferredMoC"].ToString(),
                                 Status = dataRow["Status"].ToString(),
                                 ProductID = Convert.ToInt32(dataRow["ProductID"]),
                                 DateApproached = Convert.ToDateTime(dataRow["DateApproached"])
                             }
                            );
                    }
                }
                return leads;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

    }
}




