

namespace Lib.Main.Core.Models;

internal class UserEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string County { get; set; } = null!;

    public bool EmailConfirmed { get; set; }
}
