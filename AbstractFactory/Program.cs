using System;

namespace AbstractFactory
{
    public interface IPerson
    {
        string GetName();
    }

    public class Villager : IPerson
    {
        public string GetName()
        {
            return "Village Person";
        }
    }

    public class CityPerson : IPerson
    {
        public string GetName()
        {
            return "City Person";
        }

    }

    public enum PersonType
    {
        Rural,
        Urban
    }

    /// <summary>
    /// Implementation of Factory - Used to create objects.
    /// </summary>
    public class Factory
    {
        public IPerson GetPerson(PersonType type)
        {
            switch (type)
            {
                case PersonType.Rural:
                    return new Villager();
                case PersonType.Urban:
                    return new CityPerson();
                default:
                    throw new NotSupportedException();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            Console.WriteLine(factory.GetPerson(PersonType.Urban).GetName());
            Console.WriteLine(factory.GetPerson(PersonType.Rural).GetName());

        }
    }
}
