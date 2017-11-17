using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // sonsuz hiyerarşi kurabiliriz
            Employee bilal = new Employee { Name = "bilal" };
            Employee mesut = new Employee { Name = "mesut" };

            bilal.AddSuboridinate(mesut);

            Employee veysel = new Employee { Name = "veysel" };

            bilal.AddSuboridinate(veysel);

            Employee turhan = new Employee { Name = "türhan" };

            veysel.AddSuboridinate(turhan);


            Contractor metin = new Contractor{Name = "Metin"};

            veysel.AddSuboridinate(metin);

            Console.WriteLine(bilal.Name);
            foreach (Employee manager in bilal)
            {
                Console.WriteLine("  {0}", manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }


            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
       public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSuboridinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSuboridinate(IPerson person)
        {
            _subordinates.Remove(person);
        }


        public IPerson GetSubOridinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var suboridinate in _subordinates)
            {
                yield return suboridinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
