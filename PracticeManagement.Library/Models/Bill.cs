using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Bill
    {
        public int ProjectId { get; set; }
        public double TotalAmount { get; set; } // employee rate x time hours
        public DateTime DueDate { get; set; }
        public override string ToString()
        {
            return "\nProjectId: " + ProjectId +
                   "\nTotal Amount: " + TotalAmount +
                   "\nDue Date: " + DueDate +
                   "\n";
        }
    }
}
