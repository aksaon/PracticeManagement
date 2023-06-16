using PracticeManagement.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private static object instanceLock = new object();
        public static ProjectService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProjectService();
                }

                return instance;
            }
        }
        private List<Project> projects;
        private ProjectService()
        {
            projects = new List<Project>();
        }
        public Project? Get(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }
        public int Get_Next_Id()
        {
            if (projects.Count == 0)
                return 1;
            return projects.Last().Id + 1;
        }
        public List<Project> Projects
        {
            get { return projects; }
        }
        public List<Project> Search(string query)
        {
            return Projects.Where(p => p.ShortName.ToUpper().Contains(query.ToUpper()) ||
                                  p.LongName.ToUpper().Contains(query.ToUpper())).ToList();
        }
        public void Add(Project project)
        {
            projects.Add(project);
        }
        public void Delete(int id)
        {
            var projectToRemove = Get(id);
            if (projectToRemove != null)
            {
                projects.Remove(projectToRemove);
            }
        }
        public void Close(int id)
        {
            var projectToClose = Get(id);
            if (projectToClose != null)
            {
                projectToClose.CloseDate = DateTime.Now;
                projectToClose.IsActive = false;
            }
        }
        public void Read()
        {
            projects.ForEach(Console.WriteLine);
        }
    }
}
