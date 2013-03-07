using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTestWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                int currentNum = WCFManager.Instance.TestIProductInfoService(int.Parse(input));
                Console.WriteLine("Init {0} Instance.", currentNum);
            }

        }
    }
}
