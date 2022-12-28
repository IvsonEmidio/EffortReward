using EffortReward.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Models
{
    public class WeeklyHistoryContext : DbContext
    {
        public WeeklyHistoryContext(DbContextOptions<WeeklyHistoryContext> options): base(options) { }
        public DbSet<WeeklyHistory> WeeklyHistory { get; set; }
    }
}
