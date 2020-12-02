using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace FrontEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> Employee()
        {
            var result = await _employeeService.EmployeesGet(null);
            return Ok(result);
        }
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<List<EmployeeDTO>>> Employee(int id)
        {
            var result = await _employeeService.EmployeesGet(id);
            return Ok(result);
        }
    }
}