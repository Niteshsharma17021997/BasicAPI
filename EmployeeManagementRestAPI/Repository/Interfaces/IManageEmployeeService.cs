using EmployeeManagementRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementRestAPI.Repository.Interfaces
{
    public interface IManageEmployeeService
    {
        string AddEmployee(EmployeePersonal employeePersonal, OrganizationRecord organizationRecord);
        string UpdateEmployee(EmployeePersonal employeePersonal, OrganizationRecord organizationRecord);
        List<Employee> FetchEmployee();
        string DeleteEmployee(EmployeePersonal employeePersonal);
    }
}
