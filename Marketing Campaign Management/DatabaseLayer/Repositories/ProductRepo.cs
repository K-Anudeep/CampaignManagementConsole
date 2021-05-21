using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace DatabaseLayer.Repositories
{
	public class ProductRepo : IProductsRepo
    {
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;

        public bool AddProduct(Products product)
        {
            try
            {
                command = new SqlCommand();
                {
                    CommandText = "AddProduct",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@productid", product.ProductID);
                command.Parameters.AddWithValue("@productname", product.ProductName);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@unitprice", product.UnitPrice);
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
       
        public List<Products> DisplayProducts()
        {
            try
            {
                List<Products> products = null;
                command = new SqlCommand()
                {
                    CommandText = "DisplayProducts",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };

                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Product");
                if (dataSet.Tables["Product"].Rows.Count > 0)
                {
                    employees = new List<Products>();
                    foreach (DataRow dataRow in dataSet.Tables["Product"].Rows)
                    {
                        employees.Add(
                             new Product()
                             {
                                 ProductID = (int)dataRow["ProductID"],
                                 ProductName = dataRow["ProductName"].ToString(),
                                 Description = dataRow["Description"].ToString(),
                                 UnitPrice= (decimal)dataRow["UnitPrice"],
                             }
                            );
                    }


                }
                return employees;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Products OneProduct(int pId)
        {
            try
            {
                Product product = null;
                command = new SqlCommand()
                {
                    CommandText = "OneProductByProductID",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@productid",ProductId);
                dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Product");
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    employee = new Product()
                    {
                        ProductName = dataRow["ProductName"].ToString(),
                        Description = dataRow["Description"].ToString(),
                        UnitPrice = (decimal)dataRow["UnitPrice"],
                    };
                }
                return employee;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool DeleteProduct(int pID)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "DeleteProduct",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@productid", ProductID);
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