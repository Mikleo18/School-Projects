using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager ridvan = new Manager { Name ="Rıdvan",Salary = 2000};
            Manager musa = new Manager { Name="Musa",Salary = 1700};
            Worker selo = new Worker { Name="Selo",Salary= 1000};
            Worker Ali = new Worker { Name="Ali",Salary=1000};

            ridvan.subordinates.Add(musa);
            musa.subordinates.Add(Ali);
            musa.subordinates.Add(selo);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(ridvan);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayRise payRise = new PayRise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payRise);

           
            Console.ReadLine();

        }
    }
    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstemployeebase)
        {
            Employee = firstemployeebase;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public String Name { get; set; }
        public decimal Salary { get; set; }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class PayRise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary rised to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary rised to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee  in subordinates) 
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
}
