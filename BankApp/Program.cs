namespace BankApp
    {
    internal class Program
        {
        static void Main(string[] args)
            {
            var customer1 = new Customer("Kate", "Trushko", 45896);
            Console.WriteLine(customer1);
            
            var bank = new Bank();
            var account1 = bank.OpenNewAccount(587, 35.20);
            var account2 = bank.OpenNewAccount(789, 15.80);

            bank.BindAccontToCustomer(account1, customer1);
            bank.BindAccontToCustomer(account2, customer1);

            var account3 = bank.OpenNewAccount(896, 50.12);
            var account4 = bank.OpenNewAccount(236, 24.88);

            var customer2 = new Customer("Vadym", "Manko", 58996);

            bank.BindAccontToCustomer(account3, customer2);
            bank.BindAccontToCustomer(account4, customer2);

            customer1.GetBalance();
            customer2.GetBalance();

            Console.WriteLine(account1);
            Console.WriteLine(account2);

            bank.TrancferFromTo(account1, account2, 5.20);
            bank.WithdrawCash(account4, 10.00);
            bank.PutMoneyOnAccount(account2, 120.50);

            Console.ReadLine();
            }
        }
    }
