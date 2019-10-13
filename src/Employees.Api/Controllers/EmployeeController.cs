using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Api.ClientDtos;
using Employees.Api.Mappers;
using Employees.Core.Interfaces.Business.Employees;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.Business.Salary;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Employees.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCreator _employeeCreator;
        private readonly IEmployeeUpdater _employeeUpdater;
        private readonly IEmployeeRemover _employeeRemover;
        private readonly IEmployeeReader _employeeReader;
        private readonly ISalaryReader _salaryReader;

        public EmployeeController(
            IEmployeeCreator employeeCreator,
            IEmployeeReader employeeReader,
            IEmployeeUpdater employeeUpdater,
            IEmployeeRemover employeeRemover,
            ISalaryReader salaryReader)
        {
            _employeeCreator = employeeCreator;
            _employeeUpdater = employeeUpdater;
            _employeeRemover = employeeRemover;
            _employeeReader = employeeReader;
            _salaryReader = salaryReader;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Tags = new[] { "Добавить сотрудника" })]
        public async Task<IActionResult> Post([FromBody] EmployeeSaveRequestDto dto)
        {
            var employee = EmployeeMapper.Map(dto);
            await _employeeCreator.CreateAsync(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(200)]
        [SwaggerOperation(Tags = new[] { "Изменить данные сотрудника" })]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeSaveRequestDto dto)
        {
            var employee = EmployeeMapper.Map(dto);
            await _employeeUpdater.UpdateAsync(id, employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(200)]
        [SwaggerOperation(Tags = new[] { "Удалить сотрудника" })]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRemover.DeleteAsync(id);
            return Ok();
        }
   
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(EmployeeResponseDto))]
        [SwaggerOperation(Tags = new[] { "Постраничный список сотрудников" })]
        public async Task<ActionResult<IEnumerable<EmployeeResponseDto>>> Get([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var result = await _employeeReader.GetListAsync(pageSize, pageIndex);
            return result.Select(EmployeeMapper.Map).ToArray();
        }

        [HttpGet("{name}")]
        [Produces("application/json")]
        [ProducesResponseType(404, Type = typeof(string))]      
        [ProducesResponseType(200, Type = typeof(EmployeeResponseDto))]
        [SwaggerOperation(Tags = new[] { "Получить данные сотрудника по имени" })]
        public async Task<ActionResult<EmployeeResponseDto>> Get(string name)
        {
            var result = await _employeeReader.GetByNameAsync(name);            
            return EmployeeMapper.Map(result);
        }

        [Route("api/v1/[controller]/TotalSalarySum")]
        [HttpGet]
        [Produces("application/json")]       
        [ProducesResponseType(200, Type = typeof(decimal))]
        [SwaggerOperation(Tags = new[] { "Общая сумма ежемесячных выплат" })]
        public async Task<ActionResult<decimal>> TotalSum()
        {
            return await _salaryReader.GetSalarySumAsync();           
        }

        [Route("api/v1/[controller]/EmployeeWithMaxSum")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(EmployeeResponseDto))]
        [SwaggerOperation(Tags = new[] { "Сотрудник с максимальной зарплатой" })]
        public async Task<ActionResult<EmployeeResponseDto>> EmployeeWithMaxSum()
        {
            var result = await _salaryReader.GetEmployeeWithMaxSalaryAsync();        
            return EmployeeMapper.Map(result);
        }

    }
}
