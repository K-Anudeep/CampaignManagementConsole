using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Interfaces;
using System.Data.SqlClient;
using Entities;
using System.Data;
using System.Configuration;
using DatabaseLayer.DBException;

namespace DatabaseLayer.Repositories
{
    public class SalesRepo : ISalesRepo
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCMConnection"].ConnectionString);
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;

        public bool CreateSales(Sales sales)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "AddSales",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                command.Parameters.AddWithValue("@leadid", sales.LeadID);
                command.Parameters.AddWithValue("@shippingaddress", sales.ShippingAddress);
                command.Parameters.AddWithValue("@billingaddress", sales.BillingAddress);
                command.Parameters.AddWithValue("@paymentmode", sales.PaymentMode);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
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

        public List<Sales> ViewSales()
        {
            try
            {
                List<Sales> sales = null;
                command = new SqlCommand()
                {
                    CommandText = "VIEWSALES",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                connection.Open();
                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Sales");
                if (dataSet.Tables["Sales"].Rows.Count > 0)
                {
                    sales = new List<Sales>();
                    foreach (DataRow dataRow in dataSet.Tables["Sales"].Rows)
                    {
                        sales.Add(
                             new Sales()
                             {
                                 OrderID = (int)dataRow["orderid"],
                                 LeadID = (int)dataRow["leadid"],
                                 ShippingAddress = dataRow["shippingaddress"].ToString(),
                                 BillingAddress = dataRow["billingaddress"].ToString(),
                                 CreatedON = Convert.ToDateTime(dataRow["createdon"]),
                                 PaymentMode = dataRow["paymentmode"].ToString()
                             }
                             );
                    }
                }
                return sales;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExceptionLogging.WriteLog(ex);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}