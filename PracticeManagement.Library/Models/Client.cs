using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.CLI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public Boolean IsActive { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

        public List<Project> Projects = new List<Project>();

       


        public override string ToString()
        {
            string returnValue = "Id: " + Id +
                                 "\nName: " + Name +
                                 "\nOpen Date: " + OpenDate;
            if(IsActive == false)
            {
                returnValue += "\nClose Date: ";
                returnValue += CloseDate;
            }
                
            returnValue += "\nNotes: " + Notes +
                           "\nAssociated Projects: \t";

           // If no projects, don't try to print them
           if (Projects == null ) { return returnValue; }
           
           foreach(var project in Projects) 
           {
                returnValue += "Project ID: ";
                returnValue += project.Id;
                returnValue += ", Long Name: ";
                returnValue += project.LongName;
                returnValue += "\t";
           }
           return returnValue;
        }
    }
}
