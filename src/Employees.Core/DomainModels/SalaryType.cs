namespace Employees.Core.DomainModels
{
    public enum SalaryType : byte
    {
        /// <summary>
        /// Фиксированный ежемесячный платеж
        /// </summary>      
        Fixed = 0,

        /// <summary>
        /// Почасовая ставка
        /// </summary>
        Hourly = 1,
    }
}
