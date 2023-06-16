using PracticeManagement.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Time
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Narrative { get; set; }
        public double Hours { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public override string ToString()
        {
            return "\nEmployee ID: " + EmployeeId +
                   "\nProject ID: " + ProjectId +
                   "\nHours: " + Hours +
                   "\nDate: " + Date +
                   "\nNarrative: " + Narrative +
                   "\n";
        }
    }
}
