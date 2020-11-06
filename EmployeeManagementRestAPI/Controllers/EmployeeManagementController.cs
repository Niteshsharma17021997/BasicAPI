using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementRestAPI.Models;
using EmployeeManagementRestAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IManageEmployeeService _manageEmployeeService;
        public EmployeeManagementController(IManageEmployeeService manageEmployeeService)
        {
            _manageEmployeeService = manageEmployeeService;
        }
        [HttpPost]
        [Route("addEmployee")]
        public string AddEmployee([FromBody] Employee employee)
        {
            string output = _manageEmployeeService.AddEmployee(employee.EmployeePersonal, employee.OrganizationRecord);
            return output;
        }

        [HttpPut]
        [Route("updateEmployee")]
        public string UpdateEmployee([FromBody] Employee employee)
        {
            string output = _manageEmployeeService.UpdateEmployee(employee.EmployeePersonal, employee.OrganizationRecord);
            return output;
        }

        [HttpGet]
        [Route("fetchEmployee")]
        public List<Employee> FetchEmployees()
        {
            List<Employee> ListEmployee = _manageEmployeeService.FetchEmployee();
            return ListEmployee;
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public string DeleteEmployees([FromBody]EmployeePersonal employeePersonal)
        {
            string output = _manageEmployeeService.DeleteEmployee(employeePersonal);
            return output;
        }
    }
}
