using System;
// ReSharper disable All

namespace Demo
{
    public class TypeInitializationExceptionSample : IDemoable
    {
        public void Demo()
        {
            try
            {
                Pool.Acquire(100);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("OOM");
            }
            catch (TypeInitializationException ex)
            {
                Console.WriteLine("Wrapped!" + ex.InnerException);
            }
        }

        static class Pool
        {
            static byte[] buffer;

            static Pool()
            {
                buffer = new byte[int.MaxValue];
            }

            public static byte[] Acquire(int length) => null;
        }
    }
}