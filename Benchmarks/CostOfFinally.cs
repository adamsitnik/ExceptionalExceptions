using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class CostOfFinally
    {
        [Benchmark]
        public void NoFinally() => EmptyMethod();

        [Benchmark]
        public void Finally()
        {
            try { }
            finally
            {
                EmptyMethod();
            }  
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void EmptyMethod() { }
    }
}