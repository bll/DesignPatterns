using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver); // müşterileri bilgilendir
            productManager.Attach(new EmployeeObserver()); // çalışanları bilgilendir

            productManager.Detach(customerObserver); // kullanıcıları listeden çıkar
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        //bu işleme abone olan kullanıcılar
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify(); // indirim olunca aboneleri bilgilendir
        }

        // desenin bizden istediği
        // aboneliğe ekleme
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        // abonelikten çıkarma
        public void Detach(Observer observer)
        {
            _observers.Add(observer);
        }

        //bilgilendirme
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer: Product price changed");
            // indirim olursa ilgili üyelere mesaj gönderebiliriz.
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee: Product price changed");
        }
    }
}
