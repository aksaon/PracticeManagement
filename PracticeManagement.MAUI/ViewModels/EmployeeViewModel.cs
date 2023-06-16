﻿using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.MAUI.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Employee>(EmployeeService.Current.Employees);
                }
                return new ObservableCollection<Employee>(EmployeeService.Current.Search(Query));
            }
        }
        public string Query { get; set; }
        public void Search()
        {
            NotifyPropertyChanged("Employees");
        }
        public void Delete()
        {
            if (SelectedEmployee == null)
            {
                return;
            }
            EmployeeService.Current.Delete(SelectedEmployee.Id);
            NotifyPropertyChanged("Employees");
            SelectedEmployee = null;
        }
        public void Add(Shell s)
        {
            s.GoToAsync($"//EmployeeDetails?employeeId=0");
        }
        public void Edit(Shell s)
        {
            if (SelectedEmployee == null)
            {
                return;
            }
            var idParam = SelectedEmployee.Id;
            s.GoToAsync($"//EmployeeDetails?employeeId={idParam}");
        }
        public Employee SelectedEmployee { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Employees));
        }
    }
}
