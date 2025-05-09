using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make="Toyota",HirePrice=3500,Model="3.31"};

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 15;

            Console.WriteLine("Special Offer : {0}", specialOffer.HirePrice);
            Console.WriteLine("Concrete : {0}", personalCar.HirePrice);

            Console.ReadLine();

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

    abstract class CarDecaratorBase:CarBase
    {
        private CarBase _carbase;

        protected CarDecaratorBase(CarBase carbase)
        {
            _carbase = carbase;
        }
    }

    class SpecialOffer : CarDecaratorBase
    {
        public int DiscountPercentage { get; set; }
        private CarBase _carbase;
        public SpecialOffer(CarBase carbase) : base(carbase)
        {
            _carbase = carbase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice {get {return _carbase.HirePrice -_carbase.HirePrice*DiscountPercentage / 100; }set {} }
    }
}
