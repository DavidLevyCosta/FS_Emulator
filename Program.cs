using System;
using System.Timers;
using System.Threading;
using System.Data;
using System.Diagnostics;

namespace FS_Emulator
{
    internal class Program
    {

        static void Main(string[] args)
        {   
            Engine engine = new Engine();
            engine.frame_manager.Start();
            Console.ReadLine();
        }


    }
}