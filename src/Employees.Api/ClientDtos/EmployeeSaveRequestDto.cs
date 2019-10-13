using Employees.Api.Infrastracture;
using Employees.Core.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Employees.Api.ClientDtos
{
    public class EmployeeSaveRequestDto
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Тип оплаты: фиксированная или почасовая
        /// </summary>
        [EnumValidation(typeof(SalaryType))]
        public SalaryType SalaryType { get; set; }

        /// <summary>
        /// Сумма оплаты за час или месяц в зависимости от типа
        /// </summary>
        [Required]
        [Range(0, 999999.99)]
        public decimal SalaryRate { get; set; }

        /// <summary>
        /// Сумма уже включает налоги или нет
        /// </summary>
        public bool IncludeTax { get; set; }
    }
}
