using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Employees.Api.Infrastracture
{
    public class EnumValidationAttribute : ValidationAttribute
    {

        private readonly Type _enumType;

        public EnumValidationAttribute(Type enumType) : base()
        {
            _enumType = enumType;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var type = value.GetType();
            if (!type.IsEnum)
            {
                return false;
            }

            return type.IsEnumDefined(value);
        }

        public override string FormatErrorMessage(string name)
        {
            var values = string.Join(", ", Enum.GetValues(_enumType).Cast<byte>());
            return $"Поле должно принимать одно из следующих допустимых значений: {values}.";
        }
    }
}
