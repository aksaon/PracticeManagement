using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.MAUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string test2;
        public string Test1
        {
            get
            {
                return "Test1";
            }
        }

        public string Test2
        {
            get
            {
                return test2;
            }
            set
            {
                test2 = value;
                NotifyPropertyChanged();
            }
        }

        public string Test3
        {
            get
            {
                return "Test3";
            }
        }

        public string Test4
        {
            get
            {
                return "Test4";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
