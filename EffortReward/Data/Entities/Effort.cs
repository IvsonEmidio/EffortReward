namespace EffortReward.Data.Entities
{
    public class Effort
    {
        public enum EffortStatus
        {
            AVAILABLE,
            STARTED,
            FAILED,
            DONE
        };

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int RewardPoints { get; set; }
        public bool Status { get; set; }

    }
}
