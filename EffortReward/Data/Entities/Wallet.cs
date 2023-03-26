using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortReward.Data.Entities;

public class Wallet
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column("points", TypeName = "int")]
    public int Points { get; set; }
    
    
    [Required]
    [Column("updated_at", TypeName = "timestamp")]
    public DateTime UpdatedAt { get; set; }
    
    [ForeignKey("user_id")]
    public int UserId { get; set; }

    [Required] 
    public User User { get; set; }
}