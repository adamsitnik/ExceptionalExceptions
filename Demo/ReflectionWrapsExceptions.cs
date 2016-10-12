using System;
using System.Reflection;

// ReSharper disable All

namespace Demo
{
    public class ReflectionWrapsExceptions
    {
        public void Demo()
        {
            var method = typeof(Calc).GetMethod("Sum", BindingFlags.Static | BindingFlags.NonPublic);
            try
            {
                var result = method.Invoke(
                    null,
                    new object[]
                    {
                        int.MaxValue,
                        int.MaxValue
                    });
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine("Reflection wraps all exceptions!" + ex.InnerException);
            }
        }

        class Calc
        {
            static int Sum(int left, int right) => checked(left + right);
        }
    }
}