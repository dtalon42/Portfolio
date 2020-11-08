using CDManager.Controllers;
using CDManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDManager
{
    class Program
    {
        static void Main(string[] args)
        {
            CDController manager = new CDController();
            //string input;
            Console.WriteLine("Welcome to the CD Manager!");

            while (true)
            {
                manager.run();
            
            }
            
               


        }
    }
}
