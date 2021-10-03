using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    interface IBillingStategy
    {
        double GetPrice(double rawPrice);
    }


    class NormalStrategy : IBillingStategy
    {
        public double GetPrice(double rawPrice) => rawPrice;         
    }

    class HappyHourStrategy : IBillingStategy
    {
        public double GetPrice(double rawPrice) => rawPrice * 0.5;
    }

    class CustomerBill
    {
        private IList<double> drinks;

        public IBillingStategy Strategy { get; set; }
        public CustomerBill(IBillingStategy stategy)
        {
            this.drinks = new List<double>();
            this.Strategy = stategy;
        }

        public void Add(double price,int quantity)
        {
            this.drinks.Add(this.Strategy.GetPrice(price * quantity));
        }

        public void Print()
        {
            double sum = 0;
            foreach(double cost in this.drinks)
            {
                sum += cost;
            }
            Console.WriteLine($"Total : {sum}");
            this.drinks.Clear();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            NormalStrategy normalStrategy = new NormalStrategy();
            HappyHourStrategy happyHourStrategy = new HappyHourStrategy();
            CustomerBill firstCustomerBill = new CustomerBill(normalStrategy);

            // Normal Billing
            firstCustomerBill.Add(1.0, 1);
            // Start happy hour
            firstCustomerBill.Strategy  = happyHourStrategy;
            firstCustomerBill.Add(1.0, 2);
            // Total first customer bill
            firstCustomerBill.Print();


            // New customer
            CustomerBill secondCustomerBill = new CustomerBill(happyHourStrategy);
            secondCustomerBill.Add(0.8, 1);
            // End happy hour
            secondCustomerBill.Strategy = normalStrategy;
            secondCustomerBill.Add(1.3, 2);
            secondCustomerBill.Add(2.5, 1);

            // Total first customer bill
            secondCustomerBill.Print();

        }
    }
}
