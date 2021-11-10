using System;

namespace DesignPatternSolution
{
    public abstract class FruitJuice
    {

        // Primitive Methods (Prototype)
        public abstract double weight();
        public abstract int quantity();
        public abstract int price();
        public abstract string color();

        // Template Methods (TemplateMethod)
        public virtual void print()
        {
            Console.WriteLine($"{GetType().Name} Information : \n" +
               $"weight: {weight()}\n" +
               $"quantity: {quantity()}\n" +
               $"price: {price()}\n" +
               $"color: {color()}"
               );
        }
        public double harvest()
        {
            return weight() * quantity();
        }
        public double total()
        {
            return weight() * quantity() * price();
        }

        public void display()
        {
            print();
            Console.WriteLine($"Harvest : {harvest()}");
            Console.WriteLine($"Total : {total()}");
        }

        // Prototype
        public abstract FruitJuice Clone();
    }

    public class Banana : FruitJuice
    {
        public override FruitJuice Clone()
        {
            return (FruitJuice)this.MemberwiseClone();
        }

        public override string color()
        {
            return "Yellow";
        }

        public override int price()
        {
            return 2000;
        }

        public override int quantity()
        {
            return 15;
        }

        public override double weight()
        {
            return 0.3;
        }
    }

    public class Strawberry : FruitJuice
    {
        public override FruitJuice Clone()
        {
            return (FruitJuice)this.MemberwiseClone();
        }

        public override string color()
        {
            return "Red";
        }

        public override int price()
        {
            return 150;
        }

        public override int quantity()
        {
            return 106;
        }

        public override double weight()
        {
            return 0.01;
        }
    }

    public class Mango : FruitJuice
    {
        public override FruitJuice Clone()
        {
            return (FruitJuice)this.MemberwiseClone();
        }

        public override string color()
        {
            return "Green";
        }

        public override int price()
        {
            return 7000;
        }

        public override int quantity()
        {
            return 7;
        }

        public override double weight()
        {
            return 0.7;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            FruitJuice prototypeBanana = new Banana();
            FruitJuice bananaCloned = prototypeBanana.Clone();
            bananaCloned.display();

            Console.WriteLine("===================================");
            FruitJuice prototypeStrawberry = new Strawberry();
            FruitJuice strawberryCloned = prototypeStrawberry.Clone();
            strawberryCloned.display();

            Console.WriteLine("===================================");
            FruitJuice prototypeMango = new Mango();
            FruitJuice mangoCloned = prototypeMango.Clone();
            mangoCloned.display();
        }
    }
}
