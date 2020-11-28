using System;

namespace Ejer_272
{
    class Program
    {

        // Declaración del delegate
        public delegate int AddNumbers(int x, int y);

        class TestDelegate
        {
            // Creación de un metodo para el delegate.
            public static int MyFunc(int x, int y)
            {
                Console.WriteLine("\n\n     He sido llamado por el delegate ...\n\n", string.Format("{0}", ((int)x + (int)y)));
                return x + y;
            }

            public static void Main()
            {
                // Instanciación del delegate
                AddNumbers sumar = new AddNumbers(MyFunc);
                int a = 3;
                int b = 7; 
                string str = "";
                // Invocación de la función delegate
                str = Convert.ToString(sumar(a, b));
                Console.WriteLine($"     La suma de los números {a} y {b} es: {str}");
            }
        }
    }
}
