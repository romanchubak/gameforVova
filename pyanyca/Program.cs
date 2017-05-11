using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyanyca
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] Players = { new Player("Roma", 20), new Player("Vova", 20) };
            Сroupier c = new Сroupier("BigDi", 35);
            c.StartGame(Players);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
