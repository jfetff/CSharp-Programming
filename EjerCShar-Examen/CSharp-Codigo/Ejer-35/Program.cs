using System;
using System.Globalization;

namespace Ejer_35
{
    class Program
    {
        private const string Value = "\n\t              ";

        static void Main()
        {
            Console.WriteLine("\n\n      Por favor digite la fecha de hoy en el formato local (formato DD/MM/AAAA HH:MM AM/PM):\n");
            Console.Write("\t");
            string fecha = Console.ReadLine();//Console.ReadLine(); "19/11/2020 08:00 PM"
            Console.Write("\n\n");
            if (validar(fecha))
            {
                Console.WriteLine("\n\n      *******************************************");
                Console.WriteLine("       ESTE MÉTODO HA VALIDADO LA FECHA LOCAL !");
                Console.WriteLine("      *******************************************\n\n");
            }
            else
            {
                Console.WriteLine("\n\n      *******************************************");
                Console.WriteLine("          LA FECHA NO SE HA PODIDO VALIDAR !");
                Console.WriteLine("        NO TIENE EL FORMATO LOCAL O UNIVERSAL !");
                Console.WriteLine("      *******************************************\n\n");
            }
        }
        static bool validar(string dateString)
        {
            DateTime result;
            DateTimeStyles styles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal;
            if(DateTime.TryParse(dateString, CultureInfo.CurrentCulture, styles, out result))
            {
                System.Console.Write("\n\n\t");
                System.Console.WriteLine("{0} convertido a {1} {2}.", dateString, result, result.Kind);
                return true;
            }
            else
                return false;
        }
    }
}
