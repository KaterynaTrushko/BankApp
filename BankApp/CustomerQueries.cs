using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
    {
    internal class CustomerQueries
        {
        public static string CreatCustomerQueries = "INSERT INTO customer Values(@first_name, @last_name)";
        public static string GetCustomersQueries = "SELECT ID, FirstName, LastName FROM customer";
        public static string GetByIDQueries = "SELECT ID, FirstName, LastName FROM customer WHERE ID=@customer_ID";
        public static string UpdateQueries = "UPDATE customer SET FirstName = @first_name, LastName = @last_name WHERE ID=@customer_ID";
        public static string DeleteCustomerQueries = "DELETE FROM customer WHERE ID=@customer_ID";
        }

    }
