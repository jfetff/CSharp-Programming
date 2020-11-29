using System;
using System.Net;

namespace Ejer_157
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://csharpdotchristiannageldotcom.files.wordpress.com/2019/04/musicnotes.jpg?w=672", "C:/20483C/musica.jpg");
            Console.WriteLine("     Bajando la foto, la foto se guarda en 'C:/20483C/musica.jpg' ..... Press a key to quit.");
            client.Dispose();
        }
    }
}
