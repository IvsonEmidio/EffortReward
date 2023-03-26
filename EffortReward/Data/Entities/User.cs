using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortReward.Data.Entities;

public class User
{
    [Key] public int Id { get; set; }

    [Required]
    [Column("name", TypeName = "varchar(50)")]
    public string Name { get; set; }

    [Required]
    [Column("email", TypeName = "varchar(125)")]
    public string Email { get; set; }

    [Required]
    [Column("password", TypeName = "varchar(255)")]
    public string Password { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime DeletedAt { get; set; }

    [Required] 
    public Wallet Wallet { get; set; }

    public User(
        string name,
        string email,
        string password,
        DateTime createdAt,
        DateTime deletedAt)
    {
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        DeletedAt = deletedAt;
    }
}