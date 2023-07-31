using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticeManagement.MAUI.ViewModels
{
    public class BillDetailsViewModel
    {
        public int projectId { get; set; }
        public DateOnly dueDate { get; set; }
        public double totalAmount { get; set; }
        public BillDetailsViewModel(int timeId) 
        {
            projectId = TimeService.Current.Get_Proj_Id(timeId);
            totalAmount = TimeService.Current.Get_Hours(timeId) * EmployeeService.Current.Get_Rate(TimeService.Current.Get_Employee(timeId));

        }
        public void AddBill(DateTime date) // change to not add already added bills
        {
            
            BillService.Current.Add(new Bill { ProjectId = projectId, DueDate = date, TotalAmount = totalAmount });
           
            Shell.Current.GoToAsync("//Times");
        }
    }
}
