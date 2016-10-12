#if !CORE
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Demo
{
    public class SEHExceptions
    {
        [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf(StringBuilder buffer, string format, __arglist);

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public void Demo()
        {
            try
            {
                var buffer = new StringBuilder();

                sprintf(buffer, "This requires two numbers %d %d", __arglist(10));
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("Caught AccessViolationException");
            }
            catch (SEHException)
            {
                Console.WriteLine("Caught SEHException");
            }
        }
    }
}

#endif