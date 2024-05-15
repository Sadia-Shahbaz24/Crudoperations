using crud_app.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_app.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }
    [HttpPost()]
    public async Task<ActionResult> AddEmployee([FromBody] Employee model)
    {
      await _employeeRepository.AddEmployeeAsync(model);
      return Ok();
    }
    [HttpGet]
    public async Task<ActionResult> GetEmployeeList() //get api 
    {
      var employeeList = await _employeeRepository.GetAllEmployeesAsync();
      return Ok(employeeList);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetEmployeeById([FromRoute] int id) //get api 
    {
      var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
      return Ok(employee);

    }

    [HttpPut("{id}")] //for update put() use                      
    public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model) //get api 
    {
      await _employeeRepository.UpdateEmployeeAsync(id, model);
      return Ok();

    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
    {
      await _employeeRepository.DeleteEmployeeAsync(id);
      return Ok();

    }
  }

}