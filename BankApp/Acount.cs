using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApp
    {
    public class Account
        {
        int id;
        Money balance;
        public List<string> transaction;
        public List<string> Transaction {  get; set; }    

        int Id { get; set; }
        public Account(int id, double num) 
            { 
            if(id > 0 && num > 0) 
                {
                Id = id;
                balance = new Money(num);
                }
            }

        public void TakeMoney(double num)
            {
            var a = Convert.ToDecimal(balance.Amount);
            var b = Convert.ToDecimal(num);
            var c = Convert.ToDouble(a - b);
            balance.Amount = c;
            }

        public void PutMoney(double num)
            {
            var a = Convert.ToDecimal(balance.Amount);
            var b = Convert.ToDecimal(num);
            var c = Convert.ToDouble(a + b);
            balance.Amount = c;
            }
        public double getAccountBalance() 
            {
            return balance.Amount;
            }                
        public override string ToString()
            {
            return $"Ac Id{Id} avail. bal. {balance.Amount} UAN ";
            }
        }

    }
