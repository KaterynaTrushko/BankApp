﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp
    {
    public class Customer(string name, string lastName, int id)
        {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string LastName { get; set; } = lastName;
        public List<Account> accountCustomer;

        public double GetBalance()
            {
            double sum = 0.0;
            try
                {
                 for (int i = 0; i < this.accountCustomer.Count; ++i) 
                    {
                    sum = sum + this.accountCustomer[i].getAccountBalance();
                    }
                Console.WriteLine($"{Name} {LastName} has {sum} UAN on {this.accountCustomer.Count} account"); 
                return sum;
                }
            catch (Exception e)
                {
                 Console.Write(e.Message); return 0;
                }

            }    
        public override string ToString() 
            {
            return $"Customer ID{this.Id} {this.Name} {this.LastName}";
            }
        }
    }