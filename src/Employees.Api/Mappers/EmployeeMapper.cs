using Employees.Api.ClientDtos;
using Employees.Core.DomainModels;

namespace Employees.Api.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeSaveRequest Map(EmployeeSaveRequestDto dto)
        {
            return new EmployeeSaveRequest
            {
                Name = dto.Name,
                SalaryModel = new SalaryModel
                {
                    Type = dto.SalaryType,
                    Rate = dto.SalaryRate,
                    IncludeTax = dto.IncludeTax
                }
            };
        }

        public static EmployeeResponseDto Map(Employee model)
        {
            if (model == null)
            {
                return null;
            }
            return new EmployeeResponseDto
            {
                Id = model.Id,      
                Name = model.Name,
                SalarySum = model.SalarySum
            };
        }

    }
}
