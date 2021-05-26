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
    public class ProductRepo : IProductsRepo
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MCMConnection"].ConnectionString);
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;

        public bool AddProducts(Products product)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "AddProduct",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                command.Parameters.AddWithValue("@productname", product.ProductName);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@unitprice", product.UnitPrice);
                connection.Open();
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
                connection.Close();
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
                    Connection = connection
                };

                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Product");
                if (dataSet.Tables["Product"].Rows.Count > 0)
                {
                    products = new List<Products>();
                    foreach (DataRow dataRow in dataSet.Tables["Product"].Rows)
                    {
                        products.Add(
                             new Products()
                             {
                                 ProductID = (int)dataRow["ProductID"],
                                 ProductName = dataRow["ProductName"].ToString(),
                                 Description = dataRow["Decription"].ToString(),
                                 UnitPrice = (decimal)dataRow["UnitPrice"],
                             }
                            );
                    }

                }
                return products;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Products OneProduct(int pId)
        {
            try
            {
                connection.Open();
                Products product = null;
                command = new SqlCommand()
                {
                    CommandText = "OneProduct",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                command.Parameters.AddWithValue("@productid", pId);
                dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("Product");
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    product = new Products()
                    {
                        ProductID = Convert.ToInt32(dataRow["ProductID"]),
                        ProductName = dataRow["ProductName"].ToString(),
                        Description = dataRow["Decription"].ToString(),
                        UnitPrice = Convert.ToDecimal(dataRow["UnitPrice"]),
                    };
                }
                return product;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
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
                    Connection = connection
                };
                command.Parameters.AddWithValue("@productid", pID);
                connection.Open();
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
               connection.Close();
            }
        }


    }
}