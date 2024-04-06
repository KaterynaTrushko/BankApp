using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BankApp
    {

    public class Bank : IBank
        {
        public Bank() 
            {
            var accountList = new List<Account>();
            var customerList = new List<Customer>();
            var customerDictionary = new Dictionary<Account, Customer>();
            }
        List<Account> accountList;
        List<Customer> customerList;
        Dictionary<Account, Customer> customerDictionary;
        protected double Rate { get; set; }
        static double rate = 7.5;


        public Account OpenNewAccount(int id, double num) 
            {
            var account = new Account(id, num);
            if(this.accountList == null) { this.accountList = new List<Account>(); }
            accountList.Add(account);
            return account;
            }
        public void AddNewCustomer(string name, string lastName, int id)
            {
            if(customerList == null) {  customerList = new List<Customer>(); }
            customerList.Add(new Customer(name, lastName, id));
            }
        public void BindAccontToCustomer(Account account, Customer customer)
            {
            if (customerDictionary == null)
                {
                customerDictionary = new Dictionary<Account, Customer>();
                }
            //customerDictionary.Add(account, customer);
            if (!customerDictionary.ContainsKey(account))
                {
                //customerDictionary.Add(account, customer);
                if (customer.accountCustomer == null) { customer.accountCustomer = new List<Account>(); }
                customer.accountCustomer.Add(account);

                }
            else { Console.Write("Dictionary already has this account"); }
            }
        public List<Account> GetAccounts()
            {
            foreach (var account in accountList)
                {
                Console.Write(account);
                }
            return accountList;
            }
        public List<Customer> GetCustomerList()
            { 
            foreach (var customer in customerList) 
                {
                Console.Write(customer);
                }
            return customerList; 
            }
        public void TrancferFromTo(Account account1, Account account2, double sum)
            {
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
            else { Console.WriteLine("Cheeck input parametrs"); }
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