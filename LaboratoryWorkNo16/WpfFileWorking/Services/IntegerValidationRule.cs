using System.Globalization;
using System.Windows.Controls;

namespace WpfFileWorking.Services
{
    public class IntegerValidationRule : ValidationRule
    {
        public const string NeedNaturalNumberMessage = "Целое число должно быть натуральным.";
        public const string NeedInteger = "Значение должно быть целым числом.";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int result))
            {
                if (result <= 0)
                {
                    return new ValidationResult(false, NeedNaturalNumberMessage);
                }
                
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, NeedInteger);
            }
        }
    }

}