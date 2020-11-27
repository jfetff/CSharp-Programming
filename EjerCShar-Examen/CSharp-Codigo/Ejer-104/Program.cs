using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ejer_104
{
    class Program
    {
        private const string V = "Rene";

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n      *****************************************");
            Console.WriteLine("      LISTA DE TODAS LAS OPCIONES DEL EJERCICIO");
            Console.WriteLine("      *****************************************\n\n");
            //T obj = objT; // Where obj is object whose properties you need.
            //T obj = new T();
            Coords obj = CreateObjectOpW <Coords > ();
            Console.WriteLine($"\n      El objeto devuelto es de tipo coordenada con x = {obj.x} y en y = {obj.y}");
        }

        class Coords
        {
            public int x, y;

            // constructor
            public Coords()
            {
                x = 10;
                y = 30;
            }
        }

        public static T CreateObjectOpW<T>()
        where T : new()
        {
            Console.WriteLine("      Opción A. Insert the following code at line 02: where T : new()\n");
            T obj = new T();
            return obj;
        }

        /*
        public static void CreateObjectOpB<T>()
        {
            Console.WriteLine("\n\n      Opción B. Replace line 01 with the following code: public void CreateObject<T>()\n");
            T obj = new T();
            return obj;
        }
        
        public Object CreateObjectOpC<T>()

        {
            Console.WriteLine("\n\n      Opción C. Replace line 01 with the following code: public Object CreateObject<T>()\n");
            T obj = new T();
            return obj;
        }

        public static T CreateObjectooD<T>() where T : Object
        {
            Console.WriteLine("\n\n      Opción D. Insert the following code at line 02: where T : Object\n");
            T obj = new T();
            return obj;
        }*/

    }

}
