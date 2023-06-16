using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private static object instanceLock = new object();
        public static TimeService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new TimeService();
                }

                return instance;
            }
        }
        private List<Time> times;
        private TimeService()
        {
            times = new List<Time>();
        }
        public Time? Get(int id)
        {
            return times.FirstOrDefault(t => t.Id == id);
        }
        public int Get_Next_Id()
        {
            if (times.Count == 0)
                return 1;
            return times.Last().Id + 1;
        }
        public List<Time> Times
        {
            get { return times; }
        }
        public List<Time> Search(string query)
        {
            return Times.Where(p => p.ProjectId.ToString().Contains(query) || 
                               p.EmployeeId.ToString().Contains(query)).ToList();
        }
        public void Add(Time time)
        {
            times.Add(time);
        }
        public void Delete(int id)
        {
            var timeToRemove = Get(id);
            if (timeToRemove != null)
            {
                times.Remove(timeToRemove);
            }
        }
        public void Read()
        {
            times.ForEach(Console.WriteLine);
        }
    }
}
