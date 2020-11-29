using System;

namespace Ejer_182
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Loan
    {
        //declare variables
        private double LoanAmount, InterestRate;
        private int LoanLength;

        //Constructor of Loan class that takes amount, rate and years
        public Loan(double amount, double rate, int years)
        {
            this.LoanAmount = amount;
            this.InterestRate = (rate/100.0)/12.0;
            this.LoanLength = years;
        }
        //returns the monnthly payment
        public double GetMonthlyPayment()
        {
            int months = LoanLength * 12;
            return (LoanAmount * InterestRate * Math.Pow(1 + InterestRate, months)) / (Math.Pow(1 + InterestRate, months) - 1);
        }
        //Calculates totl interterest paid and doubles it, then returns the amount
        public double TotalInterestPaid(double number1,double number2)
        {
            double TotalInterest = number1+number2;
            return  TotalInterest;
        }
    }

}
