using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementRestAPI.Models
{
    public class EmployeePersonal
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string PAN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

    }
}
