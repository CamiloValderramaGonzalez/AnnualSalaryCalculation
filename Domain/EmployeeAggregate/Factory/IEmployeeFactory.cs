using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EmployeeAggregate.Factory
{
    interface IEmployeeFactory
    {
        EmployeeFactory GetEmployee(int id,
                             string name,
                             string contractTypeName,
                             int roleId,
                             string roleName,
                             string roleDescription,
                             decimal hourlySalary,
                             decimal monthlySalary);
    }
}
