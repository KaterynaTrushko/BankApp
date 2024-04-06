using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
    {
    public interface IBank
        {
        public Account OpenNewAccount(int id, double num);
        public void AddNewCustomer(string name, string lastName, int id);
        public void BindAccontToCustomer(Account account, Customer customer);
        public List<Account> GetAccounts();
        public List<Customer> GetCustomerList();

        }
    }
