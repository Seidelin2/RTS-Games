using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTS_Games
{
    class GoldMine
    {
        static Semaphore mySemaphore = new Semaphore(0,3);

        static void Goldmine()
        {
            for (int i = 0; i <= 5; i++)
            {
                new Thread(Enter).Start(i);
            }

            Thread.Sleep(500);
            Console.WriteLine("Main thread calls Release(3)");
            mySemaphore.Release(3);
            Console.ReadKey();
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + "Starts and waits outside to enter");
            mySemaphore.WaitOne();
            Console.WriteLine(id + "Enters the nightclub");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id + "is leaving");
            mySemaphore.Release();
        }
    }
}
