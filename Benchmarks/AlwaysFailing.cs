using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
// ReSharper disable All

namespace Benchmarks
{
    public class AlwaysFailing
    {
        private readonly Exception exception = new Exception();

        [Benchmark(Baseline = true)]
        public void ThrowAndCatch()
        {
            try
            {
                throw exception;
            }
            catch (Exception)
            {
            }
        }

        [Benchmark]
        public Result<int> ReturnFailure()
        {
            return new Result<int>(default(int), exception);
        }

        [Benchmark]
        public bool TryOut()
        {
            int value;
            return TryGetValue(out value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool TryGetValue(out int value)
        {
            value = default(int);
            return false;
        }
    }
}