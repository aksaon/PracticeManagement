using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class EmployeeService
    { 
        private static EmployeeService? instance;
        private static object instanceLock = new object();
        public static EmployeeService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new EmployeeService();
                }

                return instance;
            }
        }
        private List<Employee> employees;
        private EmployeeService()
        {
            employees = new List<Employee>();
        }
        public Employee? Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
        public int Get_Next_Id()
        {
            if (employees.Count == 0)
                return 1;
            return employees.Last().Id + 1;
        }
        public List<Employee> Employees
        {
            get { return employees; }
        }
        public List<Employee> Search(string query)
        {
            return Employees.Where(p => p.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public void Delete(int id)
        {
            var employeeToRemove = Get(id);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }
        }
        public void Read()
        {
            employees.ForEach(Console.WriteLine);
        }
    }
}
