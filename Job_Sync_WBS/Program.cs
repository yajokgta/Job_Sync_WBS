
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Sync_WBS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StartInsert start = new StartInsert();
            Console.ForegroundColor = ConsoleColor.Green;
            await start.InsertDBAsync();
            /*CallAPI.callAPI();*/
        }
    }
}
