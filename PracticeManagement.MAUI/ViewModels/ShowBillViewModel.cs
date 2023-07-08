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
    public class ShowBillViewModel : INotifyPropertyChanged
    {
        public List<List<Bill>> ThisBill { get; set; }
        public string Display
        {
            get
            {
                string returnVal = "";
                foreach(var item in ThisBill)
                {
                    foreach(var bill in item)
                    {
                        returnVal += bill.ToString();
                    }
                }
                return returnVal;
            }
        }
        public ShowBillViewModel(List<Project> projects) 
        { 
            if(projects != null)
            {
                ThisBill = new List<List<Bill>>();
                foreach (Project project in projects)
                {
                    List<Bill> bill = new List<Bill>();
                    bill = BillService.Current.Get_By_Id(project.Id);
                    ThisBill.Add(bill);
                }
                NotifyPropertyChanged(nameof(ThisBill));
            }
            
        }
        public ShowBillViewModel(int projectId = 0)
        {
            if (projectId != 0)
            {
                ThisBill = new List<List<Bill>>();
                ThisBill.Add(BillService.Current.Get_By_Id(projectId));
                NotifyPropertyChanged(nameof(ThisBill));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
