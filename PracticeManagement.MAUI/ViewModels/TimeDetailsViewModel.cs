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
    public class TimeDetailsViewModel : INotifyPropertyChanged
    {
        public List<Employee> EmployeeList
        {
            get
            {
                return EmployeeService.Current.Employees;
            }
        }
        public List<Project> ProjectList
        {
            get
            {
                return ProjectService.Current.Projects;
            }
        }
        public Employee selectedEmployee { get; set; }
        public Project selectedProject { get; set; }
        public string narrative { get; set; }
        public double hours { get; set; }
        public int Id { get; set; }

        public TimeDetailsViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadByTimeId(id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadByTimeId(int id)
        {
            if (id == 0) { return; }
            var time = TimeService.Current.Get(id) as Time;
            if (time != null)
            {
                Id = time.Id;
                selectedEmployee = EmployeeService.Current.Get(time.EmployeeId);
                selectedProject = ProjectService.Current.Get(time.ProjectId);
                narrative = time.Narrative;
                hours = time.Hours;
            }

            NotifyPropertyChanged(nameof(selectedEmployee));
            NotifyPropertyChanged(nameof(selectedProject));
            NotifyPropertyChanged(nameof(narrative));
            NotifyPropertyChanged(nameof(hours));
        }
        public void AddTime()
        {
            if (selectedProject == null || selectedEmployee == null) { return; }
            if (Id <= 0) // Add new Project
            {
                TimeService.Current.Add(new Time { Id = TimeService.Current.Get_Next_Id(), 
                                                   EmployeeId = selectedEmployee.Id, 
                                                   ProjectId = selectedProject.Id, 
                                                   Hours = hours, Narrative = narrative, Date = DateTime.Now });
            }
            else // Edit Project
            {
                var refToUpdate = TimeService.Current.Get(Id) as Time;
                refToUpdate.Narrative = narrative;
                refToUpdate.Hours = hours;
                refToUpdate.EmployeeId = selectedEmployee.Id;
                refToUpdate.ProjectId = selectedProject.Id;
            }
            Shell.Current.GoToAsync("//Times");
        }

    }
}
