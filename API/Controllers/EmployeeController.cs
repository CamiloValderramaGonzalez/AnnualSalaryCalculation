using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.EmployeeAggregate.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers
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
        public async Task<ActionResult<List<EmployeeDTO>>> Get()
        {
            try
            {
                var result = await _employeeService.EmployeeGet(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployeeDTO>>> Get(int id)
        {
            try
            {
                var result = await _employeeService.EmployeeGet(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}