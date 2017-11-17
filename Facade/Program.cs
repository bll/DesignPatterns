using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            // facade kullandığım manager nesnesi.
            CustomerManagar customerManagar = new CustomerManagar();
            customerManagar.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void ChekUser()
        {
            Console.WriteLine("User checked");
        }
    }

    interface IAuthorize
    {
        void ChekUser();
    }

    class CustomerManagar
    {

        private CrossCuttingConcernsFacade _concerns;

        public CustomerManagar()
        {
            // facade ile CrossCuttingConcernsFacade sınıfında topladığımız sınıfları tek yerden kullandık.
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.ChekUser();

            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
