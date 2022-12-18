using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApi.Domain.Entities;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? RefreshToken { get; set; } = null!;
    public DateTime? RefreshTokenExpireDate { get; set; }

}