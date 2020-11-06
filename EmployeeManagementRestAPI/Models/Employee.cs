using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementRestAPI.Models
{
    public class Employee
    {
        public EmployeePersonal EmployeePersonal { get; set; }
        public OrganizationRecord OrganizationRecord { get; set; }
    }
}
