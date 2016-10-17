using System;
using System.Reflection.Emit;

namespace Demo
{
    public class ThrowingAnything : IDemoable
    {
        public void Demo()
        {
            try
            {
                Action<string> throwingMethod = ThrowAnythingMethodBuilder.BuildThrowingMethod<string>();

                throwingMethod.Invoke("I can throw whatever I want");
            }
            catch (Exception wrappedException)
            {
                Console.WriteLine(wrappedException.Message);
            }
        }
    }

    public class ThrowAnythingMethodBuilder
    {
        public static Action<TThrown> BuildThrowingMethod<TThrown>()
        {
            var dynamicMethod = new DynamicMethod(
                "Throw",
                returnType: typeof(void),
                parameterTypes: new[] { typeof(TThrown) });

            var cilGenerator = dynamicMethod.GetILGenerator();
            cilGenerator.Emit(OpCodes.Ldarg_0); // load the argument
            cilGenerator.Emit(OpCodes.Throw); // throw whatever it is!

            return (Action<TThrown>)dynamicMethod.CreateDelegate(typeof(Action<TThrown>));
        }
    }
}