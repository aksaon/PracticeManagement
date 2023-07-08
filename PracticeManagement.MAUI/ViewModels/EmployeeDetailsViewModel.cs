using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeeDetailsViewModel : INotifyPropertyChanged
    {
        public string name { get; set; }
        public double rate { get; set; }
        public int Id { get; set; }

        public EmployeeDetailsViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var employee = EmployeeService.Current.Get(id) as Employee;
            if (employee != null)
            {
                name = employee.Name;
                rate = employee.Rate;
                Id = employee.Id;
            }

            NotifyPropertyChanged(nameof(name));
            NotifyPropertyChanged(nameof(rate));
        }
        public void AddProject()
        {
            
            if (Id <= 0) // Add new Employee
            {
                EmployeeService.Current.Add(new Employee { Id = EmployeeService.Current.Get_Next_Id(),Name = name, Rate = rate });
            }
            else // Edit Employee
            {
                var refToUpdate = EmployeeService.Current.Get(Id) as Employee;
                refToUpdate.Name = name;
                refToUpdate.Rate = rate;
            }
            Shell.Current.GoToAsync("//Employees");
        }

    }
}
