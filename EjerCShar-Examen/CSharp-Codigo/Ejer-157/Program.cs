using System;
using System.Net;
using System.IO;

namespace Ejer_157
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            WebClient client = new WebClient();
            client.DownloadFile("https://csharpdotchristiannageldotcom.files.wordpress.com/2019/04/musicnotes.jpg?w=672", "C:/20483C/musica.jpg");
            Console.WriteLine("     Bajando la foto, la foto se guarda en 'C:/20483C/musica.jpg' ..... Press a key to quit.");
            client.Dispose();
            */

            Console.WriteLine("\n\n      *****************************************");
            Console.WriteLine("      LISTA DE TODAS LAS OPCIONES DEL EJERCICIO");
            Console.WriteLine("      *****************************************\n");

            try
            {
                Console.WriteLine("      Opción A.\n");
                WebRequest request = HttpWebRequest.Create("https://le-cdn.website-editor.net/711b5e80ef1349888fc4bab086670e23/dms3rep/multi/opt/F1-960w.jpg");
                StreamWriter writer = new StreamWriter(request.GetResponse().GetResponseStream());
                writer.WriteLine("C:\\file1.jpg");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("     Este es el mensaje alzado: ", ex.Message);
            }
        }
    }
}
