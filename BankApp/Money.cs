using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BankApp
    {
    public class Money
        {
        private double amoung;
        string currency = "UAN";
        public double Amount { get; set; }
        public string Currency { get; set; }
        public Money(double num) 
            {
            Amount = num;
            }
        public decimal Add(decimal a, decimal b) 
            { return a + b; }
        public double Add(double a, double b)
            { return a + b; }
        public double Multip(double a, double b)
            { return a * b; }
        public double Divaid(double a, double b)
            { return a / b; }
         
        }
   
    }
    
    
