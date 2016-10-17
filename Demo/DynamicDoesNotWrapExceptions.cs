using System;
using System.Reflection;

// ReSharper disable All

namespace Demo
{
    public class DynamicDoesNotWrapExceptions : IDemoable
    {
        public void Demo()
        {
            dynamic instance = Activator.CreateInstance<Calc>();
            try
            {
                var result = instance.Sum(int.MaxValue, int.MaxValue);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine("Got wrapped" + ex.InnerException);
            }
        }

        public class Calc
        {
            public int Sum(int left, int right) => checked(left + right);
        }
    }
}