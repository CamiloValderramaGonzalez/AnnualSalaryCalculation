using Domain.EmployeeAggregate.Entities;
using Domain.EmployeeAggregate.Factory;
using Domain.EmployeeAggregate.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EmployeeAggregate.Services
{
    public class EmployeeService : IEmployeeFactory
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> EmployeeGet(int? id)
        {
            try
            {
                var result = await _employeeRepository.EmployeesGet();
                if (id.HasValue)
                {
                    result = result.Where(x => x.id == id).ToList();
                }
                List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();
                foreach (var item in result)
                {
                    EmployeeFactory employeeFactory = GetEmployee(item.id,
                                item.name,
                                item.contractTypeName,
                                item.roleId,
                                item.roleName,
                                item.roleDescription,
                                item.hourlySalary,
                                item.monthlySalary);

                    if (employeeFactory != null)
                    {
                        EmployeeDTO employeeDTO = new EmployeeDTO();
                        employeeDTO.Id = item.id;
                        employeeDTO.Name = item.name;
                        employeeDTO.RoleName = item.roleName;
                        employeeDTO.ContractTypeName = item.contractTypeName;
                        employeeDTO.AnnualSalary = employeeFactory.AnnualSalary;
                        employeesDTO.Add(employeeDTO);
                    }
                }
                return employeesDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeFactory GetEmployee(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary)
        {
            EmployeeFactory employeeFactory = null;
            switch (contractTypeName.ToLower())
            {
                case "hourlysalaryemployee":
                    employeeFactory = new EmployeeHourlySalary(id,
                                name,
                                contractTypeName,
                                roleId,
                                roleName,
                                roleDescription,
                                hourlySalary,
                                monthlySalary);
                    break;
                case "monthlysalaryemployee":
                    employeeFactory = new EmployeeMonthlySalary(id,
                                name,
                                contractTypeName,
                                roleId,
                                roleName,
                                roleDescription,
                                hourlySalary,
                                monthlySalary);
                    break;
            }
            return employeeFactory;
        }
    }
}
