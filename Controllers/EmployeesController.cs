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
            string sql = $"select EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, HIRE_DATE, JOB_ID,SALARY, COMMISSION_PCT, MANAGER_ID, DEPARTMENT_ID from Employees";
            List<Employees> temps = OracleContext.QueryForList<Employees>(sql).ToList();
            return temps;
        }


        [HttpGet("{id}")]
        public  IActionResult GetById(long id)
        {
            string sql = $"select EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, HIRE_DATE, JOB_ID,SALARY, COMMISSION_PCT, MANAGER_ID, DEPARTMENT_ID from Employees";
            List<Employees> temps = OracleContext.QueryForList<Employees>(sql).Where(e => e.EMPLOYEE_ID == id).ToList();

            if (temps.Count() == 0)
                return NotFound();
            else
                return Ok(temps);
        }
    }
}