﻿using PracticeManagement.Library.Models;
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
    public class TimeViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                return
                    new ObservableCollection<TimeViewModel>
                    (TimeService
                        .Current.Search(Query ?? string.Empty)
                        .Select(t => new TimeViewModel(t)).ToList());
            }
        }
      
        public string Query { get; set; }
        public void Search()
        {
            NotifyPropertyChanged("Times");
        }
        public void Delete()
        {
            if (SelectedTime == null)
            {
                return;
            }
            TimeService.Current.Delete(SelectedTime.Id);
            NotifyPropertyChanged("Times");
            SelectedTime = null;
        }
        public void Add(Shell s)
        {
            s.GoToAsync($"//TimeDetails?timeId=0"); // check id
        }
        public void Edit(Shell s)
        {
            if (SelectedTime == null)
            {
                return;
            }
            var idParam = SelectedTime.Id;
            s.GoToAsync($"//TimeDetails?timeId={idParam}"); // check id
        }
        public Time SelectedTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Times));
        }
    }
}

