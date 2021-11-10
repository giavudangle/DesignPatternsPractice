using System;
using System.Collections.Generic;

namespace CompositeMixStrategy
{

    // Migrate from interface to abstract class Worker

    public abstract class Worker
    {
        public List<Worker> WorkerList { get; set; }
        public ISalaryStrategy Strategy { get; set; }

        public String name { get; set; }
        public long id { get; set; }
        public int workingDay { get; set; }
        public int salaryPerDay { get; set; }

        private int c = 0;


        public abstract double getFinalSalary();


        public int countByName(string name)
        {
            c = this.Strategy.count(this.WorkerList, name);
            foreach (var w in this.WorkerList)
            {
                w.Strategy = this.Strategy;
                c += w.countByName(name);
            }
            return c;
        }

        public Worker()
        {
            WorkerList = new List<Worker>();
        }

        public virtual void Display()
        {
            Console.WriteLine($"Name : {name}" +
                $"Id : {id}" +
                $"workingDay : {workingDay}" +
                $"salaryPerDay : {id}"
                );
        }


        public void DisplayAllWorker()
        {
            this.Display();
            foreach (var w in this.WorkerList)
            {
                w.DisplayAllWorker();
            }
        }

    }


    // 3 Lớp chính dùng dựng lên toàn bộ cây Composite
    class Constructor : Worker
    {
        public double baseSalary { get; set; }
        public Constructor(long id, String name, int workingDay, int salaryPerDay, int
        baseSalary)
        {
            this.id = id;
            this.name = name;
            this.workingDay = workingDay;
            this.salaryPerDay = salaryPerDay;
            this.baseSalary = baseSalary;
        }


        public void showDetails()
        {
            Console.WriteLine(id + " " + name + " " + workingDay + " " + salaryPerDay + " " +
           baseSalary);
        }

        public override void Display()
        {
            Console.WriteLine("Constructor");
            base.Display();
            Console.WriteLine($"Base Salary: {baseSalary}");
        }

        public override double getFinalSalary()
        {
            return this.Strategy.getSalary(this.workingDay, this.salaryPerDay, this.baseSalary);
        }
    }

    class Manager : Worker
    {
        public Manager(long id, String name, int workingDay, int salaryPerDay)
        {
            this.id = id;
            this.name = name;
            this.workingDay = workingDay;
            this.salaryPerDay = salaryPerDay;
        }

        public override double getFinalSalary()
        {
            return this.Strategy.getSalary(this.workingDay, this.salaryPerDay);
        }

        public void showDetails()
        {
            Console.WriteLine(id + " " + name + " " + workingDay + " " + salaryPerDay);
        }


    }
    class Director : Worker
    {

        public double bonus { get; set; } // từ 0 đến 1

        public Director(long id, String name, int workingDay, int salaryPerDay, double bonus)
        {
            this.id = id;
            this.name = name;
            this.workingDay = workingDay;
            this.salaryPerDay = salaryPerDay;
            this.bonus = bonus;
        }


        public void showDetails()
        {
            Console.WriteLine(id + " " + name + " " + workingDay + " " + salaryPerDay + " " +
           bonus);
        }

        public override void Display()
        {
            Console.WriteLine($"Director");
            base.Display();
            Console.WriteLine($"Bonus : {bonus}");

        }

        public override double getFinalSalary()
        {
            return this.Strategy.getSalary(this.workingDay, this.salaryPerDay, 0, this.bonus);
        }
    }




    // Strategy thực hiện tính tổng lương của công ty trong tháng

    public interface ISalaryStrategy
    {
        public double getSalary(double workingDay, double salaryPerDay, double? baseSalary = 0, double? bonus = 0);
        public int count(List<Worker> employees, string term);
    }


    public class DirectorSalaryStrategy : ISalaryStrategy
    {
        public int count(List<Worker> employees, string term)
        {
            return 0;
        }

        public double getSalary(double workingDay, double salaryPerDay, double? baseSalary, double? bonus)
        {
            return (double)(workingDay * salaryPerDay * (1 + bonus));
        }
    }

    public class ManagerSalaryStrategy : ISalaryStrategy
    {
        public int count(List<Worker> employees, string term)
        {
            return 0;
        }

        public double getSalary(double workingDay, double salaryPerDay, double? baseSalary, double? bonus)
        {
            return workingDay * salaryPerDay;
        }
    }

    public class ConstructorSalaryStrategy : ISalaryStrategy
    {
        public int count(List<Worker> employees, string term)
        {
            return 0;
        }

        public double getSalary(double workingDay, double salaryPerDay, double? baseSalary, double? bonus)
        {
            return (double)(baseSalary + workingDay * salaryPerDay);
        }
    }

    // Strategy để đếm số lượng người có tên là Tommy

    public class CountingNameStrategy : ISalaryStrategy
    {
        public int count(List<Worker> employees, string term)
        {
            int c = 0;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].name.Equals(term))
                {
                    c++;
                }
            }
            return c;
        }

        public double getSalary(double workingDay, double salaryPerDay, double? baseSalary, double? bonus)
        {
            return 0;
        }
    }




    // Composite
    // 1. Director composite
    // 2. Manager composite 
    // 3. Constructor composite


    internal class Program
    {
        static void Main(string[] args)
        {
            // Tầng root Director Composition (1 constructor , 2 manager)
            var directorComposition = new Director(1, "Manager", 10, 10, 0.5);
            directorComposition.WorkerList.Add(new Constructor(1, "Tommy", 10, 10, 10));
            var manager_one = new Manager(1, "Tommy", 10, 20);
            directorComposition.WorkerList.Add(manager_one);
            var manager_two = new Manager(1, "Tommy", 10, 20);
            directorComposition.WorkerList.Add(manager_two);

            // Manager 1 ( tầng 1)
            manager_one.WorkerList.Add(new Constructor(1, "Tommy", 10, 10, 10));
            manager_one.WorkerList.Add(new Constructor(2, "Tommy", 10, 10, 10));
            var manager_leaf_one = new Manager(1, "Manager Leaf One", 10, 20); // Manager tầng 2 - manager 1
            manager_leaf_one.WorkerList.Add(new Constructor(1, "Construtor of manager_leaf_one", 10, 10, 10));
            manager_leaf_one.WorkerList.Add(manager_leaf_one);

            // Manager 2 ( tầng 1)
            manager_two.WorkerList.Add(new Constructor(1, "Tommy", 10, 10, 10));
            manager_two.WorkerList.Add(new Constructor(1, "Tommy", 10, 10, 10));

            directorComposition.DisplayAllWorker();

            DirectorSalaryStrategy directorSalaryStrategy = new DirectorSalaryStrategy();
            ManagerSalaryStrategy managerSalaryStrategy = new ManagerSalaryStrategy();
            ConstructorSalaryStrategy constructorSalaryStrategy = new ConstructorSalaryStrategy();
            CountingNameStrategy countingNameStrategy = new CountingNameStrategy();


            directorComposition.Strategy = directorSalaryStrategy;
            var t = directorComposition.getFinalSalary();
            directorComposition.Strategy = countingNameStrategy;
            var l = directorComposition.countByName("Tommy");

            //Console.WriteLine(t);
            Console.WriteLine(l);

        }
    }


}
