﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.CLI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public Boolean IsActive { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; }

        public override string ToString()
        {
            return "Id: " + Id +
                   "\nLong Name: " + LongName +
                   "\nShort Name: " + ShortName +
                   "\nOpen Date: " + OpenDate +
                   "\nAssociated Client: " + ClientId +
                   "\n";
        }
    }
}
