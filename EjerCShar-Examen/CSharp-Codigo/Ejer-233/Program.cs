using System;
using System.Collections.Generic;

namespace Ejer_233
{
    class Program
    {
        static void Main(string[] args)
        {
            // Version 1: create a Dictionary, then add 4 pairs to it.
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("cat", 2);
            dictionary.Add("dog", 1);
            dictionary.Add("llama", 0);
            dictionary.Add("iguana", -1);
            // The dictionary has 4 pairs.
            Console.WriteLine("\n\n     DICCIONARIO 1: " + dictionary.Count);
            // Version 2: create a Dictionary with an initializer.
            var dictionary2 = new Dictionary<string, int>()
            {
                {"cat", 2},
                {"dog", 1},
                {"llama", 0},
                {"iguana", -1}
            };
            // This dictionary has 4 pairs too.
            Console.WriteLine("\n     DICCIONARIO 2: " + dictionary2.Count);
        }
    }
}
