using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomManager customManager = new CustomManager();
            customManager.CreditCalculatorBase = new After2010CreditCalculator();
            customManager.SaveCredit();

            // önce 2010 dan öncesini daha sonrada 2010 dan sonrasını hesaplayabiliriz
            customManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customManager.SaveCredit();

            Console.ReadLine();
        }

        abstract class CreditCalculatorBase
        {
            public abstract void Calculate();
        }

        class Before2010CreditCalculator : CreditCalculatorBase
        {
            public override void Calculate()
            {
                Console.WriteLine("Credit calculated using before 2010");
            }
        }

        class After2010CreditCalculator : CreditCalculatorBase
        {
            public override void Calculate()
            {
                Console.WriteLine("Credit calculated using after 2010");
            }
        }

        class CustomManager
        {
            // base sınıfını prop olarak verdik ve metodda kullandık. Desene ne verirsek onu hesaplar if else yapısından kurutlmuş ve nesnel bir kod yazmış oluruz
            // burada property vermek yerine dependency injection ilede çözebilirdik
            public CreditCalculatorBase CreditCalculatorBase { get; set; }

            public void SaveCredit()
            {
                Console.WriteLine("customer manager business");
                CreditCalculatorBase.Calculate();
            }
        }
    }
}
