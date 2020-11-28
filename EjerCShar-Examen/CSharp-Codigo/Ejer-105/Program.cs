using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer_105
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n      *****************************************");
            Console.WriteLine("      LISTA DE TODAS LAS OPCIONES DEL EJERCICIO");
            Console.WriteLine("      *****************************************\n");
            Worker myWorker = new Worker();
            myWorker.Run();
            Console.WriteLine("\n");
        }


        public class ItemBase
        {

        }
        public class Widget : ItemBase
        {

        }

        public class Worker
        {
            void DoWork(object obj)
            {
                Console.WriteLine("\n\n      In DoWork(o is Widget)");
                Console.WriteLine("\n      *****************************************");
                Console.WriteLine("      Esta es la opción C: DoWork(o is Widget);");
                Console.WriteLine("             Esta opción no es CORRECTA");
                Console.WriteLine("      *****************************************\n");
            }
            void DoWork(Widget widget)
            {
                Console.WriteLine("\n\n      In DoWork((Widget)o)");
                Console.WriteLine("\n      *****************************************");
                Console.WriteLine("      Esta es la opción A: DoWork((Widget)o);");
                Console.WriteLine("             Esta es la opción CORRECTA");
                Console.WriteLine("      *****************************************\n");
                Console.WriteLine("\n\n      In DoWork(new Widget(o))");
                Console.WriteLine("\n      *****************************************");
                Console.WriteLine("      Esta es la opción B: DoWork(new Widget(o));");
                Console.WriteLine("      Esta opción da ERROR porque no hay ningún");
                Console.WriteLine("           constructor en la clase Widget");
                Console.WriteLine("      *****************************************\n");
            }
            void DoWork(ItemBase itemBase)
            {
                Console.WriteLine("\n\n      In DoWork((ItemBase)o)");
                Console.WriteLine("\n      *****************************************");
                Console.WriteLine("      Esta en la opción D: DoWork((ItemBase)o);");
                Console.WriteLine("             Esta opción no es CORRECTA");
                Console.WriteLine("      *****************************************\n");
            }
            public void Run()
            {
                object o = new Widget();
                DoWork((Widget)o);
                //DoWork(new Widget(o));
                DoWork(o is Widget);
                DoWork((ItemBase)o);
            }
        }
    }
}
