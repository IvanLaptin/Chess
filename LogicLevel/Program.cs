using LogicLevel.NetWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            server.Start();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            server.Stop();
        }
    }
}
