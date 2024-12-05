using System.ComponentModel.DataAnnotations;

namespace Lib.Main.Core.Interfaces
{
    public interface IFormValidationService
    {
        List<ValidationResult> Validate<T>(T formModel);
    }
}