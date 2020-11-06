using EmployeeManagementRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementRestAPI.Repository.Interfaces
{
    public interface ILoginValidateService
    {
        OrganizationRecord ValidateCredentails(EmployeePersonal employee);
    }
}
