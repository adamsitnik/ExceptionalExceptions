#if !CORE
using System;
using System.Threading;

namespace Demo
{
    public class ThreadAbortExceptionDemo : IDemoable
    {
        public void Demo()
        {
            var thread = new Thread(Run);

            thread.Start();

            while (!thread.IsAlive)
                Thread.Sleep(TimeSpan.FromMilliseconds(100)); // wait until it starts

            Thread.Sleep(TimeSpan.FromMilliseconds(300)); // let it print the text and get to while loop

            thread.Abort();

            bool abortSucceeded = thread.Join(TimeSpan.FromSeconds(5));
            if (!abortSucceeded)
                Console.WriteLine("Thread abort failed.");

            GC.KeepAlive(thread);
        }

        void Run()
        {
            try
            {
                Console.WriteLine("Try block got executed");
                while (true) { } // endless loop
            }
            finally
            {
                Console.WriteLine("Finally block got executed");
            }
        }
    }
}
#endif