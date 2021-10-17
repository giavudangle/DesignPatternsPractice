using System;

namespace Prototype
{
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    public class ConcretePrototypeOne : Prototype
    {
        public string Name { get; set; }
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone(); // Shallow copy
        }
    }


    public class ConcretePrototypeTwo : Prototype
    {
        public int Age { get; set; }
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone(); // Shallow copy
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototypeOne concretePrototypeOne = new ConcretePrototypeOne();
            concretePrototypeOne.Name = "Vudang";
            ConcretePrototypeOne clonedPrototypeOne = (ConcretePrototypeOne)concretePrototypeOne.Clone();
            Console.WriteLine(clonedPrototypeOne.Name);
            concretePrototypeOne.Name = "Foolish";
            Console.WriteLine(concretePrototypeOne.Name);
            Console.WriteLine(clonedPrototypeOne.Name);

        }
    }
}
