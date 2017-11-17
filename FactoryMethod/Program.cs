using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager(new LoggerFactory());
            cm.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory //1. fabrika
    {
        public ILogger CreateLogger()
        {
            //burada web config den bakıp duruma göre text veya veritabanına kaydetme işlemi yapılabilir. Örn: Log4Net, NLog
            return new ElmahLogger();
        }

    }

    public class LoggerFactory2 : ILoggerFactory //2. fabrika
    {
        public ILogger CreateLogger()
        {
            //burada web config den bakıp duruma göre text veya veritabanına kaydetme işlemi yapılabilir. Örn: Log4Net, NLog
            return new Log4NetLogger();
        }

    }


    public interface ILoggerFactory
    {
         ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class ElmahLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with elmah");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    public class CustomerManager
    {
        //DI
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
