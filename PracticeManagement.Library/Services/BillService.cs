using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class BillService
    {
        private static BillService? instance;
        private static object instanceLock = new object();
        public static BillService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new BillService();
                }

                return instance;
            }
        }
        private List<Bill> bills;
        private BillService()
        {
            bills = new List<Bill>();
        }
        public List<Bill> Bills
        {
            get { return bills; }
        }
        public void Add(Bill bill)
        {
            bills.Add(bill);
        }
        public Bill? Get(int projectId)
        {
            return bills.FirstOrDefault(b => b.ProjectId == projectId);
        }
        public List<Bill>? Get_By_Id(int projectId)
        {
            List<Bill> returnVal = new List<Bill>();
            foreach (Bill bill in bills)
            {
                if (bill.ProjectId.Equals(projectId))
                {
                    returnVal.Add(bill);
                }
            }
            return returnVal;
        }
    }
}
