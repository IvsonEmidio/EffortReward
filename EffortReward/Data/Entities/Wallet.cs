using System.ComponentModel.DataAnnotations;

namespace EffortReward.Data.Entities;

public class Wallet
{
    public int Id { get; set; }
    
    [Required]
    public int Points { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    public DateTime? LastUpdate { get; set; }

    public Wallet(int points, int userId, DateTime? lastUpdate)
    {
        Points = points;
        UserId = userId;
        LastUpdate = lastUpdate;
    }
}