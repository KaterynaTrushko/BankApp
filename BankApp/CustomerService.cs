using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
    {
    public class CustomerService
        {
        public static async Task<bool> AddCustomer(Customer newCustomer)
            {
            //create connections
            using (var connection = new SqlConnection(ApplicationSetting.ConnectionString))
                {
                var cmd = new SqlCommand(CustomerQueries.CreatCustomerQueries, connection);
                //використовуємо параметеризовані запити
                //cmd.Parameters.Add("@first_name", System.Data.SqlDbType.NVarChar).Value = newCustomer.FirstName;
                cmd.Parameters.Add("@first_name", System.Data.SqlDbType.NVarChar).Value = newCustomer.FirstName.ToString();
                cmd.Parameters.Add("@last_name", System.Data.SqlDbType.NVarChar).Value = newCustomer.LastName.ToString();
               
                connection.Open();
                var transaction = await connection.BeginTransactionAsync();

                try
                    {
                    var affectedRow = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    return affectedRow == 1;
                    }
                catch (Exception e)
                    {
                    Console.WriteLine(e);
                    try {
                        transaction.Rollback();
                        }
                    catch(Exception ex2) 
                        { 
                        Console.WriteLine(ex2);
                        return false;
                        }
                    return false;
                    }
                }
            }


        public static async Task<IEnumerable<Customer>> GetCustomers()
            {
            using (var connection = new SqlConnection(ApplicationSetting.ConnectionString))
                {
                var cmd = new SqlCommand(CustomerQueries.GetCustomersQueries, connection);

                var customerList = new List<Customer>();

                connection.Open();

                using (var sqlReader = cmd.ExecuteReader())
                    {
                    while (sqlReader.Read())
                        {
                        var customerID = Convert.ToInt32(sqlReader["ID"]);
                        var firstName = sqlReader["FirstName"].ToString();
                        var lastName = sqlReader["LastName"].ToString();

                        customerList.Add(new Customer(lastName, firstName, customerID));
                        }
                    }

                connection.Close();

                return customerList;

                }
            }

        public static async Task<Customer> GetCustomersByID(int id)
            {
            using (var connection = new SqlConnection(ApplicationSetting.ConnectionString))
                {
                var cmd = new SqlCommand(CustomerQueries.GetByIDQueries, connection);

                Customer customer = null;

                cmd.Parameters.Add("@customer_ID", System.Data.SqlDbType.Int).Value = id;


                connection.Open();

                using (var sqlReader = cmd.ExecuteReader())
                    {
                    while (sqlReader.Read())
                        {
                        var customerID = Convert.ToInt32(sqlReader["ID"]);
                        var firstName = sqlReader["FirstName"].ToString();
                        var lastName = sqlReader["LastName"].ToString();

                        customer = new Customer(lastName, firstName, customerID);
                        }
                    }

                connection.Close();

                return customer;

                }
            }

        public static async Task<bool> UpdateCustomers(Customer updatacustomer)
            {
            //create connections
            using (var connection = new SqlConnection(ApplicationSetting.ConnectionString))
                {
                var cmd = new SqlCommand(CustomerQueries.UpdateQueries, connection);
                cmd.Parameters.Add("@customer_ID", System.Data.SqlDbType.Int).Value = updatacustomer.Id.ToString();
                cmd.Parameters.Add("@first_name", System.Data.SqlDbType.NVarChar).Value = updatacustomer.FirstName.ToString();
                cmd.Parameters.Add("@last_name", System.Data.SqlDbType.NVarChar).Value = updatacustomer.LastName.ToString();

                connection.Open();
                var affectedRow = cmd.ExecuteNonQuery();
                connection.Close();

                return affectedRow == 1;
                }
            }

        public static async Task<bool> DeleteCustomer(int id)
            {
            //create connections
            using (var connection = new SqlConnection(ApplicationSetting.ConnectionString))
                {
                var cmd = new SqlCommand(CustomerQueries.DeleteCustomerQueries, connection);
              
                cmd.Parameters.Add("@customer_ID", System.Data.SqlDbType.Int).Value = id;
                

                connection.Open();
                var affectedRow = cmd.ExecuteNonQuery();
                connection.Close();

                return affectedRow == 1;
                }
            }
        }
    }
