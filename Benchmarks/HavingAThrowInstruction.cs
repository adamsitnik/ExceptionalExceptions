using System;
using BenchmarkDotNet.Attributes;
// ReSharper disable All

namespace Benchmarks
{
    public class HavingAThrowInstruction
    {
        private readonly Result<int> result = new Result<int>(123);

        [Benchmark(Baseline = true)]
        public int SimpleProperty() => result.SimpleProperty;

        [Benchmark]
        public int ResultWithThrowInstruction() => result.ResultWithThrow();

        [Benchmark]
        public int ResultWithThrowInSeparateMethod() => result.ResultWithThrowInSeparateMethod();
    }

    public struct Result<T>
    {
        private readonly T value;
        private readonly Exception exception;

        public Result(T value, Exception error = null)
        {
            this.value = value;
            exception = error;
        }

        internal T SimpleProperty => value;

        internal T ResultWithThrow()
        {
            if (exception != null)
                throw exception;

            return value;
        }

        internal T ResultWithThrowInSeparateMethod()
        {
            if (exception != null)
                Throw();

            return value;
        }

        private void Throw()
        {
            throw exception;
        }
    }
}