using System;

namespace Ejer_34
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n\n      Por favor digite 1, 2, o 3 para elegir una de la configuraciones siguientes:\n");
            Console.WriteLine("              1. TRIAL.");
            Console.WriteLine("              2. ADVANCED.");
            Console.WriteLine("              3. BASIC");
            Console.Write("\n              ");
            string build = "\t" + Console.ReadLine();
            if (build == "1")
            {
                Console.WriteLine("\n\n      *****************************************");
                Console.WriteLine("          ESTAS EN LA CONFIGURACION TRIAL !");
                Console.WriteLine("      *****************************************\n\n");
                EvaluateLoan(); 
            }
            else if (build == "2")
            {
                Console.WriteLine("\n\n      *****************************************");
                Console.WriteLine("         ESTAS EN LA CONFIGURACION ADVANCED !");
                Console.WriteLine("      *****************************************\n\n");
                EvaluateLoan();
                ProcessLoan();
                FundLoan();
            }
            else
            {
                Console.WriteLine("\n\n      *****************************************");
                Console.WriteLine("           ESTAS EN LA CONFIGURACION BASIC !");
                Console.WriteLine("      *****************************************\n\n");
                EvaluateLoan();
                ProcessLoan();
            }

            Console.WriteLine("\n\n              ");
        }
        static void EvaluateLoan()
        {
            Console.WriteLine("      Saludos desde el Método EvaluateLoan()!");
        }
        static void ProcessLoan()
        {
            Console.WriteLine("      Saludos desde el Método ProcessLoan()!");
        }
        static void FundLoan()
        {
            Console.WriteLine("      Saludos desde el Método FundLoan()!");
        }
    }
}
