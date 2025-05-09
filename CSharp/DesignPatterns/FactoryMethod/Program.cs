using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager manager = new CustomerManager(new LoggerFactory2());
            manager.save();

            Console.ReadLine();
        }

    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new NiLogger();
        }

    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new SiLogger();
        }

    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void log();
    }

    public class NiLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged with Nilogger");
        }
    }

    public class SiLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged with Silogger");
        }
    }

    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory) 
        {
            _loggerFactory = loggerFactory;
        }
        public void save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.log();
        }
    }
}
