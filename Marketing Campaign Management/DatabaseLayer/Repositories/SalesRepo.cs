using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLayer.Interfaces;

namespace DatabaseLayer.Repositories

 public class SalesRepo : ISalesRepo
 { 
    SqlCommand command = null;
    SqlDataAdapter dataAdapter = null;

    public bool CreateSales(Sales sales)
    {
        try
        {
            command = new SqlCommand()
            {
                CommandText = "CreateSales",
                CommandType = CommandType.StoredProcedure,
                Connection = Connection.connection
            };

            command.Parameters.AddWithValue("@leadid", sales.SalesLeadID);
            command.Parameters.AddWithValue("@shippingaddress", sales.SalesShippingAddress);
            command.Parameters.AddWithValue("@billingaddress", sales.SalesBillingAddress);
            command.Parameters.AddWithValue("@createdon", sales.CreatedDate);
            command.Parameters.AddWithValue("@paymentmode", sales.PaymentMode);
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

    public List<Sales> ViewSales()
    {
        try
        {
            List<Sales> sales = null;
            command = new SqlCommand()
            {
                CommandText = "ViewSales",
                CommandType = CommandType.StoredProcedure,
                Connection = Connection.connection
            };

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
                             CreatedDate = Convert.ToDateTime(dataRow["createddate"]),
                             PaymentMode = dataRow["paymentmode"].ToString()
                         }
                         );
                        
                }


            }
            return sales;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

 }
}