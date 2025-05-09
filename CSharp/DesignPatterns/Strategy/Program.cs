using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.creditCalculatorBase = new Before2010();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010 : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Before2010");
        }
    }
    class After2010 : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("After2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase creditCalculatorBase { get; set; }

    
        public void SaveCredit()
        {
          Console.WriteLine("Saved CustomerManager");
            creditCalculatorBase.Calculate();
        }
    }
}
