using System.ComponentModel.DataAnnotations;

namespace Lib.Main.Core.Models;

public class UserFormModel
{
    [Required]
    [RegularExpression(@"^[a-öA-Ö' -]{1,15}$", ErrorMessage = "First name can not contain special characters or numbers")]
    public string FirstName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[a-öA-Ö' -]{1,15}$", ErrorMessage = "Last name can not contain special characters or numbers")]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is invalid (name@domain.com)")]
    public string Email { get; set; } = null!;

    [Required]
    [Phone]
    [RegularExpression(@"^[0-9]+$")]
    public string PhoneNumber { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string PostalCode { get; set; } = null!;
    public string County { get; set; } = null!;
}
