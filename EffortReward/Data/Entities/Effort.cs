using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortReward.Data.Entities
{
    public class Effort
    {
        public enum EffortStatus
        {
            DISABLED,
            ENABLED
        };

        public int Id { get; set; }
         
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        
        [Required]
        public int RewardPoints { get; set; }
        
        [Required]
        public int QntRecovered { get; set; }
        
        [Required]
        public EffortStatus Status { get; set; }

        public Effort(string name, string description, int rewardPoints, int qntRecovered, EffortStatus status)
        {
            Name = name;
            Description = description;
            RewardPoints = rewardPoints;
            QntRecovered = qntRecovered;
            Status = status;
        }
    }
}
