using System;
using System.IO;
using System.Net;


namespace Ejer_157b
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
            

            try
            {
                Console.WriteLine("      Opción A.\n");
                WebRequest request = HttpWebRequest.Create("https://csharpdotchristiannageldotcom.files.wordpress.com/2019/04/musicnotes.jpg?w=672");
                StreamWriter writer = new StreamWriter(request.GetResponse().GetResponseStream());
                writer.WriteLine("C:/20483C/file1.jpg");
            }
            catch (System.ArgumentException ex)
            {
                System.Console.WriteLine("     Este es el mensaje del error alzado: ", ex.Message);
            }*/

            /*
            try
            {
                Console.WriteLine("      Opción B.\n");
                WebClient client = new WebClient();
                StreamWriter writer = new StreamWriter("C:/20483C/fileOpcionB.jpg");
                writer.Write(client.DownloadData("https://csharpdotchristiannageldotcom.files.wordpress.com/2019/04/musicnotes.jpg?w=672"));
                writer.Dispose();
                client.Dispose();

            }
            catch (System.InvalidOperationException ex)
            {
                System.Console.WriteLine("     Este es el mensaje del error alzado: ", ex.Message);
            }

            
            try
            {
                Console.WriteLine("      Opción C.\n");
                WebClient client = new WebClient();
                client.DownloadFile("https://csharpdotchristiannageldotcom.files.wordpress.com/2019/04/musicnotes.jpg?w=672", "C:/20483C/musica.jpg");
                client.Dispose();
            }
            catch (System.ArgumentException ex)
            {
                System.Console.WriteLine("     Este es el mensaje del error alzado: ", ex.Message);
            }}*/

            try
            {
                Console.WriteLine("      Opción D.\n");
                WebRequest request = HttpWebRequest.Create("https://csharpdotchristiannageldotcom.files.wordpress.com/2019/04/musicnotes.jpg?w=672");
                StreamWriter writer = new StreamWriter(request.GetResponse().GetResponseStream());
                writer.Write("C:/20483C/fileOpcionD.jpg");
                writer.Dispose();
            }
            catch (System.ArgumentException ex)
            {
                System.Console.WriteLine("     Este es el mensaje del error alzado: ", ex.Message);

            }
            Console.ReadKey();
        }
    }
}
