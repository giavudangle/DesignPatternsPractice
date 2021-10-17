using System;

namespace Singleton
{
    public sealed class Singleton
    {
        public static Singleton Instance { get; } = new Singleton();
        private Singleton()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance_one = Singleton.Instance;
            Singleton instance_two = Singleton.Instance;
            Console.WriteLine(instance_one.Equals(instance_two));
        }
    }
}
