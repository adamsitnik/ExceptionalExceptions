using System;
using System.Reflection;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Switch
            (
#if !CORE
                new SuccessfulCER(),
                new FailingCER(),
                new SEHExceptions(),
#endif
                new AggregateExceptionSample(),
                new AsyncAwaitAggregatedException(),
                new DynamicDoesNotWrapExceptions(),
                new ExceptionInFinally(),
                new FireForgetAndFail(),
                new ReflectionWrapsExceptions(),
                new TypeInitializationExceptionSample()
            );

            Console.ReadKey();
        }

        static void Switch(params IDemoable[] demos)
        {
            for (int i = 0; i < demos.Length; i++)
                Console.WriteLine($"#{i} {demos[i].GetType().GetTypeInfo().Name}");

            Console.WriteLine("Please select the demo by putting it's number here:");
            var input = Console.ReadLine()?.Replace("#", String.Empty);
            int number = 0;
            if (int.TryParse(input, out number) && number < demos.Length)
                demos[number].Demo();
        }
    }
}
