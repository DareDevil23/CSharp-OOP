using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CompanyRoster
{
    class CompanyRosterMain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            GetEmployeesData(n, employees);

            IEnumerable<DepartmentAggregation> avgSalaryByDepartment = from department in employees
                                                                       group department.Salary by department.Department
                                                                       into departmentGroup
                                                                       select new DepartmentAggregation
                                                                       {
                                                                           Department = departmentGroup.Key,
                                                                           AverageSalary = departmentGroup.Average()
                                                                       };

            decimal bestSalary = avgSalaryByDepartment.Max(ms => ms.AverageSalary);
            var bestDepartment = avgSalaryByDepartment.Where(ms => ms.AverageSalary == bestSalary).Select(d => d.Department).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            foreach (var emp in employees.Where(e => e.Department == bestDepartment).OrderByDescending(s => s.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:F2} {emp.Email} {emp.Age}");
            }
        }

        private static void GetEmployeesData(int n, List<Employee> employees)
        {
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                decimal salary = decimal.Parse(info[1]);
                string position = info[2];
                string department = info[3];
                string email = "n/a";
                int age = -1;

                if (info.Length > 4)
                {
                    for (int j = info.Length - 1; j >= 4; j--)
                    {
                        if (info[j].Contains("@"))
                            email = info[j];
                        else
                            age = int.Parse(info[j]);
                    }
                }

                Employee employee = new Employee(name, salary, position, department, email, age);
                employees.Add(employee);
            }
        }
    }
}
