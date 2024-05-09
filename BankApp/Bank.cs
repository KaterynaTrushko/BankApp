using System;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BankApp
    {

    public static bool ValidBank(Bank bank)
        {
        var type = typeof(Bank);
        var attributes = type.GetCustomAttribute(false);
        foreach (var attribute in attributes)
            {
            if (attribute is RegistrationAttribute Registration)
                {
                return bank.License.Contains(Registration.Lisense);
                }
            return true;
            }
        }

    public class Registration : Attribute
        {
        public string License { get; set; } 
        public Registration(string license) 
            { 
              this.Lisense = license;
            }
        }

    [Registration("IBA")]
    public class Bank : IBank
        {
        
        public Bank(string license) 
            {
            string License = license;
            var accountList = new List<Account>();
            var customerList = new List<Customer>();
            var customerDictionary = new Dictionary<Account, Customer>();
            }
        public string License { get; set; }
        List<Account> accountList;
        List<Customer> customerList;
        Dictionary<Account, Customer> customerDictionary;
        static double rate = 7.5;
        protected double Rate { get; set; }


        public Account OpenNewAccount(int id, double num)
            {

            return new Account(id, num);
            try
                {
                var account = new Account(id, num);
                if (this.accountList == null) { this.accountList = new List<Account>(); }
                accountList.Add(account);
                return account;
                }

            catch (Exception ex)
                {
                throw ex;
                Console.WriteLine(ex.GetType().ToString(), ex.Message);
                }
            }

        public void AddNewCustomer(string name, string lastName, int id)
            {
            customerList.Add(new Customer(name, lastName, id));
            }


        public void BindAccontToCustomer(Account account, Customer customer)
            {
            if (customerDictionary == null)
                {
                customerDictionary = new Dictionary<Account, Customer>();
                }
            if (!customerDictionary.ContainsKey(account))
                {
                if(customer.AccountCustomer is null) customer.AccountCustomer = new List<Account> { account };
                }
            else { Console.Write("Dictionary already has this account"); }
            }

        public List<Account> GetAccounts()
            {
            try
                {
                foreach (var account in accountList)
                    {
                    Console.Write(account);
                    }
                return accountList;
                }
            catch (NullReferenceException ex)
                { 
                Console.Write(ex.GetType().ToString(), ex.Message);
                throw ex;
                }
            }


        public List<Customer> GetCustomerList()
            { 
            try
                {
                foreach (var customer in customerList)
                    {
                    Console.Write(customer);
                    }
                return customerList;
                }
            catch (NullReferenceException ex)
                {
                Console.Write(ex.GetType().ToString(), ex.Message);
                throw ex;
                }
            }


        public void TrancferFromTo(Account account1, Account account2, double sum)
            {
            try {
                if (account1 != null && account2 != null && account1.getAccountBalance() >= sum)
                    {
                    if (account1.transaction == null) { account1.Transaction = new List<string>(); }
                    if (account2.transaction == null) { account2.Transaction = new List<string>(); }
                    DateTime dt = DateTime.Now;
                    account1.TakeMoney(sum);
                    account2.PutMoney(sum);
                    account1.Transaction.Add($"{dt} {account1} operation: trancfer UAN: {sum} ");
                    Console.WriteLine($"{dt} {account1} operation: trancfer UAN: {sum} ");
                    account2.Transaction.Add($"{dt} {account2} operation: comming UAN: {sum} from {account1} ");
                    Console.WriteLine($"{dt} {account2} operation: comming UAN: {sum} ");

                    }
                else { Console.WriteLine("Cheeck input parameters"); }
                }
            catch(Exception e) 
                {
                throw new Exception("Check input parameters");
                }
            }
        public void WithdrawCash(Account account, double sum) 
            {
            if (account != null && account.getAccountBalance() >= sum)
                {
                if (account.transaction == null) { account.Transaction = new List<string>(); }
                DateTime dt = DateTime.Now;
                account.TakeMoney(sum);
                account.Transaction.Add($"{dt} {account} operation: Withdrawing UAN: {sum} from {account} cur. bal. {account.getAccountBalance()}UAN.");
                Console.WriteLine($"{dt} {account} operation: Withdrawing UAN: {sum} from {account} cur. bal. {account.getAccountBalance()}UAN.");
                }
            else { Console.WriteLine("Cheeck input parametrs"); }
            }

        public void PutMoneyOnAccount(Account account, double sum)
            {
            if (account != null )
                {
                if (account.transaction == null) { account.Transaction = new List<string>(); }
                DateTime dt = DateTime.Now;
                account.PutMoney(sum);
                account.Transaction.Add($"{dt} {account} operation: Put Money UAN: {sum}  cur. bal. {account.getAccountBalance()}UAN.");
                Console.WriteLine($"{dt} {account} operation: Put Money UAN:: {sum} from  cur. bal. {account.getAccountBalance()}UAN.");
                }
            else { Console.WriteLine("Cheeck input parametrs"); }
            }

        }
    
    } 
  





/*2. Банк.
- Клас +Клієнт.
- Клас +Рахунок
- Клас +Гроші
- Є клас Банк, він містить у собі список +клієнтів та +рахунків. Не всі клієнти можуть мати рахунки. 
Можна відкривати +рахунки, +додавати клієнтів. +Прив'язувати рахунок до клієнта. 
Отримувати список усіх +рахунків та +клієнтів.
- У клієнта є ім'я та прізвище, і список його рахунків. 
Методи отримання балансу по рахунках.
- У рахунку є гроші (баланс), ставка. На рахунок можна переказувати гроші та знімати їх. 
Змінювати ставку. Робити це може лише банк.
- Гроші складаються з гривень та копійок, з ними можна проводити прості арифмети. 
операції та порівняння. Має бути незмінним.
 - Усі дії з переказами (зняти, покласти або переказати гроші між рахунками) 
мають бути описані типом транзакції.
 - Історія транзакцій має бути збережена для кожного рахунку.*/