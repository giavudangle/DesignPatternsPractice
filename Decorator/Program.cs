using System;

namespace Decorator
{
    public interface IBike
    {
        string GetDetails();
        double GetPrice();
    }

    public class AluminiumBike : IBike
    {
        public string GetDetails()
        {
            return "Aluminium";
        }

        public double GetPrice()
        {
            return 100;
        }
    }

    public class CarbonBike : IBike
    {
        public string GetDetails()
        {
            return "Carbon";
        }

        public double GetPrice()
        {
            return 1000;
        }
    }

    public abstract class BikeAccessories : IBike
    {
        private readonly IBike _bike;
        public BikeAccessories(IBike bike)
        {
            this._bike = bike;
        }

        public virtual string GetDetails()
        {
            return _bike.GetDetails();
        }

        public virtual double GetPrice()
        {
            return _bike.GetPrice();
        }
    }

    public class SecurityPackage: BikeAccessories
    {
        public SecurityPackage(IBike bike) : base(bike) { }
        public override string GetDetails()
        {
            return base.GetDetails() + " -> " + "Security Package";
        }
        public override double GetPrice()
        {
            return base.GetPrice() + 9;
        }
    }

    public class SportPackage : BikeAccessories
    {
        public SportPackage(IBike bike) : base(bike) { }
        public override string GetDetails()
        {
            return base.GetDetails() + " -> " + "Sport Package";
        }
        public override double GetPrice()
        {
            return base.GetPrice() + 99;
        }
    }

    public class BikeShop
    {
        public static void UpgradeBike()
        {
            var basicBike = new AluminiumBike();
            BikeAccessories upgraded = new SportPackage(basicBike);
            upgraded = new SecurityPackage(upgraded);
            Console.WriteLine($"Bike : {upgraded.GetDetails()} -> Cost : {upgraded.GetPrice()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BikeShop.UpgradeBike();  
        }
    }
}
