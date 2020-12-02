using Newtonsoft.Json;
using System;

namespace Shared
{
    public class EmployeeDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contractTypeName")]
        public string ContractTypeName { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("annualSalary")]
        public decimal AnnualSalary { get; set; }
    }
}
