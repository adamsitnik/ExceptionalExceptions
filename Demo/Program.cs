﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new TypeInitializationExceptionSample().Demo();
            //new AsyncAwaitAggregatedException().Demo().Wait();
        }
    }
}
