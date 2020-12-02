using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EmployeeAggregate.Factory
{
    public class EmployeeHourlySalary : EmployeeFactory
    {
        //private int _id;
        //private string _name;
        //private string _contractTypeName;
        //private int _roleId;
        //private string _roleName;
        //private string _roleDescription;
        //private decimal _hourlySalary;
        //private decimal _monthlySalary;
        //private decimal _annualSalary { get; set; }

        public EmployeeHourlySalary(int id,
                             string name,
                             string contractTypeName,
                             int roleId,
                             string roleName,
                             string roleDescription,
                             decimal hourlySalary,
                             decimal monthlySalary)
        {
            Id = id;
            Name = name;
            ContractTypeName = contractTypeName;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleName;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
            AnnualSalary = 120 * hourlySalary * 12;
        }
    }
}
