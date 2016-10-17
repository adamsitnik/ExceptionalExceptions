#if !CORE
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace Demo
{
    public class SuccessfulCER : IDemoable
    {
        public void Demo()
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
            static TypeWithStaticCtor() { Console.WriteLine("Static ctor got called");  } 

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            public static void MethodCalledFromFinally() { }
        }
    }
}
#endif