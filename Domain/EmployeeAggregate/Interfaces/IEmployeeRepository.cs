using Domain.EmployeeAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EmployeeAggregate.Interfaces
{
    public interface IEmployeeRepository:IDisposable
    {
        Task<List<Employee>> EmployeesGet();
    }
}
