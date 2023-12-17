using Programming101.Manager;
using Programming101.Managers;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Programming101
{
    class Program
    {    
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.Run();            
        }
    }
}
