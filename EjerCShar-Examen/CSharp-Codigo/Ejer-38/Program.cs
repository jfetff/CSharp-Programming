using System;

namespace Ejer_38
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse.Inventory otroWareH = null;
            Warehouse.inventory.pintar();
            otroWareH = Warehouse.inventory;
            //Warehouse.inventory.pintar();
        }
    }

    public class Warehouse
    {
        public Warehouse(){}
        static Inventory _inventory = null;
        static object _lock = new object();
        public static Inventory inventory
        {
            get
            {
                if (_inventory == null)
                    lock(_lock)
                if (_inventory == null)
                {
                    System.Console.WriteLine("En inventario es nulo por eso lo instaciamos");
                    _inventory = new Inventory();
                }
                return _inventory;
            }
        }
        public class Inventory
        {
            public Inventory(){
                pintar();
            }
            public void pintar()
            {
                System.Console.WriteLine("En inventario se ha instaciado desde el constructor");
            }
        }
    }

} // Fin de la clase Program
