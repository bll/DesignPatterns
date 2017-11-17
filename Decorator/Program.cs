using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar{Make = "Audi",Model = "A4",HirePrice = 2500};

            SpecialOffer specialOffer = new SpecialOffer(personalCar);

            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Concrete : {0}",personalCar.HirePrice);

            //Decoretor pattern uyguladığım specialOffer %10 indirim uyguluyorum

            Console.WriteLine("Special offer : {0}",specialOffer.HirePrice);

            Console.ReadKey();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }


    //Decorator pattern
    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        public CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }

        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage / 100;
            }
            set
            {

            }
        }
    }
}
