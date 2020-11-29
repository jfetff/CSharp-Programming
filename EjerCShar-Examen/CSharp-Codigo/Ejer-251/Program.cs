using System;

namespace Ejer_251
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ContosoException : System.Exception
    {
        static void Log(Exception ex)
        {
            System.Console.WriteLine("    Este es el Log de ContosoException, con el mensaje: ", ex.Message);
        }
    }

    public class ContosoDbException : Contoso.Exception
    {
        static void Log(ContosoException ex)
        {
            System.Console.WriteLine("    Este es el Log de ContosoDbException, con el mensaje: ", ex.Message);
        }
    }

    public class ContosoValidationException : Contoso.Exception
    {
        static void Log(ContosoValidationException ex)
        {
            System.Console.WriteLine("    Este es el Log de ContosoValidationException, con el mensaje: ", ex.Message);
        }
    }


    [Serializable]
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException()
        {

        }

        public InvalidStudentNameException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }
    
    }

}
