using PracticeManagement.CLI.Models;
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
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddBillCommand { get; set; }
        private void SetCommands()
        {
            DeleteCommand = new Command(
                (p) => ExecuteDelete((p as TimeViewModel).Model.Id));
            EditCommand = new Command(
                (p) => ExecuteEdit((p as TimeViewModel).Model.Id));
            AddBillCommand = new Command(
                (p) => ExecuteAddBill((p as TimeViewModel).Model.Id));
        }
        public void ExecuteDelete(int id)
        {
            TimeService.Current.Delete(id);
        }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//TimeDetails?timeId={id}");
        }
        public void ExecuteAddBill(int id)
        {
            
            Shell.Current.GoToAsync($"//BillDetails?timeId={id}");
        }
        public TimeViewModel(Time time)
        {
            Model = time;
            SetCommands();
        }
        public TimeViewModel(int id)
        {
            if (id > 0)
                Model = TimeService.Current.Get(id);
            else
                Model = new Time();
            SetCommands();
        }
        public TimeViewModel()
        {
            Model = new Time();
            SetCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}
