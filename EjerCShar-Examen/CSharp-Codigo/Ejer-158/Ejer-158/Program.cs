using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ejer_158
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee miEmpleado = new Employee();
            //var employeeData = miEmpleado.ReadXML();
            var employeeData = JsonStringToByteArray();
            Console.WriteLine("\n\n      *****************************************");
            Console.WriteLine("      LISTA DE TODAS LAS OPCIONES DEL EJERCICIO");
            Console.WriteLine("      *****************************************\n");

            /*
            try
            {
                Stream stream = null;
                Console.WriteLine("      Opción A.\n");
                using (stream = new MemoryStream(employeeData));
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee retrievedEmployee = xmlSerializer.Deserialize(stream) as Employee;
                Console.WriteLine("      El assembly es nulo...");
                Console.WriteLine("      Este método toma com parametro una string y no byte[]");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("      El error mostrado en esta opción es: ", ex.Message);
            }
            
            try
            {
                Console.WriteLine("\n\n      Opción B.\n");
                using (Stream stream = new MemoryStream(employeeData)) ;
                DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Employee));
                Employee retrievedEmployee = DataContractSerializer.ReadObject(stream) as Employee;
                Console.WriteLine("      El assembly es nulo...");
                Console.WriteLine("      Este método toma com parametro una string y no byte[]");
                Console.WriteLine("      El Assembly no es nulo, mostrando sus metadatos:");
                Console.WriteLine("      Los datos del Assambly son: ");
            }
            catch (PlatformNotSupportedException ex)
            {
                Console.WriteLine("      El Assembly no es nulo, pero no muestra nada porque no usado correctamente");
                Console.WriteLine("      El error mostrado en esta opción es: ", ex.Message);
            }
            */

            static byte[] JsonStringToByteArray()
            {
                byte[] res = null;
                List<Employee> empleado = new List<Employee>{
                   new Employee{Id = 1, Name = "David Jones"}
                   };
                string jsonString = JsonConvert.SerializeObject(empleado);
                var encoding = new UTF8Encoding();
                res = encoding.GetBytes(jsonString.Substring(1, jsonString.Length - 2));
                return res;
            }

            try
            {
                Console.WriteLine("\n\n      Opción C.\n");
                using Stream stream = new MemoryStream(employeeData);
                {
                    DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Employee));
                    Employee retrievedEmployee = (Employee)dataContractJsonSerializer.ReadObject(stream);
                    retrievedEmployee.Print();
                }
                Console.WriteLine("\n\n       Proceso exitoso de esta opción...");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("      El error mostrado en esta opción es: ", ex.Message);
            }

            /*
            try
            {
                Console.WriteLine("\n\n      Opción D.\n");
                using (Stream stream = new MemoryStream(employeeData));
                {
                    NetDataContractSerializer netDataContractSerializer = new DataContractSerializer();
                    Employee retrievedEmployee = netDataContractSerializer.ReadObject(stream) as Employee;
                }
                Console.WriteLine("      El assembly es nulo...");
                Console.WriteLine("      Este método toma com parametro una string y no byte[]");
                Console.WriteLine("      El Assembly no es nulo, mostrando sus metadatos:");
                Console.WriteLine("      Los datos del Assambly son: ");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("      El error mostrado en esta opción es: ", ex.Message);
            }
            */
        }

    }

    public class Employee
    {
        public Employee(){}

        public int Id;
        public string Name;

        public byte[] ReadXML()
        {
           
            string testData = @"<Employee>
                                    <Id>1</Id>
                                    <Name>David Jones</Name>
                                </Employee>";
            
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextReader reader1 = new StringReader(testData))
            {
                Employee result = (Employee)serializer.Deserialize(reader1);
                this.Id = result.Id;
                this.Name = result.Name;
                return ToByteArray(result);
            }
        }

        public byte[] ToByteArray(Employee obj)
        {
            if (obj == null)
            {
                return null;
            }
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(Employee));
                serializer.WriteObject(ms, obj);
                return ms.ToArray();
            }
        }

        public void Print()
        {
            Console.WriteLine("\n\n      *****************************************");
            Console.WriteLine("         MOSTRANDO EL OBJETO DESERIALIZADO");
            Console.WriteLine("      *****************************************\n");

            Console.WriteLine($"\n       El Nombre del Empleado es: {Name}");
            Console.WriteLine($"       El Id del Empleado es: {Id}");
        }

    }
        
}