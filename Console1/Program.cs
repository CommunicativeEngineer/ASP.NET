using System;
using WeCare_PU.Models;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new WeCareBdContext();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
            
            Console.WriteLine("Generation de DB!");
            Console.ReadKey();
        }
    }
}
