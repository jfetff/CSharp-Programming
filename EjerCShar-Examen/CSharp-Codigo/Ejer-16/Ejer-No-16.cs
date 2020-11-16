using System;
using System.Text.RegularExpressions;

namespace Csharp_Code
{
    class Ejer_No_16
    {
        static void Main()
        {
            Console.WriteLine("Por favor digite la URL con el formato https://www.dominio.com:");
            string url = Console.ReadLine();
            if (ExtensionMethods.IsUrl(url)) 
                Console.WriteLine("Bien hecho, escribe muy bien");
            else
                Console.WriteLine("Lo siento no conoce la página de Microsoft, trate nuevamente!!");

        }
    }

    public static class ExtensionMethods
    {
        public static bool IsUrl(this String str)
        {
            var regex = new Regex(
                "(https?://)?([A-Za-z0-9-]*\\.)?([A-Za-z0-9-]*)" + 
                "\\.[A-Za-z0-9]*/?.*");
            return regex.IsMatch(str);
        }
    }
}
