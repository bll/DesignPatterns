using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
            Console.ReadKey();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object(); // theread safe  singleton
        public CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //nesne ilk defa oluşturuluyorsa ve birden fazla kullanıcı aynı anda nesneyi oluşturmasını  önlemek amacıyla kullanılır.
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }


            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");

        }
    }
}
