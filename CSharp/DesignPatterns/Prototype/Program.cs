using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { FirstName="Mikleo",LastName="Edna",city="Petrichor V",id=18};
            
            

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Zenci";

            Console.Write(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.WriteLine("Xd");

            Console.ReadLine();
        }

        public abstract class person
        {
            public abstract person Clone();
            public int id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }

        public class Customer : person
        {
            public string city { get; set; }

            public override person Clone()
            {
                return (person)MemberwiseClone();
            }
        }

        public class Employee : person
        {
            public decimal salary { get; set; }

            public override person Clone()
            {
                return (person)MemberwiseClone();
            }
        }
    }
}
