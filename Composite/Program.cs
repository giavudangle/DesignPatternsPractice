using System;
using System.Collections.Generic;

namespace Composite
{
    #region Component Abstract Soft Drink
    public abstract class SoftDrink
    {
        public int Calories { get; set; }
        public List<SoftDrink> Flavors { get; set; }
        public SoftDrink(int calories)
        {
            Calories = calories;
            Flavors = new List<SoftDrink>();
        }

        public void DisplayCalories()
        {
            Console.WriteLine(this.GetType() + ":" + this.Calories.ToString() + " calories.");
            foreach(var drink in this.Flavors)
            {
                drink.DisplayCalories();
            }
        }
    }
    #endregion
    #region Cola's Leaf Classes
    public class VanillaCola : SoftDrink
    {
        public VanillaCola(int calories) : base(calories)
        {

        }

    }

    public class CherryCola : SoftDrink
    {
        public CherryCola(int calories) : base(calories)
        {

        }

    }
    #endregion
    #region RootBeer's Leaf Classes
    public class StrawberryRootBeer : SoftDrink
    {
        public StrawberryRootBeer(int calories) : base(calories)
        {

        }

    }

    public class VanillaRootBeer : SoftDrink
    {
        public VanillaRootBeer(int calories) : base(calories)
        {

        }
    }
    #endregion
    #region Lime's Leaf Classes
    public class LemonLime : SoftDrink
    {
        public LemonLime(int calories) : base(calories)
        {

        }

    }
    #endregion
    #region  Composite
    public class Cola : SoftDrink
    {
        public Cola(int calories) : base(calories)
        {
        }
    }
    public class RootBeer : SoftDrink
    {
        public RootBeer(int calories) : base(calories)
        {
        }
    }

    public class SodaWater : SoftDrink
    {
        public SodaWater(int calories) : base(calories)
        {
        }
    }

    #endregion
    #region Main
    class Program
    {
        static void Main(string[] args)
        {
            // Colas family
            var colas = new Cola(210);
            colas.Flavors.Add(new VanillaCola(215));
            colas.Flavors.Add(new CherryCola(210));

            // LemonLime family
            var lemonLime = new LemonLime(185);

            // Root beers family
            var rootBeers = new RootBeer(195);
            rootBeers.Flavors.Add(new VanillaRootBeer(200));
            rootBeers.Flavors.Add(new StrawberryRootBeer(200));

            // Compose 3 families
            SodaWater sodaWater = new SodaWater(180);
            sodaWater.Flavors.Add(colas);
            sodaWater.Flavors.Add(lemonLime);
            sodaWater.Flavors.Add(rootBeers);

            sodaWater.DisplayCalories();


        }
    }
    #endregion
}
