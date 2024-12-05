using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee.Models;
using employee.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
     //Get All Employee Data   
    [HttpGet]
    public async Task<IActionResult> GetAllEmp()
    {
        var getEmpModel = await employeeRepository.GetAllEmpAsync();
        return Ok(getEmpModel);
    }
    //Get By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> getById([FromRoute] int id)
    {
        var GetByIdModel = await employeeRepository.GetByIdAsync(id);
        if (GetByIdModel == null)
        {
            return NotFound();
        }
        return Ok(GetByIdModel);
    }
    //Create Employee
    [HttpPost]
    public async Task<IActionResult> CreateEmp([FromBody] Employee employee)
    {
        var createModel = await employeeRepository.CreateEmpAsync(employee);
        return CreatedAtAction(nameof(getById), new {id = createModel.Id}, createModel);
    }

    //Update Employee
    [HttpPut ("{id:int}")]
    public async Task<IActionResult> UpdateEmp([FromRoute]int id, [FromBody] Employee employee)
    {
        var updateEmp = await employeeRepository.UpdateEmpAsync(id , employee);
        if (updateEmp == null)
        {
            return NotFound();
        }
        return Ok(updateEmp);
    }

    //Delete Employee
    [HttpDelete ("{id:int}")]
    public async Task<IActionResult> DeleteEmp([FromRoute] int id)
    {
        var deleteEmployee = await employeeRepository.DeleteEmpAsync(id);
        if (deleteEmployee == null)
        {
            return NotFound();
        }
        return Ok(deleteEmployee);
    }

    }
}