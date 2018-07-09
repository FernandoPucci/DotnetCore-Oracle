using System.Collections.Generic;
using System.Linq;
using EmployeesAPI.Model;
using EmployeesAPI.OracleHelpers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            string sql = "select EMPLOYEE_ID, FIRST_NAME, LAST_NAME from Employees";  
            List<Employees> temps = OracleContext.QueryForList<Employees>(sql).ToList();  
            return temps;
        }
        
    }
}