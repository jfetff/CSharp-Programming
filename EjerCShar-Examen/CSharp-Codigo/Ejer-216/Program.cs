using System;

namespace Ejer_216
{
    class Program
    {
        static void Main(string[] args)
        {
            Class2 myClass2 = new Class2();
            //myClass2.Method1();
            var f2 = new Class2();
            ((INewInterface)f2).LLamame();
            var myClsOne = new Class1();
            var otraClase = myClsOne.teEnvioClass();
        }
    }

    public class Class1 : Class2
    {
        public Class1(){
            //return (INewInterface)myClass1;
        }
        public Class1 teEnvioClass()
        {
            var ret = new Class1();
            return (Class1)(INewInterface)ret;
        }
        public void Muestrame()
        {
            Console.WriteLine("\n\n     Estoy en el método 'Muestrame' de la Clase1\n\n");
        } 
    }

    public interface INewInterface
    {
        void Method1();
        void LLamame();
        void Muestrame();
    }

    public class Class2 : INewInterface
    {
        public void Method1()
        {
            Console.WriteLine("\n\n     Estoy en el método1 de la clase2\n\n");
            throw new NotImplementedException();
        }

        void INewInterface.LLamame() => Console.WriteLine("     Esto es una implentación explícita de la Clase2");

        public void Muestrame()
        {
            Console.WriteLine("     Estoy en el método 'Muestrame' de la Clase2");
        }
    }
}
