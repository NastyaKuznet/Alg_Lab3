﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class TestPostfixCalculator
    {
        public void Start()
        {
            PostfixCalculator calc = new PostfixCalculator("2 * ( 1 + 2 )");
            calc.Calculate(false);
            Console.WriteLine(calc.GetResult());
            
        }
    }
}
