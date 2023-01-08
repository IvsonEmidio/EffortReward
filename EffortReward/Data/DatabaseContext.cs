using EffortReward.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
        //Generic Entities
        public DbSet<WeeklyHistory> WeeklyHistory { get; set; }
        public DbSet<Effort> Effort { get; set; }
    }
}
