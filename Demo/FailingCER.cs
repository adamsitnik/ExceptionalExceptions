#if !CORE
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace Demo
{
    public class FailingCER : IDemoable
    {
        public void Demo()
        {
            try
            {
                FailingMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FailingMethod()
        {
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Console.WriteLine("Entering try block");
            }
            finally
            {
                TypeWithStaticCtor.MethodCalledFromFinally();
            }
        }

        static class TypeWithStaticCtor
        {
            static TypeWithStaticCtor() { throw new Exception("thrown from Static ctor");  } 

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            public static void MethodCalledFromFinally() { }
        }
    }
}
#endif