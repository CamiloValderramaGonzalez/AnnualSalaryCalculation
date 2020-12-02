using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EmployeeAggregate.Entities
{
    public class Employee
    {
        [JsonProperty("id")]
        public int id;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("contractTypeName")]
        public string contractTypeName;

        [JsonProperty("roleId")]
        public int roleId;

        [JsonProperty("roleName")]
        public string roleName;

        [JsonProperty("roleDescription")]
        public string roleDescription;

        [JsonProperty("hourlySalary")]
        public decimal hourlySalary;

        [JsonProperty("monthlySalary")]
        public decimal monthlySalary;
    }
}
