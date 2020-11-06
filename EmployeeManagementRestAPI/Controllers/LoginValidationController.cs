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
    public class LoginValidationController : ControllerBase
    {
        private ILoginValidateService _loginValidateService;
        public LoginValidationController(ILoginValidateService loginValidateService)
        {
            _loginValidateService = loginValidateService;
        }

        [HttpPost]
        [Route("validateCredentials")]
        public OrganizationRecord ValidateCredentails([FromBody] EmployeePersonal employee)
        { 
            OrganizationRecord orgRecord = _loginValidateService.ValidateCredentails(employee);
            return orgRecord;
        }
    }
}
