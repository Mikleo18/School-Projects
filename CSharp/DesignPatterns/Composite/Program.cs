using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee rıfat = new Employee { Name="Rıfat"};
            Employee seloş = new Employee { Name = "Seloş" };
            Employee musa = new Employee { Name = "musaisa" };
            Employee Nejat = new Employee { Name = "Nejatİşler" };

            rıfat.AddSubordinates(seloş);
            rıfat.AddSubordinates(musa);
            Nejat.AddSubordinates(rıfat);

            Console.WriteLine(Nejat.Name);
            foreach (Employee manager in Nejat)
            {
                Console.WriteLine("   {0}",manager.Name);

                foreach (Employee employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set;}
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinates(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinates(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
