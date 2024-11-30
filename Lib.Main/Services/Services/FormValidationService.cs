

using System.ComponentModel.DataAnnotations;

namespace Lib.Main.Services.Services;

internal class FormValidationService
{
    /// <summary>
    /// Returns NULL if no errors
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="formModel">Type that uses DataAnnotation for property validation</param>
    /// <returns></returns>
    public List<ValidationResult> Validate<T>(T formModel)
    {
        var context = new ValidationContext(formModel);
        var validationResluts = new List<ValidationResult>();

        if (!Validator.TryValidateObject(formModel, context, validationResluts, true))
        {
            return validationResluts;
        }
        return null;
    }
}
