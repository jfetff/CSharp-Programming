using System;
using System.IO;

namespace Ejer_199
{
    class Program
    {
        static void Main(string[] args)
        {    
            // File name  
            string fileName = @"C:/20483C/CSharp-Programming/EjerCShar-Examen/CSharp-Codigo/Ejer-199/Ejer-199.txt";
            string value = "     El archivo contiene un poco de C# pruebas de los ejercicios.";
            try  
            {  
                StreamWriter strWriter = null;
                strWriter = new StreamWriter(fileName);
                strWriter.Write(value);
                strWriter.Close();
            }  
            catch(Exception exp)  
            {  
                Console.Write(exp.Message);  
            }
        }
    }
}
