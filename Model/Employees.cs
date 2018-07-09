using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EmployeesAPI.Model
{
    [Table(@"EMPLOYEES")]
    public class Employees
    {
        [Key()]
        [Column(name: @"EMPLOYEE_ID")]
        [JsonProperty(@"employeeId")]
        public long EMPLOYEE_ID { get; set; }

        [Column(name: @"FIRST_NAME")]
        [JsonProperty(@"firstName")]
        public string FIRST_NAME { get; set; }

        [Column(name: @"LAST_NAME")]
        [JsonProperty(@"lastName")]
        public string LAST_NAME { get; set; }

        [Column(name: @"EMAIL")]
        [JsonProperty(@"email")]
        public string EMAIL { get; set; }

        [Column(name: @"PHONE_NUMBER")]
        [JsonProperty(@"phoneNumber")]
        public string PHONE_NUMBER { get; set; }

        [Column(name: @"HIRE_DATE")]
        [JsonProperty(@"hireDate")]
        public DateTime HIRE_DATE { get; set; }

        [Column(name: @"JOB_ID")]
        [JsonProperty(@"jobId")]
        public string JOB_ID { get; set; }

        [Column(name: @"SALARY")]
        [JsonProperty(@"salary")]
        public double SALARY { get; set; }

        [Column(name: @"COMMISSION_PCT")]
        [JsonProperty(@"commissionPct")]
        public double COMMISSION_PCT { get; set; }

        [Column(name: @"MANAGER_ID")]
        [JsonProperty(@"managerId")]
        public long MANAGER_ID { get; set; }

        [Column(name: @"DEPARTMENT_ID")]
        [JsonProperty(@"departmentId")]
        public long DEPARTMENT_ID { get; set; }

    }
}