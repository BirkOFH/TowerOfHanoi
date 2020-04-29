using System;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private static Tower t;
        static void Main(string[] args)
        {
            var TowerHeight = 5;
            Console.BufferWidth = 200;
            Console.WindowWidth = 200;
            Console.CursorVisible = false;
            
            t = new Tower(TowerHeight);
            t.StartDemonstration();
            Console.ReadLine();
            t.Auto();
            Console.ReadLine();
        }


    }
}
