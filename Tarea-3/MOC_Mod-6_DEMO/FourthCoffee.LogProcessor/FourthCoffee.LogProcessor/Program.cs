using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.LogProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO 09: Replace [Repository Root] with your folder path 
            var logLocator = new LogLocator(@"C:\20483C\CSharp-Programming\Tarea-3\Data\Logs\");
            var logCombiner = new LogCombiner(logLocator);

            logCombiner.CombineLogs(@"C:\20483C\CSharp-Programming\Tarea-3\Data\Logs\CombinedLog.txt");

        }
    }
}
