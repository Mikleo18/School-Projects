using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.DependecyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>() 
        {
            var kernel =new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
            
        }
    }
}
