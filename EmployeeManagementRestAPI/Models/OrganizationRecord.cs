using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementRestAPI.Models
{
    public class OrganizationRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsStillEmployee { get; set; }
    }
}
