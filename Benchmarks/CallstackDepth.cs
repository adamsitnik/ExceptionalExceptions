using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class CallstackDepth
    {
        private readonly Exception exception = new Exception();

        [Benchmark(Baseline = true)]
        public void Depth0() { try { throw exception; } catch (Exception) { } }

        [Benchmark]public void Depth1() { try { Throw(); } catch (Exception) { } }
        [Benchmark]public void Depth2() { try { ThrowDepth2(); } catch (Exception) { } }
        [Benchmark]public void Depth3() { try { ThrowDepth3(); } catch (Exception) { } }
        [Benchmark]public void Depth4() { try { ThrowDepth4(); } catch (Exception) { } }
        [Benchmark]public void Depth5() { try { ThrowDepth5(); } catch (Exception) { } }
        [Benchmark]public void Depth6() { try { ThrowDepth6(); } catch (Exception) { } }

        [MethodImpl(MethodImplOptions.NoInlining)]void Throw() { throw exception;}
        [MethodImpl(MethodImplOptions.NoInlining)]void ThrowDepth2() => Throw();
        [MethodImpl(MethodImplOptions.NoInlining)]void ThrowDepth3() => ThrowDepth2();
        [MethodImpl(MethodImplOptions.NoInlining)]void ThrowDepth4() => ThrowDepth3();
        [MethodImpl(MethodImplOptions.NoInlining)]void ThrowDepth5() => ThrowDepth4();
        [MethodImpl(MethodImplOptions.NoInlining)]void ThrowDepth6() => ThrowDepth5();
    }
}