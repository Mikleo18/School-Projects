using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependecyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member { Email="seyupaltas02@gmail.com",FirstName="Selahattin",LastName="Altaş",DateOfBirth=new DateTime(2002,11,26),TcNo="*****"});
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
