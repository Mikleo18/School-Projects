using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void log(string message)
        {
            Console.WriteLine("Log with Log4Net");
        }
    }

    public class NLogger : Logging
    {
        public override void log(string message)
        {
            Console.WriteLine("Log with Nlogger");
        }
    }

    public abstract class caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    public class NiCache : caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with NiCache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override caching CreateCaching()
        {
            return new NiCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _CrossCuttingConcernsFactory;
        private Logging _Logging;
        private caching _Caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _CrossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _Logging = _CrossCuttingConcernsFactory.CreateLogger();
            _Caching = _CrossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _Logging.log("Logged");
            _Caching.Cache("Data");
            Console.WriteLine("Product Listed");
        }
    }
}
