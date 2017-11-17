using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //bu yapıda dependency injection ile kullanılabilir deneme için direk nesne türetiyorum
            ProductManager productManager = new ProductManager(new Factory2());//1 fabrikayı kullan
            productManager.GetAll();

            Console.ReadLine();
        }

        public abstract class Logging
        {
            public abstract void Log(string message);
        }

        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with log4net");
            }
        }

        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with nLogger");
            }
        }

        // caching

        public abstract class Caching
        {
            public abstract void Cache(string data);
        }

        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }

        public class RedisCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with RedisCache");
            }
        }

        // duruma göre factory üreten sınıflar

        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }

        //1. durumda loglama olarak log4net cache olarak RedisCache kullanacağım
        // bu yapılar iş süreçleridir
        public class Factory1 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }

            public override Caching CreateCaching()
            {
                return new RedisCache();
            }
        }

        // 2. fabrika

        public class Factory2 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new NLogger();
            }

            public override Caching CreateCaching()
            {
                return new MemCache();
            }
        }

        //bunları kullanacak iş katmanımız

        public class ProductManager
        {
            private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
            private Logging _logging;
            private Caching _caching;
            public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
                _logging = _crossCuttingConcernsFactory.CreateLogger();
                _caching = _crossCuttingConcernsFactory.CreateCaching();
            }

            public void GetAll()
            {

                _logging.Log("logged");
                _caching.Cache("data");
                Console.WriteLine("listed");
            }
        }
    }
}
