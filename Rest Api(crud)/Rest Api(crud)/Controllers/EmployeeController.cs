using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rest_Api_crud_.Data;

namespace Rest_Api_crud_.Controllers
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
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model) {
            await _employeeRepository.AddEmployee(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployeeList()
        {
            var employeList=await _employeeRepository.GetAllEmployee();
            return Ok(employeList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
        {    
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee!=null) {
            return Ok(employee);

            }
            else {
                return Ok("Not Found");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
        {
            await _employeeRepository.UpdateEmployee(id, model);
            return Ok("update Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployeeAsnyc(id);
            return Ok("successfully delete");
        }
    }
}
