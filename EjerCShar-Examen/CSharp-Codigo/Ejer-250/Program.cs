using System;

namespace Ejer_250
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n     Esta es la respuesta de la caja No 1. usando solo 'throw'\n");
            Console.WriteLine("     throw conserva la información sobre dónde se lanzó la excepción, pero aún no da una imagen completa de lo que sucedió.\n");
            Console.WriteLine("     Aquí el error es de tipo original y mantenemos el tipo de excepción.\n");
            try
            {
                int x = 0;
                int y = 10;
                int res = y / x;
            }
            catch (Exception)
            {
                throw;
            }

            Console.WriteLine("\n\n     Esta es la respuesta de la caja No 2.\n");
            Console.WriteLine("     Aquí el error es de tipo original y hacemo reset del seguimiento de la pila de excepciones.");
            Console.WriteLine("\n     throw ex restablece el seguimiento de la pila (por lo que sus errores parecerían originarse en HandleException.\n");
            try
            {
                int x = 0;
                int y = 10;
                int res = y / x;
                Console.WriteLine("     Aquí hacemos reset del seguimiento de la pila de excepciones y el tipo de excepción.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("      " + ex.ToString());
            }

            Console.WriteLine("\n     Esta es la respuesta de la caja No 3.\n");
            Console.WriteLine("     Aquí hacemos reset del seguimiento de la pila de excepciones al igual que al tipo de excepción.");
            try
            {
                int x = 0;
                int y = 10;
                int res = y / x;
                Console.WriteLine("     Aquí hacemos reset del seguimiento de la pila de excepciones y el tipo de excepción.\n");
            }
            catch (Exception)
            {
                throw new System.InvalidOperationException("     Logfile cannot be read-only");
            }
            Console.WriteLine("\n\n     La Respuesta correcta es en el order throw, throw ex, throw new Exception !!");
        }
    }
}
