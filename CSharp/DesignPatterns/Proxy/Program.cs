﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creditbase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadLine();
        }

        abstract class Creditbase
        {
            public abstract int Calculate();
        }

        class CreditManager : Creditbase
        {
            public override int Calculate()
            {
                int result = 1;
                for (int i = 1; i < 5; i++)
                { 
                    result *= i;
                    Thread.Sleep(1000);
                }
                return result;
            }
        }

        class CreditManagerProxy : Creditbase
        {
            private CreditManager _creditManager;
            private int _cachedValue;
    
            public override int Calculate()
            {
                if (_creditManager == null) 
                {
                    _creditManager = new CreditManager();  
                    _cachedValue = _creditManager.Calculate();
                }
                return _cachedValue;
            }
        }
    }

}
