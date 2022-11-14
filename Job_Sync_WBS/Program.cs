
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Sync_WBS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartInsert start = new StartInsert();
            Console.ForegroundColor = ConsoleColor.Green;
            start.insertDB();
            /*CallAPI.callAPI();*/
        }
    }
}
