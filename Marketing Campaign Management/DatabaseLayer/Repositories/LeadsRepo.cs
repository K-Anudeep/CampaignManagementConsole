using System;
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
    class LeadsRepo : ILeadsRepo
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
                command.Parameters.AddWithValue("@Status", leads.Status);
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
                Connection.Open();
                command = new SqlCommand()
                {
                    CommandText = "GetLeadByLeadID",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@LeadID", LeadID);
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
                    leads.PreferredMoC = reader["PrefferedMoC"].ToString();
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

        public List<Leads> ViewLeads()
        {
            try
            {
                List<Leads> leads = null;
                command = new SqlCommand()
                {
                    CommandText = "ViewLeads",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };

                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Leads");
                if (dataSet.Tables["Leads"].Rows.Count > 0)
                {
                    leads = new List<Leads>();
                    foreach (DataRow dataRow in dataSet.Tables["Leads"].Rows)
                    {
                        leads.Add(
                             new Leads()
                             {
                                 LeadID = (int)dataRow["LeadID"],
                                 CampaignID = (int)dataRow["CampaignID"],
                                 ConsumerName = dataRow["ConsumerName"].ToString(),
                                 Status = dataRow["Status"].ToString(),
                                 ProductID = (int)dataRow["ProductID"],
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
        }

    }
}




