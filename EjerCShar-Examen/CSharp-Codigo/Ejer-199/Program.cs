using System;

namespace Ejer_199
{
    class Program
    {
        static void Main(string[] args)
        {    
            // File name  
            string fileName = @"C:\Temp\Mahesh.txt";
            try  
            {  
                using (StreamWriter writer = new StreamWriter(fileName))  
                {  
                    writer.Write("     El archivo contiene un poco de C# pruebas de los ejercicios.");  
                }  
            }  
            catch(Exception exp)  
            {  
                Console.Write(exp.Message);  
            }  

            Console.WriteLine("Hello World!");
        }
    }

    public class WritingFile
    {

        protected void ProcessFile(string fileName, string value)
        {

        }
    }
}
