using System;
using System.Collections.Generic;

namespace EmployeeDues
{
    class Program
    {
        private static string input { get; set; }
        private static readonly string[] choiceCheck = new string[]
        {
            "1",
            "2",
            "3",
            "temp",
            "parttime",
            "fulltime",
        };
        
        static void Main(string[] args)
        {
            //Have the program prompt the user to enter the type of employee(from a list of employee types).
            myEmployeeChoice();
            Employee myEmploymentType = new Employee(input);
            //The program should also prompt the user to enter the number of meals being purchased.
            myLunchDues(myEmploymentType);
        }

        private static void myEmployeeChoice()
        {
            Console.Clear();
            Console.WriteLine("What Type of Employee Are You?");
            Console.WriteLine("1. Temp");
            Console.WriteLine("2. PartTime");
            Console.WriteLine("3. FullTime");
            Console.Write($"Employee Type: ");

            input = Console.ReadLine().ToLower();

            while(!Array.Exists(choiceCheck, type => type == input))
            {
                Console.Write("Please type the correct Employee Type: ");
                input = Console.ReadLine().ToLower();
            }
        }

        private static void myLunchDues(Employee me)
        {
            Console.Clear();
            Console.WriteLine("Employment Dues Calculator---");
            Console.WriteLine("The following types owe their appended amount:");
            Console.WriteLine("Full Time : $0");
            Console.WriteLine("Part Time : $1.50");
            Console.WriteLine("Temp : $2.75");
            Console.WriteLine($"You are a {me.employeeType}");
            Console.WriteLine($"The Current Dues You Own Are ${me.calculateDues()}");
        }
    }

    class Employee
    {
        public string employeeType { get; set; }
        private readonly Dictionary<string, double> employeeList = new Dictionary<string, double>()
        {
            ["temp"] = 2.75,
            ["parttime"] = 1.50,
            ["fulltime"] = 0,
        };

        private readonly DateTime dt = new DateTime();

        public Employee(string employeeType)
        {
            switch (employeeType)
            {
                case "1":
                    employeeType = "temp";
                    break;
                case "2":
                    employeeType = "parttime";
                    break;
                case "3":
                    employeeType = "fulltime";
                    break;
                default:
                    break;
            }
            this.employeeType = employeeType;
        }

        public double calculateDues()
        {
            return employeeList[employeeType] * DateTime.DaysInMonth(dt.Year, dt.Month); 
        }
    }
}
