using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Switch
            (
                args,
#if !CORE
                new SuccessfulCER(),
                new FailingCER(),
                new SEHExceptions(),
                new HandleStackOverflow(),
                new ThreadAbortExceptionDemo(),
#endif
                new AggregateExceptionSample(),
                new AsyncAwaitAggregatedException(),
                new DynamicDoesNotWrapExceptions(),
                new ExceptionInFinally(),
                new FireForgetAndFail(),
                new ReflectionWrapsExceptions(),
                new TypeInitializationExceptionSample(),
                new ThrowingAnything()
            );

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to terminate");
                Console.ReadKey();
            }
        }

        static void Switch(string[] args, params IDemoable[] demos)
        {
            var input = GetNumber(args, demos);
            int number = 0;
            if (int.TryParse(input, out number) && number < demos.Length)
                demos[number].Demo();
        }

        private static string GetNumber(string[] args, IDemoable[] demos)
        {
            if (args.Any())
                return args[0];

            for (int i = 0; i < demos.Length; i++)
            {
                Console.WriteLine($"#{i} {demos[i].GetType().GetTypeInfo().Name}");
            }
            Console.WriteLine();

            Console.WriteLine("Please select the demo by putting it's number here:");
            return Console.ReadLine()?.Replace("#", string.Empty);
        }
    }
}
