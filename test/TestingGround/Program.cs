using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(1998, 04, 12, 12, 00, 00);

            var time = dt.AddHours(2);
            Console.WriteLine(dt);
            Console.WriteLine(time);

            Console.ReadKey();
        }
    }
}
