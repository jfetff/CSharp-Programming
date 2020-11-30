using System;

namespace Ejer_182
{
    class Program
    {
        static void Main(string[] args)
        {
                        //declare variables
            double amount;
            double rate;
            int years;
            //prompt loan amount
            Console.WriteLine("     Entre una cantidad para un loan:");
            amount = Convert.ToDouble(Console.ReadLine());//accepts console input and assigne to variable
            //prompt for rate
            Console.WriteLine("    Entre un tasa de interes anual:");
            rate = Convert.ToDouble(Console.ReadLine());//accepts console input and assigne to variable
            //prompt for monhts
            Console.WriteLine("    Entre el número de años:");
            years = Convert.ToInt32(Console.ReadLine());//accepts console input and assigne to variable

            Loan loan = new Loan(350, 12, years);//create  new instance, send values to the class
            loan.Modificadores();
            Console.ReadKey();
        }
    }

    public class Loan
    {
        // declarar a las variables
        private double LoanAmount, InterestRate;
        private int LoanLength;

        // Constructor de la Loan que toma como parametros amount, rate y years
        public Loan(double amount, double rate, int years)
        {
            this.LoanAmount = amount;
            this.InterestRate = (rate/100.0)/12.0;
            this.LoanLength = years;
        }
        // Regresa el mes pagado
        public double GetMonthlyPayment()
        {
            int months = LoanLength * 12;
            return (LoanAmount * InterestRate * Math.Pow(1 + InterestRate, months))/(Math.Pow(1 + InterestRate, months) - 1);
        }
        // Calcula el total del interes pagado y lo dobla, y luego regresa la cantidad
        public double TotalInterestPaid(double number1,double number2)
        {
            double TotalInterest = number1+number2;
            return  TotalInterest;
        }

        public void Modificadores()
        {
            System.Console.WriteLine("\n\n     La Respuesta correcta es la Opción B");
            System.Console.WriteLine("     ");
            System.Console.WriteLine("     public int DayNumber");
            System.Console.WriteLine("     {");
            System.Console.WriteLine("          get");
            System.Console.WriteLine("          {");
            System.Console.WriteLine("               return DateTime.Today.Day;");
            System.Console.WriteLine("          }");
            System.Console.WriteLine("     }");
        }
    }
}
