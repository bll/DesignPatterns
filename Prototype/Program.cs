using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { FirstName = "Bilal", LastName = "Yanık", City = "İstanbul", Id = 1 };

            var customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Ali";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.ReadLine();

        }

        public abstract class Person
        {
            //temel nesneyi prototype haline getirebilmek için soyut bir clone metodundan besleniyor olması gerekir
            public abstract Person Clone();

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }

        public class Customer : Person
        {
            public string City { get; set; }

            public override Person Clone()
            {
                return (Person)MemberwiseClone();
            }
        }
        public class Employee : Person
        {
            public string Salary { get; set; }

            public override Person Clone()
            {
                return (Person)MemberwiseClone();
            }
        }
    }
}
