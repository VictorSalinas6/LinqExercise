using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            var sumOfList = numbers.Sum();
            Console.WriteLine($"The sum of the list is: {sumOfList}");

            //TODO: Print the Average of numbers
            var averageOfList = numbers.Average();
            Console.WriteLine($"The average of the list is: {averageOfList}");

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("The list in ascending order is: ");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            //TODO: Order numbers in descending order and print to the console

            Console.WriteLine("The list in descending order is: ");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("The numbers on the list that are greater than 6 are: ");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("Ordered the list, then just show 4 of them: ");
            var orderThen4 = numbers.OrderBy(x => x);
            int c = 0;
            foreach (int x  in orderThen4)
            {
                if (c < 4)
                {
                    Console.Write($"{x} ");
                    c++;
                }
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Changed the index 4 to my age, the new list in descending order is: ");
            numbers[4] = 30;
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            Console.WriteLine();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("List of employees which name starts with the letter C or S in order: ");
            var employeesStartingC = employees.Where(x => x.FirstName.StartsWith("C"));
            var employeesStartingS = employees.Where(x => x.FirstName.StartsWith("S"));
            var employeesStartingCS = employeesStartingC.Concat(employeesStartingS);
            employeesStartingCS.OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine($"{x.FullName}"));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("\nList of employees which are older than 26 in order: ");
            var employees26 = employees.Where(x => x.Age > 26);
            employees26.OrderBy(x => x.Age).OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine($"{x.FullName}"));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("\nThe result of the sum of the Years of Experience of employees older than 35 and less YOE than 11 is : ");
            var employeesYOEAdd = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);
            Console.WriteLine(employeesYOEAdd);

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("\nThe result of the average of the Years of Experience of employees older than 35 and less YOE than 11 is : ");
            var employeesYOEAvg = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience);
            Console.WriteLine($"{(int)employeesYOEAvg} (Exact number: {employeesYOEAvg})");

            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee { FirstName = "Victor", LastName = "Salinas", Age = 30, YearsOfExperience = 2 }).ToList();
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
