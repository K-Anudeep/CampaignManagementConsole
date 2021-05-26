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
    public class UserRepo : IUsersRepo
    {
        SqlCommand command = null;
        SqlDataAdapter dataAdapter = null;
        public bool AddUsers(Users user)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "Add_Users",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@FullName", user.FullName);
                command.Parameters.AddWithValue("@LoginID", user.LoginID);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@DateOfJoin", user.DateOfJoin);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
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

        public bool DiscontinueUser(int uId)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "DiscontinueUser",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection
                };
                command.Parameters.AddWithValue("@UserID", uId);
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

        public List<Users> DisplayUsers()
        {
            try
            {
                List<Users> users = null;
                command = new SqlCommand()
                {
                    CommandText = "DisplayUsers",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection

                };
                dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Users");
                if (dataSet.Tables["Users"].Rows.Count > 0)
                {
                    users = new List<Users>();
                    foreach (DataRow datarow in dataSet.Tables["Users"].Rows)
                    {
                        users.Add(
                            new Users()
                            {
                                UserID = Convert.ToInt32(datarow["UserID"]),
                                FullName = datarow["FullName"].ToString(),
                                LoginID = datarow["LoginID"].ToString(),
                                Password = datarow["Password"].ToString(),
                                DateOfJoin = Convert.ToDateTime(datarow["DateOfJoin"]),
                                Discontinued = Convert.ToByte(datarow["Discontinued"]),
                                Address = datarow["Address"].ToString(),
                                IsAdmin = Convert.ToByte(datarow["IsAdmin"])

                            }
                            );

                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Users OneUser(int uId)
        {
            try
            {
                Users user = null;
                command = new SqlCommand()
                {
                    CommandText = "DisplayUsersByID",
                    CommandType = CommandType.StoredProcedure,
                    Connection = Connection.connection

                };
                command.Parameters.AddWithValue("@UserID", uId);
                dataAdapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable("Users");
                dataAdapter.Fill(datatable);
                if (datatable.Rows.Count > 0)
                {
                    DataRow datarow = datatable.Rows[0];
                    user = new Users()
                    {
                        UserID = Convert.ToInt32(datarow["UserID"]),
                        FullName = datarow["FullName"].ToString(),
                        LoginID = datarow["LoginID"].ToString(),
                        Password = datarow["Password"].ToString(),
                        DateOfJoin = Convert.ToDateTime(datarow["DateOfJoin"]),
                        Address = datarow["Address"].ToString(),
                        Discontinued = Convert.ToByte(datarow["Discontinued"]),
                        IsAdmin = Convert.ToByte(datarow["IsAdmin"])
                    };
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
